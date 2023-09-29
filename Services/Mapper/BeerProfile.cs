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
    public class BeerProfile : Profile
    {
        public BeerProfile()
        {
            CreateMap<BeerDto, Beer>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.Name}")
                )
                .ForMember(dest => dest.SourceId, opt => opt.MapFrom(src => $"{src.SourceId}")
                )
                .ForMember(dest => dest.Removed, opt => opt.MapFrom(src => src.Removed)
                )
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price)
                );

            CreateMap<Beer, BeerDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.Name}")
                )
                .ForMember(dest => dest.SourceId, opt => opt.MapFrom(src => $"{src.SourceId}")
                )
                .ForMember(dest => dest.Removed, opt => opt.MapFrom(src => src.Removed)
                )
                .ForMember(dest => dest.BrewerySourceId, opt => opt.MapFrom(src => src.Brewery.SourceId)
                )
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price)
                );
        }
    }
}
