using Hennis_DAL.DbEntities;
using Hennis_Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hennis_Business.Repository.Interface
{
    public interface IPageRepository : IGenericRepository<Page, PageDto>
    {
        
        public Task<PageDto> Get(string name);

    }

}
