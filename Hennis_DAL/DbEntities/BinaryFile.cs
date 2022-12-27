using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hennis_DAL.DbEntities
{
    [Table("BinaryFile")]
    public class BinaryFile
    {
        public int Id { get; set; }

        public byte[] Bytes { get; set; }

        public string FileName { get; set; }

        public string FileExtension { get; set; }


        public Guid? Guid { get; set; }

    }
}
