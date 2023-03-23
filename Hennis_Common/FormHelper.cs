using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hennis_Common
{
    public static class FormHelper
    {
        public static List<DropdownModel> GetYesNoOptions
        {
            get
            {
                return new List<DropdownModel>
                {
                    new DropdownModel { Text = "Yes", Value = "Yes" },
                    new DropdownModel { Text = "No", Value = "No" }
                };
            }
        }

        public static List<DropdownModel> GetOver18Options
        {
            get
            {
                return new List<DropdownModel> {
                    new DropdownModel { Text = "Yes", Value = "Yes" },
                    new DropdownModel { Text = "No", Value = "No" },
                    new DropdownModel {Text= "I'm over 18", Value="Over18" }
                };
            }
        }

        public static List<DropdownModel> GetLocations
        {
            get
            {
                return new List<DropdownModel> {
                    new DropdownModel { Text = "Bolivar", Value = "Bolivar" },
                    new DropdownModel { Text = "Dover", Value = "Dover" }
                };
            }
        }


    }

    public class DropdownModel
    {
        public string Text { get; set; }

        public string Value { get; set; }
    }
}
