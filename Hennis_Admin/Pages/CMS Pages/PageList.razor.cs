using Hennis_Models.Dto;

namespace Hennis_Admin.Pages.CMS_Pages
{
    public partial class PageList
    {
        private IEnumerable<PageDto> Pages { get; set; } = new List<PageDto>();
        public bool IsLoading { get; set; }

        public class TreeObject
        {
            public int Id { get; set; }

            public int? ParentId { get; set; }

            public string Name { get; set; }

            public string Title { get; set; }

            public byte[] ImageData { get; set; }

        }

        public List<TreeObject> TreeData = new List<TreeObject>();

        protected override void OnAfterRender(bool firstRender)
        {
            if (firstRender)
            {
                IsLoading = true;
                StateHasChanged();
                Pages = _pageRepository.GetAllWithImagesAsync().OrderBy(x => x.ParentPageId).ThenBy(x => x.Name);

                foreach (var page in Pages)
                {
                    TreeData.Add(new TreeObject
                    {
                        Id = page.Id,
                        ParentId = page.ParentPageId,
                        Name = page.Name,
                        Title = page.Title,
                        ImageData = page.ImageData
                    });
                }

                IsLoading = false;
                StateHasChanged();
            }

           
            
        }
    }
}
