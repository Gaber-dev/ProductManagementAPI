using BussinessLayer.Dtos;
using DataAccessLayer.Entity.Products;
using DataAccessLayer.Repository.ProductsRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repo;

        public ProductService(IProductRepository repo)
        {
            _repo = repo;
        }

        public async Task AddProduct(AddProductDto dto)
        {
            if (dto.Name == null || dto.Description == null || dto.Price <= 0 || dto.Stock <= 0 )
                throw new Exception("Please Enter Complete and non Product");



            var ProductToDb = new Product
            {
              Name = dto.Name,
              Description = dto.Description,
              Price = dto.Price,
              Stock = dto.Stock
            };
            await _repo.AddEntity(ProductToDb);
        }


        public async Task<IEnumerable<AddProductDto>> GetAllProducts()
        {
            var productsFromDb = await _repo.GetAll();
           var productToUser =  productsFromDb.Select(product => new AddProductDto
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Stock = product.Stock
            });
            return productToUser;
        }


        public async Task<AddProductDto> GetProductById(int id)
        {
            var EntityfromDb = await _repo.GetEntityById(id);
            if (EntityfromDb == null)
                throw new Exception("This product is not exists.");

            var entityToUser = new AddProductDto
            {
                Name = EntityfromDb.Name,
                Description = EntityfromDb.Description,
                Price = EntityfromDb.Price,
                Stock = EntityfromDb.Stock
            };
            
            
            return entityToUser;
        }



        public async Task UpdateProduct(AddProductDto dto)
        {
            var productFromDb = await _repo.GetProductByName(dto.Name);

            if (productFromDb == null)
                throw new Exception("Product not found");

            if (!string.IsNullOrEmpty(dto.Description) && dto.Description != "string")
                productFromDb.Description = dto.Description;

            if (dto.Price != 0)
                productFromDb.Price = dto.Price;

            if (dto.Stock != 0)
                productFromDb.Stock = dto.Stock;

           await _repo.UpdateEntity(productFromDb);

        }



        public async Task DeleteProduct(int id)
        {
            await _repo.DeleteEntity(id);
        }




    }
}
