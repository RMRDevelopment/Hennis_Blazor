using Hennis_DAL.DbEntities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hennis_DAL.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<HtmlContent> HtmlContents { get; set; }

        public DbSet<Layout> Layouts { get; set; }
        public DbSet<LayoutZone> LayoutZones { get; set; }
        public DbSet<Page> Page { get; set; }
    }
}
