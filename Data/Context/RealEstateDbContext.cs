using Data.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Context
{
    public class RealEstateDbContext : DbContext
    {
        public RealEstateDbContext(DbContextOptions<RealEstateDbContext> options) : base(options)
        {

        }

        public virtual DbSet<Estate> Estates { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Workplace> Workplaces { get; set; }
    }
}
