using BussinessLayer.Dtos;
using BussinessLayer.Services.ProductServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProductManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }


        [HttpPost]
        public async Task<IActionResult> AddProduct(AddProductDto dto)
        {
            await _service.AddProduct(dto);
            return Ok("Product Added Successfully");
        }


        [HttpGet]
        public async Task<IEnumerable<AddProductDto>> GetAllProducts()
        {
            var productToUser = await _service.GetAllProducts();
            return productToUser;
        }


        [HttpGet("/id")]
        public async Task<AddProductDto> GetProductById(int id)
        {
            var productToUser = await _service.GetProductById(id);
            return productToUser;
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(AddProductDto dto)
        {
            await _service.UpdateProduct(dto);
            return Ok("Product updated successfully");
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _service.DeleteProduct(id);
            return Ok("Product deleted successfully.");
        }



    }
}
