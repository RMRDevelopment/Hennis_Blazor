﻿using AutoMapper;
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
    public class HtmlContentRepository : GenericRepository<HtmlContent,HtmlContentDto>, IHtmlContentRepository
    {
        public readonly IMapper _mapper;
        public HtmlContentRepository(IMapper mapper) : base(mapper)
        {
            _mapper = mapper;
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
                obj.Content = model.Content;
                obj.LayoutZoneName = model.LayoutZoneName;
                
                _context.HtmlContents.Update(obj);
                await _context.SaveChangesAsync();
                return _mapper.Map<HtmlContentDto>(obj);
            }
            return model;
        }
    }
}
