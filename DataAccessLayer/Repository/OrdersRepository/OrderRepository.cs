using DataAccessLayer.Data;
using DataAccessLayer.Entity.Orders;
using DataAccessLayer.Repository.GenericsRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository.OrdersRepository
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context) : base(context) 
        {
            _context = context;
        }

        public async Task<IEnumerable<Order>> GetAllOrdersWithProduct()
        {
           return await  _context.Orders.Include(o => o.ProductsOrder)
                .ThenInclude(o => o.Product)
                .Include(o => o.Customer)
                .ToListAsync();
        }


        public async Task<Order?> GetOneOrderwithProduct(int id)
        {
            return await _context.Orders.Include(o => o.ProductsOrder)
                 .ThenInclude(o => o.Product)
                 .Include(o => o.Customer)
                 .FirstOrDefaultAsync(o => o.Id == id);
        }



    }
}
