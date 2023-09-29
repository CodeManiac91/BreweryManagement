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
                )
                .ForMember(dest => dest.IndentificationNumber, opt => opt.MapFrom(src => $"{src.IdentificationNumber}")
                )
                .ForMember(dest => dest.Removed, opt => opt.MapFrom(src => src.Removed)
                );

            CreateMap<Brewer, BrewerDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.Name}")
                )
                .ForMember(dest => dest.IdentificationNumber, opt => opt.MapFrom(src => $"{src.IndentificationNumber}")
                )
                .ForMember(dest => dest.Removed, opt => opt.MapFrom(src => src.Removed)
                );
        }
    }
}
