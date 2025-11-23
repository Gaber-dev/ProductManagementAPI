using BussinessLayer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Services.CustomerServices
{
    public interface ICustomerService
    {
        Task AddCustomer(AddCustomerDto dto);
    }
}
