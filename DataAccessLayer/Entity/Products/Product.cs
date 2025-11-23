using DataAccessLayer.Entity.OrderProducts;
using DataAccessLayer.Entity.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entity.Products
{
    public class Product
    {
       public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Stock {  get; set; }
        public ICollection<OrderProduct> ProductsOrder { get; set; } = new HashSet<OrderProduct>();

    }
}
