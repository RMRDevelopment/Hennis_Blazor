
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
    public class ImageGalleryRepository : GenericRepository<ImageGallery, ImageGalleryDto>, IImageGalleryRepository
    {

        private readonly IMapper _mapper;

        public ImageGalleryRepository( IMapper mapper) : base(mapper)
        {

            _mapper = mapper;
        }

        public async Task<IEnumerable<ImageGalleryDto>> GetAllWithImagesAsync(int? pageId, bool removeDeleted = false)
        {
            var list = await _context.ImageGallery.Include(x => x.Image).ProjectTo<ImageGalleryDto>(_mapper.ConfigurationProvider).ToListAsync();
            
            if (pageId.HasValue)
            {
                list = list.Where( x=> x.PageId == pageId.Value ).ToList();
            }

            if (removeDeleted)
            {
                return list.Where(x => x.Deleted == false).ToList();
            }
            return list;
        }

        public async Task<int> GetImageId(int id)
        {
            return await _context.ImageGallery.Where(x => x.Id == id).Select(x => x.ImageId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ImageGalleryDto>> GetWithImagesByLocationAsync(int? pageId, int locationId, bool removeDeleted = false)
        {
            var list = await _context.ImageGallery.Include(x => x.Image).Where(x => x.LocationId == locationId).ProjectTo<ImageGalleryDto>(_mapper.ConfigurationProvider).ToListAsync();

            if (pageId.HasValue)
            {
                list = list.Where(x => x.PageId == pageId.Value).ToList();
            }

            return list;
        }
    }
}
