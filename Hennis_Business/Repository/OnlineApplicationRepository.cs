
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Hennis_Business.Helper;
using Hennis_Business.Repository.Interface;
using Hennis_DAL.Data;
using Hennis_DAL.DbEntities;
using Hennis_Models.Dto;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Hennis_Business.Repository
{
    public class OnlineApplicationRepistory : GenericRepository<OnlineApplication, OnlineApplication>, IOnlineApplicationRepository
    {

        private readonly IMapper _mapper;

        public OnlineApplicationRepistory( IMapper mapper) : base(mapper)
        {

            _mapper = mapper;
        }

        public async Task<OnlineApplicationDto> ConvertToObject(int id)
        {
            var application = await GetById(id);
            try
            {
                var model = JsonConvert.DeserializeObject<OnlineApplicationDto>(application.Json);
                model.Id = id;
                return model;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<IEnumerable<OnlineApplicationDto>> GetObjectList()
        {
            List<OnlineApplicationDto> list = new List<OnlineApplicationDto>();

            var dbList = await GetAll();
            try
            {
                foreach (var item in dbList)
                {
                    var model = JsonConvert.DeserializeObject<OnlineApplicationDto>(item.Json);
                    model.Id = item.Id;
                    list.Add(model);
                }
                return list;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public async Task<OnlineApplication> SubmitApplication(OnlineApplicationDto onlineApplication)
        {
            try
            {
                onlineApplication.DateSubmitted = DateTime.Now;
                var json = JsonConvert.SerializeObject(onlineApplication);
                var model = new OnlineApplication();
                model.Json = json;
                
                await Create(model);

                return model;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
