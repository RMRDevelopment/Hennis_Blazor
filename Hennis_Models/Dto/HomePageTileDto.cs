﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hennis_Models.Dto
{
    public class HomePageTileDto : BaseModel
    {
        public int Id { get; set; }

        public int Order { get; set; }

        public string Title { get; set; }

        public int ImageId { get; set; }


        public string Content { get; set; }

        public bool Deleted { get; set; }

        public byte[] ImageData { get; set; }

        public string FileName { get; set; }
    }
}
