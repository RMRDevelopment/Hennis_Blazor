using Hennis_DAL.Configuration;
using Hennis_DAL.DbEntities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hennis_DAL.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext()
        {

        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer("Data source=newgw.rmrdevelopment.com;Initial Catalog=HennisBlazor;User=sa;Password=COM214me_nts;MultipleActiveResultSets=true;Max Pool Size=100;");
            }
        }



        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var AddedEntities = ChangeTracker.Entries()
                .Where(E => E.State == EntityState.Added)
                .ToList();


            AddedEntities.ForEach(E =>
            {
                if (E.Entity.GetType().GetProperty("CreatedDateTime") != null)
                {
                    E.Property("CreatedDateTime").CurrentValue = DateTime.Now;
                }
 
            });

            var EditedEntities = ChangeTracker.Entries()
                .Where(E => E.State == EntityState.Modified)
                .ToList();

            EditedEntities.ForEach(E =>
            {
                if (E.Entity.GetType().GetProperty("ModifiedDateTime") != null)
                {
                    E.Property("ModifiedDateTime").CurrentValue = DateTime.Now;
                }
                
            });

            //return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
            return base.SaveChangesAsync(cancellationToken);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            var AddedEntities = ChangeTracker.Entries()
                .Where(E => E.State == EntityState.Added)
                .ToList();

            AddedEntities.ForEach(E =>
            {
                if (E.Entity.GetType().GetProperty("CreatedDateTime") != null)
                {
                    E.Property("CreatedDateTime").CurrentValue = DateTime.Now;
                }

            });

            var EditedEntities = ChangeTracker.Entries()
                .Where(E => E.State == EntityState.Modified)
                .ToList();

            EditedEntities.ForEach(E =>
            {
                if (E.Entity.GetType().GetProperty("ModifiedDateTime") != null)
                {
                    E.Property("ModifiedDateTime").CurrentValue = DateTime.Now;
                }
            });

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<HtmlContent> HtmlContents { get; set; }

        public DbSet<Layout> Layouts { get; set; }
        public DbSet<LayoutZone> LayoutZones { get; set; }
        public DbSet<Page> Page { get; set; }

        public DbSet<ErrorLog> ErrorLogs { get; set; }

        public DbSet<Import> Imports { get; set; }

        public DbSet<ImageGallery> ImageGallery { get; set; }

        public DbSet<Paystub> Paystubs { get; set; }
        public DbSet<BinaryFile> BinaryFiles { get; set; }

        public DbSet<PageTile> PageTiles { get; set; }

        public DbSet<StaffImage> StaffImages { get; set; }

        public DbSet<Happenings> Happenings { get; set; }

        public DbSet<OnlineApplication> OnlineApplications { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new LayoutConfiguration());
            builder.ApplyConfiguration(new LayoutZoneConfiguration());
        }
    }
}
