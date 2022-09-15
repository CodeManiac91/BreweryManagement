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
    public class WholeSalerProfile : Profile
    {
        public WholeSalerProfile()
        {
            CreateMap<WholeSalerDto, WholeSaler>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.Name}")
                )
                .ForMember(dest => dest.SourceId, opt => opt.MapFrom(src => $"{src.SourceId}")
                )
                .ForMember(dest => dest.Removed, opt => opt.MapFrom(src => src.Removed)
                );

            CreateMap<WholeSaler, WholeSalerDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.Name}")
                )
                .ForMember(dest => dest.SourceId, opt => opt.MapFrom(src => $"{src.SourceId}")
                )
                .ForMember(dest => dest.Removed, opt => opt.MapFrom(src => src.Removed)
                );
        }
    }
}
