using Hennis_Business.Repository.Interface;
using Hennis_Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hennis_Business.Repository
{
    public class HtmlContentRepository : IHtmlContentRepository
    {
        public Task<HtmlContentDto> Create(HtmlContentDto model)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<HtmlContentDto> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<HtmlContentDto> Get(string name)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<HtmlContentDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<HtmlContentDto> Update(HtmlContentDto model)
        {
            throw new NotImplementedException();
        }
    }
}
