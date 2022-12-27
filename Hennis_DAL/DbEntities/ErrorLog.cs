using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hennis_DAL.DbEntities
{
    [Table("ErrorLog")]
    public class ErrorLog
    {
        public int Id { get; set; }

        public string Title { get; set; } = ""; 

        public DateTime LogDate { get; set; } = DateTime.Now;

        public string Message { get; set; } = "";

        public string StackTrace { get; set; } = "";
    }
}
