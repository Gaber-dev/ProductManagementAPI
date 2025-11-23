using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Dtos
{
    public class UpdateOrderDto
    {
        public int OrderID { get; set; }
        public int NumberOfItems { get; set; }
    }
}
