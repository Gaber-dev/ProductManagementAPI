using BussinessLayer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Services.ProductServices
{
    public interface IProductService
    {
        Task AddProduct(AddProductDto dto);
        Task<IEnumerable<AddProductDto>> GetAllProducts();
        Task<AddProductDto> GetProductById(int id);
        Task UpdateProduct(AddProductDto dto);
        Task DeleteProduct(int id);
    }
}
