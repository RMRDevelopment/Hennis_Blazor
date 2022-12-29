using AutoMapper;
using Hennis_DAL.DbEntities;
using Hennis_Models.Dto;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hennis_Business.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Page, PageDto>().ReverseMap();
            CreateMap<Layout,LayoutDto>().ReverseMap();
            CreateMap<LayoutZone,LayoutZoneDto>().ReverseMap();
            CreateMap<HtmlContent, HtmlContentDto>().ReverseMap();
            CreateMap<Paystub, PaystubDto>()
                .ForMember(dest => dest.FileData, opt => opt.MapFrom(src => src.File.Bytes))
                .ReverseMap();
            CreateMap<HomePageTile, HomePageTileDto>()
                .ForMember(dest => dest.ImageData, opt => opt.MapFrom(src => src.Image.Bytes))
                .ForMember(dest => dest.FileName, opt => opt.MapFrom(src => src.Image.FileName));

            CreateMap<HomePageTileDto, HomePageTile>();
        }

    }
}
