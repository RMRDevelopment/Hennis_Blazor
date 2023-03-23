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
    public class HappeningsRepository : GenericRepository<Happenings,HappeningsDto>, IHappeningsRepository
    {
        public readonly IMapper _mapper;
        public HappeningsRepository(IMapper mapper) : base(mapper)
        {
            _mapper = mapper;
        }

      
        public async Task<IEnumerable<HappeningsDto>> GetEmployeeHappenings()
        {
            return _mapper.Map<IEnumerable<Happenings>, IEnumerable<HappeningsDto>>(_context.Happenings.Where(x => 
                        x.DisplayOption == (int)DisplayOptionEnum.EmployeeHappenings || 
                        x.DisplayOption == (int)DisplayOptionEnum.Both
                ));
        }

        public async Task<IEnumerable<HappeningsDto>> GetResidentHappenings()
        {
            return _mapper.Map<IEnumerable<Happenings>, IEnumerable<HappeningsDto>>(_context.Happenings.Where(x =>
                        x.DisplayOption == (int)DisplayOptionEnum.ResidentHappenings ||
                        x.DisplayOption == (int)DisplayOptionEnum.Both
                ));
        }

        public async Task<HappeningsDto> Update(HappeningsDto model)
        {
            var obj = await _context.Happenings.FirstOrDefaultAsync(x => x.Id == model.Id);
            if (obj != null)
            {
                obj.Content = model.Content;
                obj.Title = model.Title;
                obj.DisplayEndDate = model.DisplayEndDate;
                obj.DisplayStartDate = model.DisplayStartDate;
                obj.Date = model.Date;
                obj.DisplayOption = model.DisplayOption;
                //obj.LayoutZoneName = model.LayoutZoneName;
                
                _context.Happenings.Update(obj);
                await _context.SaveChangesAsync();
                return _mapper.Map<HappeningsDto>(obj);
            }
            return model;
        }
    }
}
