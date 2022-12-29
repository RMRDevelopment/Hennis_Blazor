
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
    public class PageRepository : GenericRepository<Page, PageDto>, IPageRepository
    {

        private readonly IMapper _mapper;

        public PageRepository( IMapper mapper) : base(mapper)
        {

            _mapper = mapper;
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

    }
}
