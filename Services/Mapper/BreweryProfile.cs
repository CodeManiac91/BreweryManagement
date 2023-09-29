﻿using AutoMapper;
using DataAccess;
using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Mapper
{
    public class BreweryProfile : Profile
    {
        public BreweryProfile()
        {
            CreateMap<BreweryDto, Brewery>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.Name}")
                )
                .ForMember(dest => dest.SourceId,opt => opt.MapFrom(src => $"{src.SourceId}")
                )
                .ForMember(dest => dest.Removed, opt => opt.MapFrom(src => src.Removed)
                );

            CreateMap<Brewery, BreweryDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.Name}")
                )
                .ForMember(dest => dest.SourceId, opt => opt.MapFrom(src => $"{src.SourceId}")
                )
                .ForMember(dest => dest.Removed, opt => opt.MapFrom(src => src.Removed)
                ); 
        }
    }
}
