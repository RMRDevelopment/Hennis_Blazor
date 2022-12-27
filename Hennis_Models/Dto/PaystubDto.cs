using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hennis_Models.Dto
{
    public class PaystubDto : BaseModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }

        public int FileId { get; set; }

        public byte[] FileData { get; set; }

        public string FileName { get; set; }
    }
}
