using AutoMapper;
using Hennis_DAL.DbEntities;
using Hennis_Models.Dto;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Org.BouncyCastle.Asn1;
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
            CreateMap<Page,PageDto>()
                .ForMember(dest => dest.ImageData, opt => opt.MapFrom(src => src.Image.Bytes))
                .ForMember(dest => dest.FileName, opt => opt.MapFrom(src => src.Image.FileName))
                .ForMember(dest => dest.ParentPageName, opt => opt.MapFrom(src => src.ParentPage.Name));
                

            CreateMap<PageDto, Page>()
                .ForAllMembers(
                    opt => opt.Condition((src, dest, sourceMember) => sourceMember != null));
            ;

            CreateMap<Layout,LayoutDto>().ReverseMap();
            CreateMap<LayoutZone,LayoutZoneDto>().ReverseMap();
            CreateMap<HtmlContent, HtmlContentDto>().ReverseMap();
            CreateMap<Paystub, PaystubDto>()
                .ForMember(dest => dest.FileData, opt => opt.MapFrom(src => src.File.Bytes))
                .ForMember(dest => dest.BinaryFileGuid, opt => opt.MapFrom(src => src.File.Guid))
                .ForMember(dest => dest.PaystubDate, opt => opt.MapFrom(src => src.PayDate))
                .ForMember(dest => dest.FileName, opt => opt.MapFrom(src => src.File.FileName))
                .ReverseMap();
            CreateMap<HomePageTile, HomePageTileDto>()
                .ForMember(dest => dest.ImageData, opt => opt.MapFrom(src => src.Image.Bytes))
                .ForMember(dest => dest.FileName, opt => opt.MapFrom(src => src.Image.FileName));

            CreateMap<StaffImage, StaffImageDto>()
                .ForMember(dest => dest.ImageData, opt => opt.MapFrom(src => src.Image.Bytes))
                .ForMember(dest => dest.FileName, opt => opt.MapFrom(src => src.Image.FileName))
                .ForMember(dest => dest.PageName, opt => opt.MapFrom(src => src.Page.Name));

            CreateMap<HomePageTileDto, HomePageTile>()
                .ForAllMembers(
                    opt => opt.Condition((src, dest, sourceMember) => sourceMember != null));
            ;

            CreateMap<StaffImageDto, StaffImage>()
                .ForAllMembers(
                    opt => opt.Condition((src, dest, SourceMember) => SourceMember != null));
            ;
        }

    }
}
