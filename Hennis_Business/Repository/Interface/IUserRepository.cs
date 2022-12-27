using Hennis_DAL.DbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hennis_Business.Repository.Interface
{
    public interface IUserRepository
    {
        Task<ApplicationUser> GetUserByName(string firstname, string lastname);
        Task<ApplicationUser> GetUserByNameAndLocation(string firstname, string lastname,string location);
    }
}
