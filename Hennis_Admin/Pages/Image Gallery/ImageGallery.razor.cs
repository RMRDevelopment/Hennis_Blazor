using Hennis_Models.Dto;
using Syncfusion.Blazor.Grids;
using Syncfusion.Blazor.Inputs;

namespace Hennis_Admin.Pages.Image_Gallery
{
    public partial class ImageGallery
    {
        private IEnumerable<ImageGalleryDto> Tiles { get; set; } = new List<ImageGalleryDto>();
        private IEnumerable<PageDto> Pages { get; set; } = new List<PageDto>();
        public bool IsLoading { get; set; }
        public string FileName { get; set; }
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
            Tiles = await _repo.GetAllWithImagesAsync(null);
            Pages = await _pageRepo.GetAll();
            IsLoading = false;
            StateHasChanged();
        }

        private void SuccessHandler(SuccessEventArgs args)
        {
            FileName = args.File.Name;
            // Disabled = false;
            StateHasChanged();
        }

        public async Task ActionComplete(ActionEventArgs<ImageGalleryDto> args)
        {
            if (args.RequestType.Equals(Syncfusion.Blazor.Grids.Action.Save))
            {
                // get file by name
                var file = await _fileRepo.GetFileByName(FileName);
                args.Data.ImageId = file != null ? file.Id : 0;
                if (args.Data.Id == 0)
                {
                    await _repo.Create(args.Data);
                }
                else
                {
                    if (args.Data.ImageId == 0)
                    {
                        var imageId = await _repo.GetImageId(args.Data.Id);
                        args.Data.ImageId = imageId;
                    }
                    
                    _repo.Update(args.Data, new Hennis_DAL.DbEntities.ImageGallery());
                    await _repo.Save();
                }
            }

            if (args.RequestType.Equals(Syncfusion.Blazor.Grids.Action.Delete))
            {
                await _repo.Delete(args.Data);
            }
        }

        public string convert(byte[] a)
        {
            return string.Join("", a.Select(b => string.Format("{0:X2}", b)));
        }
    }
}
