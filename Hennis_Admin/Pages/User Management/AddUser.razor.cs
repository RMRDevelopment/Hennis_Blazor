using Hennis_DAL.DbEntities;
using Hennis_Models.Dto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Policy;

namespace Hennis_Admin.Pages.User_Management
{
    public partial class AddUser
    {
        private CreateUserDto User { get; set; } = new();

        public string ReturnUrl { get; set; }
        public bool IsLoading { get; set; }



        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }

        private async Task SaveUser()
        {
            
            var user = CreateUser();
            user.FirstName = User.FirstName;
            user.LastName = User.LastName;
            user.Location = User.SelectedLocation;
            user.UserName = User.Username;
            user.Email = User.Email;
            user.EmailConfirmed = true;
            //await _userStore.SetUserNameAsync(user, User.Username, CancellationToken.None);
            //await _emailStore.SetEmailAsync(user, user.Email, CancellationToken.None);
            var result = await _userManager.CreateAsync(user, User.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, User.SelectedRole);
                _navigation.NavigateTo("~/Admin/Users");
                //return LocalRedirect(returnUrl);

            }
            foreach (var error in result.Errors)
            {
                // ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        // If we got this far, something failed, redisplay form


        #region Helpers
        private ApplicationUser CreateUser()
        {
            try
            {
                return Activator.CreateInstance<ApplicationUser>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(ApplicationUser)}'. " +
                    $"Ensure that '{nameof(ApplicationUser)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }
        #endregion


    }
}
