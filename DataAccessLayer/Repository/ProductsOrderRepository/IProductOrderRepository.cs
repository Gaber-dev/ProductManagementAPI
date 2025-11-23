using DataAccessLayer.Entity.OrderProducts;
using DataAccessLayer.Repository.GenericsRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository.ProductsOrderRepository
{
    public interface IProductOrderRepository : IGenericRepository<OrderProduct>
    {

    }
}
