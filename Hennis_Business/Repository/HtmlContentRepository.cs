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
    public class HtmlContentRepository : IHtmlContentRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public HtmlContentRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<HtmlContentDto> Create(HtmlContentDto model)
        {

            var obj = _mapper.Map<HtmlContent>(model);
            _context.HtmlContents.Add(obj);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                ErrorLogHelper.LogError(_context, ex, "Html Content Create");
                model.IsError = true;
                model.ErrorMessage = "An error occurred saving";
                return model;
            }


            var htmlContentDto = _mapper.Map<HtmlContentDto>(obj);
            return htmlContentDto;
        }

        public async Task<int> Delete(int id)
        {
            var obj = _context.HtmlContents.FirstOrDefault(x => x.Id == id);

            if (obj != null)
            {
                _context.HtmlContents.Remove(obj);
                return await _context.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<HtmlContentDto> Get(int id)
        {
            var obj = await _context.HtmlContents.FirstOrDefaultAsync(x => x.Id == id);
            if (obj != null)
            {
                return _mapper.Map<HtmlContentDto>(obj);
            }

            return new HtmlContentDto();
        }


        public async Task<IEnumerable<HtmlContentDto>> GetAll()
        {
            return _mapper.Map<IEnumerable<HtmlContent>, IEnumerable<HtmlContentDto>>(_context.HtmlContents);
        }

        public async Task<IEnumerable<HtmlContentDto>> GetByPageId(int pageId)
        {
            return _mapper.Map<IEnumerable<HtmlContent>, IEnumerable<HtmlContentDto>>(_context.HtmlContents.Where(x => x.PageId == pageId));
        }

        public async Task<HtmlContentDto> Update(HtmlContentDto model)
        {
            var obj = await _context.HtmlContents.FirstOrDefaultAsync(x => x.Id == model.Id);
            if (obj != null)
            {
                obj.PageId = model.PageId;
                obj.LayoutZoneName = model.LayoutZoneName;
                obj.Content = model.Content;
                _context.HtmlContents.Update(obj);
                await _context.SaveChangesAsync();
                return _mapper.Map<HtmlContentDto>(obj);
            }
            return model;
        }
    }
}
