using DataAccessLayer.Data;
using DataAccessLayer.Entity.Products;
using DataAccessLayer.Repository.GenericsRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository.ProductsRepository
{
    public class ProductRepository : GenericRepository<Product> , IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }


        public async Task<Product> GetProductByName(string name)
        {
            var Product = await _context.Products.FirstOrDefaultAsync(p => p.Name == name);
            return Product;
        }

        
    }
}
