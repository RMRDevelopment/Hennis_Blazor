using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hennis_DAL.DbEntities
{
    [Table("StaffImage")]
    public class StaffImage : BaseEntityModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Title { get; set; }

        public string Location { get; set; }

        public int ImageId { get; set; }

        public bool Deleted { get; set; }

        public int PageId { get; set; }

        public string Bio { get; set; }

        #region Virtual Properties
        [ForeignKey("ImageId")]
        //[NotMapped]
        public virtual BinaryFile Image { get; set; }

        public virtual Page Page { get; set; }
        #endregion
    }
}
