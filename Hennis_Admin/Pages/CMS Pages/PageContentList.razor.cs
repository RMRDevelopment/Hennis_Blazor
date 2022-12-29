using Hennis_Models.Dto;
using Microsoft.AspNetCore.Components;

namespace Hennis_Admin.Pages.CMS_Pages
{
    public partial class PageContentList
    {
        [Parameter]
        public int PageId { get; set; }
        private PageDto Page { get; set; } = new PageDto();
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
            Page = await _pageRepository.GetById(PageId);
            IsLoading = false;
            StateHasChanged();
        }
    }
}
