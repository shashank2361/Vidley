using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Vidley.Dtos;
using Vidley.Models;

namespace Vidley.App_Start
{
    public class MappingProfile : Profile   
    {
      
        public MappingProfile()
        {
            //Domain TO DTO
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>();
            Mapper.CreateMap<Movie, MovieDto >();
            Mapper.CreateMap<MovieDto, Movie>();
            //Dto to Domain
            //CreateMap<Customer, CustomerDto>().ForMember(c => c.Id, opt => opt.Ignore());

            //CreateMap<Movie, MovieDto>() .ForMember(m => m.Id, opt => opt.Ignore());
         

        }
    }
}