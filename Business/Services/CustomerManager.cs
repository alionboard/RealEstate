using Business.Repositories;
using Data.Context;
using Data.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Services
{
    public class CustomerManager : BaseRepository<Customer>, ICustomerRepository
    {
        private readonly RealEstateDbContext _context;
        public CustomerManager(RealEstateDbContext context) : base(context)
        {
            _context = context;
        }

        public Customer GetById(int id)
        {
            var customers = _context.Customers.Include(customer => customer.CustomerTypes);
            return customers.FirstOrDefault(x=>x.Id == id);
        }
    }
}
