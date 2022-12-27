using AutoMapper;
using Hennis_Business.Helper;
using Hennis_Business.Repository.Interface;
using Hennis_DAL.Data;
using Hennis_DAL.DbEntities;
using Hennis_Models.Dto;
using Hennis_Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Org.BouncyCastle.Math.EC.Rfc7748;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hennis_Business.Repository
{
    public class FileRepository : IFileRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public FileRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<BinaryFile> GetBinaryFile(int id)
        {
            var file = await _context.BinaryFiles.FindAsync(id);
            if (file == null)
            {
                file = new BinaryFile();
            }
            return file;
        }

        public async Task<BinaryFile> GetBinaryFile(Guid guid)
        {
            var file = await _context.BinaryFiles.Where(x => x.Guid == guid).FirstOrDefaultAsync();
            if (file == null)
            {
                file = new BinaryFile();
            }
            return file;
        }
    }
}
