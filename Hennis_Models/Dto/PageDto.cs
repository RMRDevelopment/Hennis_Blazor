using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hennis_Models.Dto
{
    public class PageDto
    {
        public int Id { get; set; }

        public int LayoutId { get; set; }

        public int Order { get; set; }

        public string Name { get; set; }

        public LayoutDto Layout { get; set; }
    }
}
