using Hennis_Models.Dto;
using Syncfusion.Blazor.Grids;
using Syncfusion.Blazor.Inputs;

namespace Hennis_Admin.Pages.Homepage_Tiles
{
    public partial class Index
    {
        private IEnumerable<HomePageTileDto> Tiles { get; set; } = new List<HomePageTileDto>();
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
            Tiles = await _repo.GetAllWithImagesAsync();
            IsLoading = false;
            StateHasChanged();
        }

        private void SuccessHandler(SuccessEventArgs args)
        {
            FileName = args.File.Name;
            // Disabled = false;
            StateHasChanged();
        }

        public async Task ActionComplete(ActionEventArgs<HomePageTileDto> args)
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
                    
                    _repo.Update(args.Data, new Hennis_DAL.DbEntities.HomePageTile());
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
