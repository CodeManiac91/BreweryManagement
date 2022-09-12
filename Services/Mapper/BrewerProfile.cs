using AutoMapper;
using DataAccess;
using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Mapper
{
    public class BrewerProfile : Profile
    {
        public BrewerProfile() {
            CreateMap<BrewerDto, Brewer>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.Name}")
                );

            CreateMap<Brewer, BrewerDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.Name}")
                );
        }
    }
}
