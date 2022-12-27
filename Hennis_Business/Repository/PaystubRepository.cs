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
    public class PaystubRepository : IPaystubRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public PaystubRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
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

        public Task<PaystubDto> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> PaystubExistsForEmployee(string employeeId, DateTime payDate)
        {
            var exists = await _context.Paystubs.Where(x => x.UserId == employeeId && x.PayDate == payDate).AnyAsync();

            return exists;
        }
    }
}
