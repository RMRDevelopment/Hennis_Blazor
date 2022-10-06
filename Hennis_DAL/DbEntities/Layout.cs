using System.ComponentModel.DataAnnotations.Schema;

namespace Hennis_DAL.DbEntities
{
    [Table("Layout")]
    public class Layout
    {
        public int Id { get; set; }

        public string Name { get; set; }

        #region Virtual Properties
        public virtual ICollection<LayoutZone> LayoutZones { get; set; }

        #endregion
    }
}