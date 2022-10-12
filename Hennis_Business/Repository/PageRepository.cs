
using AutoMapper;
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
        public Task<PageDto> Create(PageDto model)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PageDto> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PageDto> Get(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PageDto>> GetAll()
        {
            return _mapper.Map<IEnumerable<Page>, IEnumerable<PageDto>>(_context.Page.Include(x => x.Layout));
        }

        public Task<PageDto> Update(PageDto model)
        {
            throw new NotImplementedException();
        }
    }
}
