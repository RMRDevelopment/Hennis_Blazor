using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hennis_Models.Dto
{
    public class PageDto : BaseModel
    {
        public int Id { get; set; }

        public int LayoutId { get; set; }

        public int? ParentPageId { get; set; }
        public int Order { get; set; }

        public string Name { get; set; }

        public string Title { get; set; }

        public int? ImageId { get; set; } = 0;

        public byte[] ImageData { get; set; }

        public string FileName { get; set; }

        public string ParentPageName { get; set; }

        public LayoutDto Layout { get; set; }

        public PageDto ParentPage { get; set; }

        public ICollection<HtmlContentDto> HtmlContents { get; set; } = new List<HtmlContentDto>();

        public string ImageSourceData
        {
            get
            {
                return ImageData == null ? "" : $"data:image/png;base64,{Convert.ToBase64String(ImageData)}";
                
            }
        }
    }
}
