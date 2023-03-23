using Hennis_DAL.DbEntities;
using Hennis_Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hennis_Business.Repository.Interface
{
    public interface IImageGalleryRepository : IGenericRepository<ImageGallery, ImageGalleryDto>
    {
        Task<IEnumerable<ImageGalleryDto>> GetAllWithImagesAsync(int? pageId, bool removeDeleted = false);

        Task<IEnumerable<ImageGalleryDto>> GetWithImagesByLocationAsync(int? pageId, int LocationId, bool removeDeleted = false);
        Task<int> GetImageId(int id);
    }

}
