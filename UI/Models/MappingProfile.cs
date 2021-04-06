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
            CreateMap<EditCustomerDto, Customer>();
            CreateMap<Customer, EditCustomerDto>();
            CreateMap<AddCustomerDto, Customer>()
                .ForMember(dest => dest.CustomerTypes, opt => opt.Ignore());
            CreateMap<AddEstateDto, Estate>();
            CreateMap<Estate, AddEstateDto>();
        }
    }
}
