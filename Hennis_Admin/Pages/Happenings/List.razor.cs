using Hennis_Models.Dto;
using Syncfusion.Blazor.Grids;
using Syncfusion.Blazor.Inputs;

namespace Hennis_Admin.Pages.Happenings
{
    public partial class List
    {
        private IEnumerable<HappeningsDto> Items { get; set; } = new List<HappeningsDto>();
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
            Items = await _repo.GetAll();
            IsLoading = false;
            StateHasChanged();
        }

        private void SuccessHandler(SuccessEventArgs args)
        {
            //FileName = args.File.Name;
            // Disabled = false;
            StateHasChanged();
        }

        public async Task ActionComplete(ActionEventArgs<HappeningsDto> args)
        {
            if (args.RequestType.Equals(Syncfusion.Blazor.Grids.Action.Save))
            {
                // get file by name
                //var file = await _fileRepo.GetFileByName(FileName);
                //args.Data.ImageId = file != null ? file.Id : 0;
                if (args.Data.Id == 0)
                {
                    await _repo.Create(args.Data);
                }
                else
                {
                    //if (args.Data.ImageId == 0)
                    //{
                    //    var imageId = await _repo.GetImageId(args.Data.Id);
                    //    args.Data.ImageId = imageId;
                    //}

                    _repo.Update(args.Data, new Hennis_DAL.DbEntities.Happenings());
                    await _repo.Save();
                }
            }

            if (args.RequestType.Equals(Syncfusion.Blazor.Grids.Action.Delete))
            {
                await _repo.Delete(args.Data);
            }
        }

    }
}
