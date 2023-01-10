using Microsoft.EntityFrameworkCore;
using UrlApp.Data.Models;

namespace UrlApp.Data
{
    public class UrlDbContext: DbContext
    {
        public UrlDbContext(DbContextOptions<UrlDbContext> options) : base(options)
        {

        }

        public DbSet<Url> Urls { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //setting DB Connection string
            optionsBuilder.UseSqlServer(@"server=(localdb)\ProjectModels; Database=FarhoodURL;Trusted_Connection=True;");
        }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UrlDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }


    }
}