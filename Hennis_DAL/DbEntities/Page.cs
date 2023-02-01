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

        public string? Name { get; set; }

        public string? Title { get; set; }

        public int? ImageId { get; set; }

        public int? ParentPageId { get; set; }

        #region Virtual Properties
        [ForeignKey("LayoutId")]
        public virtual Layout? Layout { get; set; }

        public virtual ICollection<HtmlContent> HtmlContents { get; set; } = new List<HtmlContent>();

        [ForeignKey("ImageId")]
        public virtual BinaryFile? Image { get; set; }

        [ForeignKey("ParentPageId")]
        public virtual Page? ParentPage { get; set; }
        #endregion


    }
}
