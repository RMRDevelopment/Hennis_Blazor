using Hennis_DAL.DbEntities;
using Hennis_Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hennis_Business.Repository.Interface
{
    public interface IHtmlContentRepository : IGenericRepository<HtmlContent,HtmlContentDto>
    {
        public Task<IEnumerable<HtmlContentDto>> GetByPageId(int pageId);
    }

}
