using Hennis_DAL.DbEntities;
using Hennis_Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hennis_Business.Repository.Interface
{
    public interface IHappeningsRepository : IGenericRepository<Happenings,HappeningsDto>
    {
        public Task<IEnumerable<HappeningsDto>> GetResidentHappenings();

        public Task<IEnumerable<HappeningsDto>> GetEmployeeHappenings();


        public Task<HappeningsDto> Update(HappeningsDto model);
    }

}
