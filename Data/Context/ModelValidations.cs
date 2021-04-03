using Data.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Context
{
    public static class ModelValidations
    {
        public static void ValidateModels(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(e => {
                e.Property(c => c.Email).HasMaxLength(75);
                e.Property(c =>c.Fullname).HasMaxLength(75).IsRequired();
                e.Property(c =>c.MobileNumber).HasMaxLength(15).IsRequired();
                e.Property(c =>c.HousePhoneNumber).HasMaxLength(15).IsRequired();
            });
            modelBuilder.Entity<Estate>(e => {
                e.Property(es=>es.CustomerId).IsRequired();
                e.Property(es=>es.DistrictId).IsRequired();
                e.Property(es=>es.HeatingTypeId).IsRequired();
                e.Property(es=>es.EstateTypeId).IsRequired();
                e.Property(es=>es.Address).HasMaxLength(200).IsRequired();
                e.Property(es=>es.Floor).HasMaxLength(3).IsRequired();
                e.Property(es=>es.NumberOfRooms).HasMaxLength(4).IsRequired();
                e.Property(es=>es.SquareMeter).HasMaxLength(6).IsRequired();
                e.Property(es=>es.TotalNumberOfBuildingFloors).HasMaxLength(3).IsRequired();
            });
        }
    }
}
