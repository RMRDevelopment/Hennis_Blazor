using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hennis_DAL.DbEntities
{
    public class BaseEntityModel
    {
        public DateTime? CreatedDateTime { get; set; }
        public DateTime? ModifiedDateTime { get; set; }

        public string? CreatedBy { get; set; }
        public string? ModifiedBy { get; set; }
    }
}
