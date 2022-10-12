using Hennis_Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hennis_Business.Repository.Interface
{
    public interface ILayoutRepository
    {
        public Task<LayoutDto> Create(LayoutDto model);
        public Task<LayoutDto> Update(LayoutDto model);
        public Task<int> Delete(int id);

        public Task<LayoutDto> Get(int id);
        public Task<LayoutDto> Get(string name);

        public Task<IEnumerable<LayoutDto>> GetAll();
    }

}
