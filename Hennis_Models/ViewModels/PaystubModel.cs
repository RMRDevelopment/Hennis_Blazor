using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hennis_Models.ViewModels
{
    public class PaystubModel
    {
        public string Location { get; set; }

        public string Type { get; set; }
        public string FileName { get; set; }

        public byte[] Stream { get; set; }

        public DateTime PayDate { get; set; }

        public string UserId { get; set; }
    }
}
