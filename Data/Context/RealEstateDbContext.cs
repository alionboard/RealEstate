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
        public virtual DbSet<CustomerType> CustomerTypes { get; set; }
        public virtual DbSet<District> Districts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerTypeCustomer>(e =>
            {
                e.HasKey(ctc => new { ctc.CustomerId, ctc.CustomerTypeId });
            });


            modelBuilder.Entity<CustomerType>().HasData(
                new CustomerType { Id = 1, Type = "Satıcı" },
                new CustomerType { Id = 2, Type = "Alıcı" },
                new CustomerType { Id = 3, Type = "Kiraya Veren" },
                new CustomerType { Id = 4, Type = "Kiracı" }
            );

            modelBuilder.Entity<EstateType>().HasData(
                new EstateType { Id=1,Type="Satılık"},
                new EstateType { Id=2,Type="Kiralık"}
                );

            modelBuilder.Entity<HeatingType>().HasData(
                new HeatingType { Id=1,Type="Yok"},
                new HeatingType { Id=2,Type="Doğalgaz"},
                new HeatingType { Id=3,Type="Merkezi Isıtma"},
                new HeatingType { Id=4,Type="Güneş Enerjisi"},
                new HeatingType { Id=5,Type="Soba"}
            );

            modelBuilder.SeedCityDistrict();
        }
    }
}
