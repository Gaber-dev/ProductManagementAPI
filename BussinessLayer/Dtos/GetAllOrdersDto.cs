using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Dtos
{
    public class GetAllOrdersDto
    {
        public int OrderId { get; set;}
        public string CustomerName { get; set;}
        public string CustomerPhone { get; set;}
        public double TotalAmount { get; set;}
        public List<ProductInOrderDto> Products { get; set; }

    }
}
