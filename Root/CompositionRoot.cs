using Business.Repositories;
using Business.Services;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Root
{
    public class CompositionRoot
    {
        public CompositionRoot()
        {

        }

        public static void InjectDependencies(IServiceCollection services)
        {
            services.AddScoped<RealEstateDbContext>();
            services.AddScoped(typeof(ITypesRepository<>), typeof(TypeBaseRepository<>));
            services.AddScoped<IEstateRepository, EstateManager>();
            services.AddScoped<ICustomerRepository, CustomerManager>();
            services.AddScoped<IWorkPlaceRepository, WorkplaceManager>();
            services.AddDbContext<RealEstateDbContext>(options => options.UseSqlServer("server=(localdb)\\mssqllocaldb;database=RealEstateDb;Integrated Security=true;", x => x.MigrationsAssembly("Data")));
        }
    }
}
