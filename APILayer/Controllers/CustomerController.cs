using BussinessLayer.Dtos;
using BussinessLayer.Services.CustomerServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProductManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _service;

        public CustomerController(ICustomerService service)
        {
            _service = service;
        }


        [HttpPost]
        public async Task<IActionResult> AddCustomer(AddCustomerDto dto)
        {
            await _service.AddCustomer(dto);
            return Ok("Customer Added successfully.");
        }
    }
}
