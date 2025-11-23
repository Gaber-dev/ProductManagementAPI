using DataAccessLayer.Data;
using DataAccessLayer.Entity.OrderProducts;
using DataAccessLayer.Entity.Products;
using DataAccessLayer.Repository.GenericsRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository.ProductsOrderRepository
{
    public class ProductOrderRepository : GenericRepository<OrderProduct> , IProductOrderRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductOrderRepository(ApplicationDbContext context): base(context) 
        {
            _context = context;
        }


        

    }
}
