using Hennis_Admin.Helper;
using Hennis_Models.Dto;
using Microsoft.AspNetCore.Components;
using Syncfusion.Blazor.Inputs;

namespace Hennis_Admin.Pages.CMS_Pages
{
    public partial class Upsert
    {
        [Parameter]
        public int Id { get; set; }

        private IEnumerable<LayoutDto> Layouts { get; set; } = new List<LayoutDto>();
        private IEnumerable<PageDto> Pages { get; set; } = new List<PageDto>();
        private PageDto Page { get; set; } = new();

        private string Title { get; set; } = "Create";
        public bool IsLoading { get; set; }

        public string FileName { get; set; } = "";

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
            Pages = await _pageRepository.GetAll();
            
            if (Id != 0)
            {
                Title = "Update";
                Page = await _pageRepository.GetById(Id);
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

            var file = await _fileRepo.GetFileByName(FileName);
            Page.ImageId = file != null ? file.Id : null;

            if (Id == 0)
            {
                await _pageRepository.Create(Page);
                await _jsRuntime.SweetAlertSuccess("Page created successfully");
            }
            else
            {
                if (Page.ImageId == 0)
                {
                    var imageId = await _pageRepository.GetImageId(Page.Id);
                    Page.ImageId = imageId.HasValue ? imageId.Value : null;
                    
                }
                await _pageRepository.Update(Page);
                await _jsRuntime.SweetAlertSuccess("Page updated successfully");
            }

            _navigation.NavigateTo($"/pages/content/{Page.Id}");
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

        public string? PageValue { get; set; }

        public void OnPageChange(Syncfusion.Blazor.DropDowns.ChangeEventArgs<string, PageDto> args)
        {
            if (args.ItemData != null)
            {
                Page.ParentPageId = args.ItemData.Id;
            }
        }

        private void SuccessHandler(SuccessEventArgs args)
        {
            FileName = args.File.Name;
            // Disabled = false;
            StateHasChanged();
        }

    }
}
