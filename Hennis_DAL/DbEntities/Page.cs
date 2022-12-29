using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Hennis_DAL.DbEntities
{
    [Table("Page")]
    public class Page : BaseEntityModel
    {
        public int Id { get; set; }

        public int LayoutId { get; set; }

        public int Order { get; set; }

        public string Name { get; set; }

        #region Virtual Properties
        [ForeignKey("LayoutId")]
        public virtual Layout Layout { get; set; }

        public virtual ICollection<HtmlContent> HtmlContents { get; set; }
        #endregion


    }
}
