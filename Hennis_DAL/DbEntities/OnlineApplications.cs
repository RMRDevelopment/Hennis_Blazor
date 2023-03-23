using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hennis_DAL.DbEntities
{
    [Table("OnlineApplications")]
    public class OnlineApplication : BaseEntityModel
    {
        public int Id { get; set; }
        public string Json { get; set; }


    }
}
