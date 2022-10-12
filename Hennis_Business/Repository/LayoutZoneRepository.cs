using Hennis_Business.Repository.Interface;
using Hennis_Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hennis_Business.Repository
{
    public class LayoutZoneRepository : ILayoutZoneRepository
    {
        public Task<LayoutZoneDto> Create(LayoutZoneDto model)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<LayoutZoneDto> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<LayoutZoneDto> Get(string name)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<LayoutZoneDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<LayoutZoneDto> Update(LayoutZoneDto model)
        {
            throw new NotImplementedException();
        }
    }
}
