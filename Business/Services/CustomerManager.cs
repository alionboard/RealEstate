using Business.Repositories;
using Data.Context;
using Data.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Services
{
    public class CustomerManager : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerManager(RealEstateDbContext context) : base(context)
        {

        }



    }
}
