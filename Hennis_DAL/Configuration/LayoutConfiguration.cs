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
    public class LayoutConfiguration : IEntityTypeConfiguration<Layout>
    {
        public void Configure(EntityTypeBuilder<Layout> builder)
        {
            builder.ToTable("Layout");
            builder.HasData(
                new Layout
                {
                    Id = 1,
                    Name = "Full Width",
                },
                new Layout
                {
                    Id = 2,
                    Name = "Two Column"
                }
           );
        }
    }
}
