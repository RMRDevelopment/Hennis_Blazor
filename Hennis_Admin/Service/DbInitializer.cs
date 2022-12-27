
using Hennis_Admin.Service.IService;
using Hennis_Common;
using Hennis_DAL.Data;
using Hennis_DAL.DbEntities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Hennis_Admin.Service
{
    public class DbInitializer : IDbInitializer
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _context;

        public DbInitializer(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }

        public async void Initialize()
        {
            try
            {
                

                if (_context.Database.GetPendingMigrations().Count() > 0)
                {
                    _context.Database.Migrate();
                }

                //Import Users
                //var users = _context.Imports.ToList();

                //foreach (var u in users)
                //{
                //    var newUser = new ApplicationUser
                //    {
                //        UserName = u.Username,
                //        Email = u.Email,
                //        EmailConfirmed = true,
                //        Location = u.Location,
                //        FirstName = u.FirstName,
                //        LastName = u.LastName
                //    };

                //    _userManager.CreateAsync(newUser, u.Password).GetAwaiter().GetResult();
                //    _userManager.AddToRoleAsync(newUser, SD.Role_User).GetAwaiter().GetResult();
                //}

                if (_userManager.FindByNameAsync("superadmin@rmrdevelopment.com").GetAwaiter().GetResult() == null)
                {
                    ApplicationUser user = new()
                    {
                        UserName = "superadmin@rmrdevelopment.com",
                        Email = "superadmin@rmrdevelopment.com",
                        EmailConfirmed = true,
                        FirstName = "Aaron",
                        LastName = "Jones",
                        Location="All"
                    };

                    _userManager.CreateAsync(user, "RavensRGr8t!").GetAwaiter().GetResult();

                    _userManager.AddToRoleAsync(user, SD.Role_SuperAdmin).GetAwaiter().GetResult();
                }

                if (!_roleManager.RoleExistsAsync(SD.Role_Admin).GetAwaiter().GetResult())
                {
                    _roleManager.CreateAsync(new IdentityRole(SD.Role_User)).GetAwaiter().GetResult();
                    _roleManager.CreateAsync(new IdentityRole(SD.Role_Admin)).GetAwaiter().GetResult();
                    _roleManager.CreateAsync(new IdentityRole(SD.Role_SuperAdmin)).GetAwaiter().GetResult();
                }
                else
                {
                    return;
                }

                

                

            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
