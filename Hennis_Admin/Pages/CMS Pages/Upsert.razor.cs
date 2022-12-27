using Hennis_Admin.Helper;
using Hennis_Models.Dto;
using Microsoft.AspNetCore.Components;

namespace Hennis_Admin.Pages.CMS_Pages
{
    public partial class Upsert
    {
        [Parameter]
        public int Id { get; set; }

        private IEnumerable<LayoutDto> Layouts { get; set; } = new List<LayoutDto>();
        private PageDto Page { get; set; } = new();

        private string Title { get; set; } = "Create";
        public bool IsLoading { get; set; }


        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await LoadPage();
            }

        }

        private async Task LoadPage()
        {
            IsLoading = true;
            StateHasChanged();
            Layouts = await _layoutRepository.GetAll();
            
            if (Id != 0)
            {
                Title = "Update";
                Page = await _pageRepository.Get(Id);
            }

            IsLoading = false;
            StateHasChanged();
        }

        private async Task UpsertPage()
        {
            if (Page.LayoutId == 0)
            {
                await _jsRuntime.SweetAlertError("Must select a layout");
                return;
            }

            if (Id == 0)
            {
                await _pageRepository.Create(Page);
                await _jsRuntime.SweetAlertSuccess("Page created successfully");
            }
            else
            {
                
                await _pageRepository.Update(Page);
                await _jsRuntime.SweetAlertSuccess("Page updated successfully");
            }

            _navigation.NavigateTo("/pages");
        }

        public string DropDownValue { get; set; } = "";
        public string ChangeValue { get; set; } = "Basketball";

        public void OnChange(Syncfusion.Blazor.DropDowns.ChangeEventArgs<string, LayoutDto> args)
        {
            if (args.ItemData != null)
            {
                Page.LayoutId = args.ItemData.Id;
            }
            //this.ChangeValue = args.ItemData.Name;


        }

    }
}
