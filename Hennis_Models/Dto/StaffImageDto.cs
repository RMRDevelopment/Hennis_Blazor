using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hennis_Models.Dto
{
    public class StaffImageDto : BaseModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Title { get; set; }

        public string Location { get; set; }

        public int ImageId { get; set; }


        public bool Deleted { get; set; }

        public int PageId { get; set; }
        public byte[] ImageData { get; set; }

        public string FileName { get; set; }

        public string Bio { get; set; }

        public string PageName { get; set; }

    }
}
