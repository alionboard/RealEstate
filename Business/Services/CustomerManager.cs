using Business.Repositories;
using Data.Context;
using Data.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services
{
    public class CustomerManager : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerManager(ApplicationDbContext context) : base(context)
        {

        }
    }
}
