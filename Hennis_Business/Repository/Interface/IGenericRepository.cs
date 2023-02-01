using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hennis_Business.Repository.Interface
{
    public interface IGenericRepository<T,Dto> where T : class
    {
        Task<IEnumerable<Dto>> GetAll();
        Task<Dto> GetById(object id);
        Task Insert(Dto obj);
        void Update(Dto obj,T dest);
        Task Delete(object id);
        Task Save();

        Task<object> Create(Dto obj);
    }
}
