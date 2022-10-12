using Hennis_Models.Dto;

namespace Hennis_Admin.Pages.CMS_Pages
{
    public partial class PageList
    {
        private IEnumerable<PageDto> Pages { get; set; } = new List<PageDto>();
        public bool IsLoading { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await LoadPages();
            }
        }

        private async Task LoadPages()
        {
            IsLoading = true;
            StateHasChanged();
            Pages = await _pageRepository.GetAll();
            IsLoading = false;
            StateHasChanged();
        }
    }
}
