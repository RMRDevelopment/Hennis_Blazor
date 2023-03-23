using Hennis_DAL.DbEntities;
using Syncfusion.Blazor.Grids;

namespace Hennis_Admin.Pages.User_Management
{
    public partial class Index
    {
        public bool IsLoading { get; set; }
        private IEnumerable<ApplicationUser> Users = new List<ApplicationUser>();

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await LoadUsers();
            }
        }

        private async Task LoadUsers()
        {
            IsLoading = true;
            StateHasChanged();
            Users = await _repo.GetAll();
            IsLoading= false;
            StateHasChanged();
        }

        public async Task ActionComplete(ActionEventArgs<ApplicationUser> args)
        {
            if (args.RequestType.Equals(Syncfusion.Blazor.Grids.Action.Save))
            {
                
            }
        }
    }
}
