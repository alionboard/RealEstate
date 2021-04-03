using AutoMapper;
using Data.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CustomerViewModel, Customer>();
            CreateMap<Customer, CustomerViewModel>();
            CreateMap<AddCustomerDto, Customer>()
                .ForMember(dest => dest.CustomerTypes, opt => opt.Ignore());
        }
    }
}
