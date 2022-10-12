using Hennis_DAL.DbEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hennis_DAL.Configuration
{
    internal class LayoutZoneConfiguration : IEntityTypeConfiguration<LayoutZone>
    {
        public void Configure(EntityTypeBuilder<LayoutZone> builder)
        {
            builder.ToTable("LayoutZone");

            builder.HasData(
                new LayoutZone
                {
                    Id = 1,
                    LayoutId = 1,
                    Name = "Feature"
                },
                new LayoutZone
                {
                    Id = 2,
                    LayoutId = 1,
                    Name = "ZoneA"
                },
                new LayoutZone
                {
                    Id = 3,
                    LayoutId = 2,
                    Name = "Feature"
                },
                new LayoutZone
                {
                    Id = 4,
                    LayoutId = 2,
                    Name = "ZoneA"
                },
                new LayoutZone
                {
                    Id = 5,
                    LayoutId = 2,
                    Name = "ZoneB"
                }
            );
        }
        
    }
}
