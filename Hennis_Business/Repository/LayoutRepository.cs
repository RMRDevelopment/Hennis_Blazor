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
    public class LayoutRepository : GenericRepository<Layout,LayoutDto>, ILayoutRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public LayoutRepository(IMapper mapper) : base(mapper)
        {
            _mapper = mapper;
        }


        public async Task<LayoutDto> Get(string name)
        {
            var result = await _context.Layouts.Where(x => x.Name == name).FirstOrDefaultAsync();
            return _mapper.Map<LayoutDto>(result);
        }

    }
}
