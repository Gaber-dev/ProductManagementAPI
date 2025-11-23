using BussinessLayer.Dtos;
using DataAccessLayer.Entity.Customers;
using DataAccessLayer.Repository.CustomersRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Services.CustomerServices
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repo;

        public CustomerService(ICustomerRepository repo)
        {
            _repo = repo;
        }


        public async Task AddCustomer(AddCustomerDto dto)
        {
            if (dto.Name == null)
                throw new Exception("Please Enter Name");

            if(dto.PhoneNumber == null)
                throw new Exception("Please Enter PhoneNumber");

            var CustomerToDb = new Customer
            {
              Name = dto.Name,
              PhoneNumber = dto.PhoneNumber
            };
           await _repo.AddEntity(CustomerToDb);
        }

    }
}
