
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Hennis_Business.Helper;
using Hennis_Business.Repository.Interface;
using Hennis_DAL.Data;
using Hennis_DAL.DbEntities;
using Hennis_Models.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Hennis_Business.Repository
{
    public class PageRepository : GenericRepository<Page, PageDto>, IPageRepository
    {

        private readonly IMapper _mapper;

        public PageRepository( IMapper mapper) : base(mapper)
        {

            _mapper = mapper;
        }
       


        public async Task<PageDto> Get(string name)
        {
            var obj = await _context.Page.Include(x => x.Layout).Include(x => x.Image).Include(x => x.HtmlContents).FirstOrDefaultAsync(x => x.Name == name);
            if (obj != null)
            {
                return _mapper.Map<PageDto>(obj);
            }

            return new PageDto();
        }

        public async Task<int?> GetImageId(int id)
        {
            return await _context.Page.Where(x => x.Id == id).Select(x => x.ImageId).FirstOrDefaultAsync();
        }

        public IEnumerable<PageDto> GetAllWithImagesAsync(bool removeDeleted = false)
        {
            var list = _context.Page.Include(x => x.Image).Include(x=>x.ParentPage).ProjectTo<PageDto>(_mapper.ConfigurationProvider).ToList();
            //if (removeDeleted)
            //{
            //    return list.Where(x => x.Deleted == false).ToList();
            //}
            return list;
        }

        public async Task<PageDto> Update(PageDto model)
        {
            var obj = await _context.Page.FirstOrDefaultAsync(x => x.Id == model.Id);
            if (obj != null)
            {
                obj.Name = model.Name;
                obj.LayoutId = model.LayoutId;
                obj.Title = model.Title;
                obj.ImageId = model.ImageId.HasValue ? model.ImageId.Value : obj.ImageId;
                obj.ParentPageId = model.ParentPageId.HasValue ? model.ParentPageId.Value : obj.ParentPageId;
                _context.Page.Update(obj);
                await _context.SaveChangesAsync();
                return _mapper.Map<PageDto>(obj);
            }
            return model;
        }

        public async Task<PageDto> GetWithZones(int id)
        {
            return await _context.Page.Include(x => x.Layout).Include(x => x.HtmlContents)
                .Where(x => x.Id == id)
                .ProjectTo<PageDto>(_mapper.ConfigurationProvider).FirstOrDefaultAsync();
            
        }

        public async Task<PageDto> Get(int id)
        {
            var obj = await _context.Page.Include(x => x.Layout).Include(x => x.Image).Include(x => x.HtmlContents).FirstOrDefaultAsync(x => x.Id == id);
            if (obj != null)
            {
                return _mapper.Map<PageDto>(obj);
            }

            return new PageDto();
        }
    }
}
