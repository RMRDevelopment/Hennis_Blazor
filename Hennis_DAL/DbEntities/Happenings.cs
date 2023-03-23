using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hennis_DAL.DbEntities
{
    [Table("Happenings")]
    public class Happenings : BaseEntityModel
    {
       
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }

        public DateTime? Date { get; set; }

        [Required(ErrorMessage = "Display Start Date is required")]
        [Display(Name = "Display Start Date")]
        public DateTime DisplayStartDate { get; set; }

        [Display(Name = "Display End Date")]
        public DateTime? DisplayEndDate { get; set; }

        public int DisplayOption { get; set; }

        public bool Deleted { get; set; }

        [NotMapped]
        public string DisplayTitle {
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

    public enum DisplayOptionEnum
    {
        
        ResidentHappenings = 1,
        EmployeeHappenings = 2,
        Both = 3
    }
}
