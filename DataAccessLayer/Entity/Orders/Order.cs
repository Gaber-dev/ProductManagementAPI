using DataAccessLayer.Entity.Customers;
using DataAccessLayer.Entity.OrderProducts;
using DataAccessLayer.Entity.OrderProducts;
using DataAccessLayer.Entity.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entity.Orders
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public double TotalAmount { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public ICollection<OrderProduct> ProductsOrder { get; set; } = new HashSet<OrderProduct>();


    }
}
