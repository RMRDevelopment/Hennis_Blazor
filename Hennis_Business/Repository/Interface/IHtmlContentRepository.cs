using Hennis_Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hennis_Business.Repository.Interface
{
    public interface IHtmlContentRepository
    {
        public Task<HtmlContentDto> Create(HtmlContentDto model);
        public Task<HtmlContentDto> Update(HtmlContentDto model);
        public Task<int> Delete(int id);

        public Task<HtmlContentDto> Get(int id);
        public Task<HtmlContentDto> Get(string name);

        public Task<IEnumerable<HtmlContentDto>> GetAll();
    }

}
