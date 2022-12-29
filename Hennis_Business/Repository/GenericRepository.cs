using AutoMapper;
using Hennis_Business.Helper;
using Hennis_Business.Repository.Interface;
using Hennis_DAL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Hennis_Business.Repository
{
    public class GenericRepository<T,Dto> : IGenericRepository<T,Dto> where T : class
    {
        public ApplicationDbContext _context = null;
        public DbSet<T> table = null;
        private readonly IMapper _mapper;
        public GenericRepository(IMapper mapper)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer("Server=newgw.rmrdevelopment.com;Database=HennisBlazor;User=sa;Password=COM214me_nts");

            this._context = new ApplicationDbContext(optionsBuilder.Options);
            table = _context.Set<T>();
            _mapper = mapper;
        }
        public async Task Delete(object id)
        {
            T existing = await table.FindAsync(id);
            table.Remove(existing);
        }

        public async Task<IEnumerable<Dto>> GetAll()
        {
            var list = await table.ToListAsync();
            return _mapper.Map<IEnumerable<T>, IEnumerable<Dto>>(list);
        }

        public async Task<Dto> GetById(object id)
        {
            var record = await table.FindAsync(id);
            return _mapper.Map<Dto>(record);
        }

        public async Task Insert(Dto obj)
        {
            var model = _mapper.Map<T>(obj);
            await table.AddAsync(model);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(Dto obj)
        {
            var model = _mapper.Map<T>(obj);
            table.Attach(model);
            _context.Entry(model).State = EntityState.Modified;
        }

        public async Task<object> Create(Dto obj)
        {
            var model = _mapper.Map<T>(obj);
            await table.AddAsync(model);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                ErrorLogHelper.LogError(_context, ex, "Page Create");
                
                return obj;
            }

            var result = _mapper.Map<Dto>(model);
            return result;

        }
    }
}
