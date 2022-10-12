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
    public class LayoutRepository : ILayoutRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public LayoutRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public Task<LayoutDto> Create(LayoutDto model)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<LayoutDto> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<LayoutDto> Get(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<LayoutDto>> GetAll()
        {
            return _mapper.Map<IEnumerable<Layout>, IEnumerable<LayoutDto>>(_context.Layouts);
        }


        public Task<LayoutDto> Update(LayoutDto model)
        {
            throw new NotImplementedException();
        }
    }
}
