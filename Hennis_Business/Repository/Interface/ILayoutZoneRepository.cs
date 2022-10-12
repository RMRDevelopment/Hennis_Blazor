using Hennis_Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hennis_Business.Repository.Interface
{
    public interface ILayoutZoneRepository
    {
        public Task<LayoutZoneDto> Create(LayoutZoneDto model);
        public Task<LayoutZoneDto> Update(LayoutZoneDto model);
        public Task<int> Delete(int id);

        public Task<LayoutZoneDto> Get(int id);
        public Task<LayoutZoneDto> Get(string name);

        public Task<IEnumerable<LayoutZoneDto>> GetAll();
    }

}
