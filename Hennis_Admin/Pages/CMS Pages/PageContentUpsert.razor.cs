using Hennis_Admin.Helper;
using Hennis_Models.Dto;
using Microsoft.AspNetCore.Components;
using Syncfusion.Blazor.RichTextEditor;

namespace Hennis_Admin.Pages.CMS_Pages
{
    public partial class PageContentUpsert
    {
        [Parameter]
        public int Id { get; set; }

        [Parameter]
        public int PageId { get; set; }

        private PageDto Page { get; set; } = new();
        private HtmlContentDto HtmlContent { get; set; } = new();


        private IEnumerable<LayoutZoneDto> LayoutZones { get; set; } = new List<LayoutZoneDto>();

        private string Title { get; set; } = "Create";

        public string LayoutZone { get; set; } = "";
        public bool IsLoading { get; set; }

        public string DropDownValue { get; set; } = "";

        public string ChangeValue { get; set; } = "";

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await InitializePage();
            }

        }

        private async Task InitializePage()
        {
            IsLoading = true;
            StateHasChanged();
            if (Id != 0)
            {
                Title = "Update";
                HtmlContent = await _htmlContentRepository.GetById(Id);
                PageId = HtmlContent.PageId;

            }
            else
            {
                HtmlContent.PageId = PageId;
            }
            Page = await _pageRepository.GetById(PageId);
            LayoutZones = Page.Layout.LayoutZones;

            IsLoading = false;
            StateHasChanged();
        }

        private async Task UpsertContent()
        {
            

            if (Id == 0)
            {
                await _htmlContentRepository.Insert(HtmlContent);
                await _htmlContentRepository.Save();
                await _jsRuntime.SweetAlertSuccess("Page created successfully");
            }
            else
            {

                _htmlContentRepository.Update(HtmlContent);
                await _htmlContentRepository.Save();
                await _jsRuntime.SweetAlertSuccess("Page updated successfully");
            }

            _navigation.NavigateTo("/pages");
        }

        

        public void OnChange(Syncfusion.Blazor.DropDowns.ChangeEventArgs<string, LayoutZoneDto> args)
        {
            if (args.ItemData != null)
            {
                HtmlContent.LayoutZoneName = args.ItemData.Name;
            }
            //this.ChangeValue = args.ItemData.Name;


        }
        public void ValueChangeHandler(Syncfusion.Blazor.RichTextEditor.ChangeEventArgs args)
        {
            //here you can can get the editor value using args.value
            HtmlContent.Content = args.Value;
        }
    }
}
