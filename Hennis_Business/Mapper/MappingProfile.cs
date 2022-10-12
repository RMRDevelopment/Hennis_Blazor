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
        }
    }
}
