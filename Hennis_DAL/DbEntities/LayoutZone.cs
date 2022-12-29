using System.ComponentModel.DataAnnotations.Schema;

namespace Hennis_DAL.DbEntities
{
    [Table("LayoutZone")]
    public class LayoutZone : BaseEntityModel
    {
        public int Id { get; set; }

        public int LayoutId { get; set; }

        public string Name { get; set; }

        #region Virtual Properties
        [ForeignKey("LayoutId")]
        public virtual Layout Layout { get; set; }
        #endregion
    }
}