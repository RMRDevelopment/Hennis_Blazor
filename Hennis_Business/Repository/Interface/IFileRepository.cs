using Hennis_DAL.DbEntities;
using Hennis_Models.Dto;
using Hennis_Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hennis_Business.Repository.Interface
{
    public interface IFileRepository
    {
        
        Task<BinaryFile> GetBinaryFile(int id);
        Task<BinaryFile> GetBinaryFile(Guid guid);
    }
}
