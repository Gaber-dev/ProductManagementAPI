using BussinessLayer.Dtos;
using BussinessLayer.Services.OrderServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProductManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _service;

        public OrderController(IOrderService service)
        {
            _service = service;
        }


        [HttpPost]
        public async Task<IActionResult> AddOrder(AddOrderDto dto , int customerId)
        {
            await  _service.AddOrder(dto, customerId);
            return Ok("Order Created successfully");
        }


        [HttpGet]
        public async Task<IEnumerable<GetAllOrdersDto>> GetAllOrders()
        {
            var res = await _service.GetAllOrders();
            return res;

        }

        [HttpGet("{id}")]
        public async Task<GetAllOrdersDto> GetOneOrder(int id)
        {
            var res = await _service.GetOneOrderById(id);
            return res;
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrder(UpdateOrderDto dto)
        {
            await _service.UpdateOrder(dto);
            return Ok("Order updated successfully");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteOrder(int orderId)
        {
            await _service.DeleteOrder(orderId);
            return Ok("Order deleted successfully");
        }


    }
}
