using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hennis_Models.Dto
{
    public class HtmlContentDto : BaseModel
    {
        public int Id { get; set; }

        public int PageId { get; set; }

        public string LayoutZoneName { get; set; }

        public string Content { get; set; }
    }
}
