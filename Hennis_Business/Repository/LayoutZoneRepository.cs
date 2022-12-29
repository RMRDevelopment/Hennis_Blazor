using AutoMapper;
using Hennis_Business.Repository.Interface;
using Hennis_DAL.Data;
using Hennis_DAL.DbEntities;
using Hennis_Models.Dto;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.Crmf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hennis_Business.Repository
{
    public class LayoutZoneRepository : GenericRepository<LayoutZone,LayoutZoneDto>, ILayoutZoneRepository
    {

        private readonly IMapper _mapper;
        public LayoutZoneRepository(IMapper mapper) : base(mapper)
        {
            _mapper = mapper;
        }

        public async Task<LayoutZoneDto> Get(string name)
        {
            var result = await _context.LayoutZones.Where(x => x.Name == name).FirstOrDefaultAsync();
            return _mapper.Map<LayoutZoneDto>(result);
        }

    }
}
