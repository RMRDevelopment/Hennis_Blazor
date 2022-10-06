using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hennis_DAL.DbEntities
{
    [Table("HtmlContent")]
    public class HtmlContent
    {
        public int Id { get; set; }

        public int PageId { get; set; }

        public string LayoutZoneName { get; set; }

        public string Content { get; set; }

        #region Virtual Properties
        [ForeignKey("PageId")]
        public virtual Page Page { get; set; }
        #endregion
    }
}
