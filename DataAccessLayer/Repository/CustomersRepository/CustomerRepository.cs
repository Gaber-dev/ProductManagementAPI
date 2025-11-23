using DataAccessLayer.Data;
using DataAccessLayer.Entity.Customers;
using DataAccessLayer.Repository.GenericsRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository.CustomersRepository
{
    public class CustomerRepository : GenericRepository<Customer> , ICustomerRepository
    {
        private readonly ApplicationDbContext _context;

        public CustomerRepository(ApplicationDbContext context) : base(context) 
        {
           _context = context;
        }
    }
}
