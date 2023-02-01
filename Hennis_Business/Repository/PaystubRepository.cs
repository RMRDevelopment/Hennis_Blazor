using AutoMapper;
using AutoMapper.QueryableExtensions;
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
    public class PaystubRepository : GenericRepository<Paystub, PaystubDto>, IPaystubRepository
    {

        private readonly IMapper _mapper;
        public PaystubRepository(IMapper mapper) : base(mapper)
        {
            _mapper = mapper;
        }
        public async Task<PaystubDto> Create(PaystubModel model)
        {
            try
            {

                var binaryFile = new BinaryFile
                {
                    Bytes = model.Stream,
                    FileExtension = model.Type,
                    FileName = model.FileName,
                    Guid = Guid.NewGuid()
                };
                var paystub = new Paystub
                {
                    File = binaryFile,
                    PayDate = model.PayDate,
                    UserId = model.UserId
                };

                

                await _context.Paystubs.AddAsync(paystub);
                await _context.SaveChangesAsync();


                return _mapper.Map<PaystubDto>(paystub);

            }
            catch (Exception ex)
            {
                ErrorLogHelper.LogError(_context, ex, "Page Create");
                var dto = new PaystubDto();
                dto.IsError = true;
                dto.ErrorMessage = "An error occurred saving";
                return dto;
            }
        }

        public async Task<IEnumerable<PaystubDto>> GetAllByUserId(string userid)
        {
            return await _context.Paystubs.Where(x => x.UserId == userid).OrderByDescending(x => x.CreatedDateTime).ProjectTo<PaystubDto>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<BinaryFile> GetBinaryFileById(int id)
        {
            return await _context.BinaryFiles.FindAsync(id);
        }

        public Task<IEnumerable<PaystubDto>> GetByDate(DateTime date)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PaystubDto>> GetByDateAndUserId(DateTime date, int UserId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PaystubDto>> GetPaystubsByFullName(string fullName)
        {
            return await _context.Paystubs.Include(x => x.User).Include(x => x.File).Where(x => x.User.FirstName + x.User.LastName == fullName).OrderByDescending(x => x.CreatedDateTime).ProjectTo<PaystubDto>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<bool> PaystubExistsForEmployee(string employeeId, DateTime payDate)
        {
            var exists = await _context.Paystubs.Where(x => x.UserId == employeeId && x.PayDate == payDate).AnyAsync();

            return exists;
        }
    }
}
