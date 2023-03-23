using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Hennis_Models.Dto
{
    public class HappeningsDto : BaseModel
    {
        public int Id { get; set; }


        public string Title { get; set; }
     
        public string Content { get; set; }

        public DateTime? Date { get; set; }

        public DateTime DisplayStartDate { get; set; }

        public DateTime? DisplayEndDate { get; set; }

        public int DisplayOption { get; set; }

        public bool Deleted { get; set; }

        public string DisplayTitle
        {
            get
            {
                string title = Title;

                if (Date.HasValue)
                {
                    title = $"{Date.Value.ToShortDateString()} - {title}";
                }

                return title;
            }
        }

    }
}
