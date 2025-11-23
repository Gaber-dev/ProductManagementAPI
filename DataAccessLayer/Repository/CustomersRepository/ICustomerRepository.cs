using DataAccessLayer.Entity.Customers;
using DataAccessLayer.Repository.GenericsRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository.CustomersRepository
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
    }
}
