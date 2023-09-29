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
    public class StockProfile : Profile
    {
        public StockProfile()
        {
            CreateMap<StockDto, Stock>().ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.Amount));

            CreateMap<Stock, StockDto>().ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.Amount));
        }
    }
}
