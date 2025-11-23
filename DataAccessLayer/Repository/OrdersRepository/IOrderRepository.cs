using DataAccessLayer.Entity.Orders;
using DataAccessLayer.Repository.GenericsRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository.OrdersRepository
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task<IEnumerable<Order>> GetAllOrdersWithProduct();
        Task<Order?> GetOneOrderwithProduct(int id);
    }
}
