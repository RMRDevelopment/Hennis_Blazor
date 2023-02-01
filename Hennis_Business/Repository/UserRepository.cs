using Hennis_Business.Repository.Interface;
using Hennis_DAL.Data;
using Hennis_DAL.DbEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hennis_Business.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ApplicationUser>> GetAll()
        {
            return await _context.ApplicationUsers.OrderBy(x => x.LastName).ToListAsync();
        }

        public async Task<ApplicationUser> GetUserByName(string firstname, string lastname)
        {
            var user = await _context.ApplicationUsers.Where(x => x.FirstName == firstname && x.LastName == lastname).FirstOrDefaultAsync();

            return user;
        }

        public async Task<ApplicationUser> GetUserByNameAndLocation(string firstname, string lastname, string location)
        {
            var user = await _context.ApplicationUsers.Where(x => x.FirstName == firstname && x.LastName == lastname && x.Location == location).FirstOrDefaultAsync();

            return user;
        }

        public async Task<ApplicationUser> GetUserByUsername(string username)
        {
            return await _context.ApplicationUsers.Where(x => x.UserName == username).FirstOrDefaultAsync();
        }
    }
}
