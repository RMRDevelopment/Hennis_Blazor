
using AutoMapper;
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

namespace Hennis_Business.Repository
{
    public class PageRepository : IPageRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public PageRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<PageDto> Create(PageDto model)
        {
            var obj = _mapper.Map<Page>(model);
            _context.Page.Add(obj);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                ErrorLogHelper.LogError(_context, ex, "Page Create");
                model.IsError = true;
                model.ErrorMessage = "An error occurred saving";
                return model;
            }


            var pageDto = _mapper.Map<PageDto>(obj);
            return pageDto;
        }

        public async Task<int> Delete(int id)
        {
            var obj = _context.Page.FirstOrDefault(x => x.Id == id);

            if (obj != null)
            {
                _context.Page.Remove(obj);
                return await _context.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<PageDto> Get(int id)
        {
            var obj = await _context.Page.Include(x => x.Layout).Include(x => x.Layout.LayoutZones).Include(x => x.HtmlContents).FirstOrDefaultAsync(x => x.Id == id);
            if (obj != null)
            {
                return _mapper.Map<PageDto>(obj);
            }

            return new PageDto();
        }

        public async Task<PageDto> Get(string name)
        {
            var obj = await _context.Page.Include(x => x.Layout).FirstOrDefaultAsync(x => x.Name == name);
            if (obj != null)
            {
                return _mapper.Map<PageDto>(obj);
            }

            return new PageDto();
        }

        public async Task<IEnumerable<PageDto>> GetAll()
        {
            return _mapper.Map<IEnumerable<Page>, IEnumerable<PageDto>>(_context.Page.Include(x => x.Layout));
        }

        public async Task<PageDto> Update(PageDto model)
        {
            var obj = await _context.Page.FirstOrDefaultAsync(x => x.Id == model.Id);
            if (obj != null)
            {
                obj.Name = model.Name;
                obj.LayoutId = model.LayoutId;
                _context.Page.Update(obj);
                await _context.SaveChangesAsync();
                return _mapper.Map<PageDto>(obj);
            }
            return model;
        }
    }
}
