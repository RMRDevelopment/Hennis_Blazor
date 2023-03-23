using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hennis_DAL.DbEntities
{
    [Table("PageTile")]
    public class PageTile : BaseEntityModel
    {
        public int Id { get; set; }

        public int Order { get; set; }

        public string Title { get; set; }

        public int ImageId { get; set; }



        public string Content { get; set; }



        public bool Deleted { get; set; }

        public int PageId { get; set; }

        #region Virtual Properties
        [ForeignKey("ImageId")]
        //[NotMapped]
        public virtual BinaryFile Image { get; set; }
        #endregion
    }
}
