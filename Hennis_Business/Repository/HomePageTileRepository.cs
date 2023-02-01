
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Hennis_Business.Helper;
using Hennis_Business.Repository.Interface;
using Hennis_DAL.Data;
using Hennis_DAL.DbEntities;
using Hennis_Models.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hennis_Business.Repository
{
    public class HomePageTileRepository : GenericRepository<HomePageTile, HomePageTileDto>, IHomePageTileRepository
    {

        private readonly IMapper _mapper;

        public HomePageTileRepository( IMapper mapper) : base(mapper)
        {

            _mapper = mapper;
        }

        public async Task<IEnumerable<HomePageTileDto>> GetAllWithImagesAsync(bool removeDeleted = false)
        {
            var list = await _context.HomePageTiles.Include(x => x.Image).ProjectTo<HomePageTileDto>(_mapper.ConfigurationProvider).ToListAsync();
            if (removeDeleted)
            {
                return list.Where(x => x.Deleted == false).ToList();
            }
            return list;
        }

        public async Task<int> GetImageId(int id)
        {
            return await _context.HomePageTiles.Where(x => x.Id == id).Select(x => x.ImageId).FirstOrDefaultAsync();
        }
    }
}
