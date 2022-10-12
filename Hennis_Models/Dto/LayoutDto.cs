using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hennis_Models.Dto
{
    public class LayoutDto
    {
        public int Id { get; set; }

        public string Name { get; set; }


        public ICollection<LayoutZoneDto> LayoutZones { get; set; }
    }
}
