using Hennis_DAL.DbEntities;
using Hennis_Models.Dto;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Policy;

namespace Hennis_Admin.Pages.User_Management
{
    public partial class ResetPassword
    {
        [Parameter]
        public string Id { get; set; }
        private ResetPasswordDto User { get; set; } = new();

        private ApplicationUser DbUser { get; set; } = new();

        public string ReturnUrl { get; set; }
        public bool IsLoading { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await SetUser();
            }
        }

        private async Task SetUser()
        {
            DbUser = await _userManager.FindByIdAsync(Id);
        }

        private async Task SaveUser()
        {

            await _userManager.RemovePasswordAsync(DbUser);
            await _userManager.AddPasswordAsync(DbUser, User.Password);
            //await _userStore.SetUserNameAsync(user, User.Username, CancellationToken.None);
            //await _emailStore.SetEmailAsync(user, user.Email, CancellationToken.None);
            _navigation.NavigateTo("/Admin/Users");
            
        }

        // If we got this far, something failed, redisplay form


        


    }
}
