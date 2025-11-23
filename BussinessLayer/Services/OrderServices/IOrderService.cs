using BussinessLayer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Services.OrderServices
{
    public interface IOrderService
    {
        Task AddOrder(AddOrderDto dto, int CustomerId);
        Task<IEnumerable<GetAllOrdersDto>> GetAllOrders();
        Task<GetAllOrdersDto> GetOneOrderById(int id);
        Task UpdateOrder(UpdateOrderDto dto);
        Task DeleteOrder(int orderId);
    }
}
