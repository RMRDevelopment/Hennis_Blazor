using Hennis_Admin.Helper;
using Hennis_Models.ViewModels;
using Syncfusion.Blazor.Buttons;
using Syncfusion.Blazor.Inputs;

namespace Hennis_Admin.Pages.Paystub_Admin
{
    public partial class Index
    {
        public string DropDownValue { get; set; }
        public bool IsLoading { get; set; } = false;

        public DateTime? DateValue { get; set; }

        public bool Disabled { get; set; } = true;
        private PaystubModel Model { get; set; } = new();
        public string FileName { get; set; }

        private string Summary { get; set; }

        List<Location> LocationList = new List<Location>{
        new Location() {Name = "Dover" },
        new Location() {Name = "Bolivar" }
    };

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                IsLoading = false;
                StateHasChanged();
            }
        }

        private void SuccessHandler(SuccessEventArgs args)
        {
            FileName = args.File.Name;
            Disabled = false;
            StateHasChanged();
        }

        public void OnDropdownChange(Syncfusion.Blazor.DropDowns.ChangeEventArgs<string, Location> args)
        {
            if (args.ItemData != null)
            {
                DropDownValue = args.ItemData.Name;
            }
            //this.ChangeValue = args.ItemData.Name;


        }

        private async Task UploadPayroll()
        {
            if (DateValue.HasValue == false)
            {
                await _jsRuntime.SweetAlertError("Paydate is required");
                return;
            }

            if (string.IsNullOrEmpty(DropDownValue))
            {
                await _jsRuntime.SweetAlertError("Location is required");
                return;
            }

            if (string.IsNullOrEmpty(FileName))
            {
                await _jsRuntime.SweetAlertError("File is required");
                return;
            }

            Model.FileName = FileName;
            Model.PayDate = DateValue.Value;
            Model.Location = DropDownValue;

            IsLoading = true;
            StateHasChanged();

            var result = await _paystubService.ProcessPdf(Model);
            Summary = "<ul>" + result + "</ul>";
            IsLoading = false;
            StateHasChanged();


            
                await _jsRuntime.SweetAlertError("Uploaded successfully");
                return;
            

            
        }


        private void DateChanged(Syncfusion.Blazor.Calendars.ChangedEventArgs<DateTime?> args)
        {
            DateValue = args.Value;
            StateHasChanged();
        }
    }
    public class Location
    {
        public string Name { get; set; }
    }
}
