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
            try
            {
                var list = await table.ToListAsync();
                return _mapper.Map<IEnumerable<T>, IEnumerable<Dto>>(list);
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }

        public async Task<Dto> GetById(object id)
        {
            try
            {
                var record = await table.FindAsync(id);
                return _mapper.Map<Dto>(record);
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        public async Task Insert(Dto obj)
        {
            try
            {
                var model = _mapper.Map<T>(obj);
                await table.AddAsync(model);
            }
            catch (Exception ex)
            {

                throw;
            }
           
        }

        public async Task Save()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public void Update(Dto obj, T dest)
        {
            try
            {
                //var model = _mapper.Map<T>(obj);
                MapValidValues(obj, dest);
                table.Attach(dest);
                _context.Entry(dest).State = EntityState.Modified;
            }
            catch (Exception ex)
            {

                throw;
            }
            
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

        #region Helper Methods
        public static U MapValidValues<U, T>(T source, U destination)
        {
            // Go through all fields of source, if a value is not null, overwrite value on destination field.
            foreach (var propertyName in source.GetType().GetProperties().Where(p => !p.PropertyType.IsGenericType).Select(p => p.Name))
            {
                var value = source.GetType().GetProperty(propertyName).GetValue(source, null);
                if (value != null && value.GetType() != typeof(byte[]) && (value.GetType() != typeof(DateTime) || (value.GetType() == typeof(DateTime) && (DateTime)value != DateTime.MinValue)))
                {
                    var exists = destination.GetType().GetProperty(propertyName);
                    if (exists != null)
                    {
                        destination.GetType().GetProperty(propertyName).SetValue(destination, value, null);
                    }

                }
            }

            return destination;
        }
        #endregion
    }
}
