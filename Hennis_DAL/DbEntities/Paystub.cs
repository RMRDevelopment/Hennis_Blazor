using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hennis_DAL.DbEntities
{
    public class Paystub : BaseEntityModel
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public DateTime PayDate { get; set; }

        public int FileId { get; set; }

        [ForeignKey("FileId")]
        public virtual BinaryFile File { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }
    }
}
