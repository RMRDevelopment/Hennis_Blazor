using Hennis_Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hennis_Business.Repository.Interface
{
    public interface IPageRepository
    {
        public Task<PageDto> Create(PageDto model);
        public Task<PageDto> Update(PageDto model);
        public Task<int> Delete(int id);

        public Task<PageDto> Get(int id);
        public Task<PageDto> Get(string name);

        public Task<IEnumerable<PageDto>> GetAll();
    }

}
