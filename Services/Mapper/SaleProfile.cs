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
    public class SaleProfile : Profile
    {
        public SaleProfile()
        {
            CreateMap<SaleDto, Sale>()
                    .ForMember(dest => dest.SalesOrderNumber, opt => opt.MapFrom(src => $"{src.SalesOrderNumber}")
                    )
                    .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.Amount)
                    )
                    .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src => src.TotalPrice)
                    );


            CreateMap<Sale, SaleDto>()
                .ForMember(dest => dest.SalesOrderNumber, opt => opt.MapFrom(src => $"{src.SalesOrderNumber}")
                    )
                    .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.Amount)
                    )
                    .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src => src.TotalPrice)
                    );
        }
    }
}
