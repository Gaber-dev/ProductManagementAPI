using BussinessLayer.Dtos;
using DataAccessLayer.Data;
using DataAccessLayer.Entity.Customers;
using DataAccessLayer.Entity.OrderProducts;
using DataAccessLayer.Entity.Orders;
using DataAccessLayer.Entity.Products;
using DataAccessLayer.Repository.OrdersRepository;
using DataAccessLayer.Repository.ProductsOrderRepository;
using DataAccessLayer.Repository.ProductsRepository;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Services.OrderServices
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _order;
        private readonly ApplicationDbContext _context;
        private readonly IProductRepository _productrepo;
        private readonly IProductOrderRepository _pOrderrepo;

        public OrderService(IOrderRepository order , ApplicationDbContext context , IProductRepository productrepo , IProductOrderRepository pOrderrepo)
        {
            _order = order;
            _context = context;
            _productrepo = productrepo;
            _pOrderrepo = pOrderrepo;
        }


        public async Task AddOrder(AddOrderDto dto , int CustomerId)
        {

            if (dto.Items == null || dto.Items.Count == 0)
                throw new Exception("Order must contain at least one product");

            double totalAmount = 0;

            var orderProducts = new List<OrderProduct>();

            foreach (var item in dto.Items)
            {
                var product = await _productrepo.GetProductByName(item.ProductName);
                if (product == null)
                    throw new Exception($"Product '{item.ProductName}' is not available.");

                if (product.Stock < item.Quantity)
                    throw new Exception($"Not enough stock for '{item.ProductName}'.");

                totalAmount += product.Price * item.Quantity;

                var op = new OrderProduct
                {
                    ProductId = product.Id,
                    Quantity = item.Quantity
                };

                orderProducts.Add(op);

                product.Stock -= item.Quantity;
                await _productrepo.UpdateEntity(product);
            }

            var orderToDb = new Order
            {
                CustomerId = CustomerId,
                TotalAmount = totalAmount,
                OrderDate = dto.OrderDate
            };

            await _order.AddEntity(orderToDb);

            foreach (var op in orderProducts)
            {
                op.OrderId = orderToDb.Id;
                await _pOrderrepo.AddEntity(op);
            }

        }


        public async Task<IEnumerable<GetAllOrdersDto>> GetAllOrders()
        {
            var orders = await _order.GetAllOrdersWithProduct();

            var result = orders.Select(o => new GetAllOrdersDto
            {
                OrderId = o.Id,
                CustomerName = o.Customer?.Name ?? string.Empty,
                CustomerPhone = o.Customer?.PhoneNumber ?? string.Empty,
                TotalAmount = o.TotalAmount,
                Products = o.ProductsOrder
                    .Select(po => new ProductInOrderDto
                    {
                        ProductName = po.Product?.Name ?? string.Empty,
                        Quantity = po.Quantity
                    })
                    .ToList()
            });

            return result;
        }


        public async Task<GetAllOrdersDto> GetOneOrderById(int id)
        {
            var orderfromDb = await _order.GetOneOrderwithProduct(id);

            if (orderfromDb == null)
                throw new Exception("Order is not found");

            var dto = new GetAllOrdersDto
            {
                OrderId = orderfromDb.Id,
                CustomerName = orderfromDb.Customer?.Name ?? string.Empty,
                CustomerPhone = orderfromDb.Customer?.PhoneNumber ?? string.Empty,
                TotalAmount = orderfromDb.TotalAmount,
                Products = orderfromDb.ProductsOrder
                    .Select(po => new ProductInOrderDto
                    {
                        ProductName = po.Product?.Name ?? string.Empty,
                        Quantity = po.Quantity
                    })
                    .ToList()
            };

            return dto;
        }



        public async Task UpdateOrder(UpdateOrderDto dto)
        {
            var orderFromDb = await _order.GetOneOrderwithProduct(dto.OrderID);
            if (orderFromDb == null)
                throw new Exception("Order does not exist");

            var orderProduct = orderFromDb.ProductsOrder.FirstOrDefault();
            if (orderProduct == null)
                throw new Exception("Order has no product");

            var product = orderProduct.Product;
            if (product == null)
            {
                product = await _productrepo.GetEntityById(orderProduct.ProductId);
                if (product == null)
                    throw new Exception("Product not found");
            }

            if ( dto.NumberOfItems > 0)
            {
                int existingQuantity = orderProduct.Quantity;
                int newQuantity = dto.NumberOfItems;

                int difference = newQuantity - existingQuantity;

                if (difference > 0)
                {
                    if (product.Stock < difference)
                        throw new Exception("There is not enough stock to add more items.");

                    product.Stock -= difference;
                }
                else if (difference < 0)
                {
                    product.Stock += (-difference);
                }

                orderProduct.Quantity = newQuantity;

                orderFromDb.TotalAmount = newQuantity * product.Price;

                await _productrepo.UpdateEntity(product);
                await _pOrderrepo.UpdateEntity(orderProduct);
                await _order.UpdateEntity(orderFromDb);
            }
            else
            {
                throw new Exception("NumberOfItems must be greater than 0.");
            }
        }
        


        public async Task DeleteOrder(int orderId)
        {
            var orderfromdb = await _order.GetOneOrderwithProduct(orderId);
            if (orderfromdb == null)
                throw new Exception("Order does not exist");

            foreach (var orderproduct in orderfromdb.ProductsOrder.ToList())
            {
                Product product = orderproduct.Product;

                if (product == null)
                {
                    product = await _productrepo.GetEntityById(orderproduct.ProductId);
                }

                if (product != null)
                {
                    product.Stock += orderproduct.Quantity;
                    await _productrepo.UpdateEntity(product);
                }

                await _pOrderrepo.DeleteEntity(orderproduct.Id);
            }

            await _order.DeleteEntity(orderfromdb.Id);
        }

    }







    
}
