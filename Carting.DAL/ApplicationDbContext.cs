using Carting.Domain.Entities;
using Catalog.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace Catalog.DataAccessLayer
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options) { }

        public DbSet<CategoryDALEntity> Categories { get; set; }
        public DbSet<ItemDALEntity> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {             
        }
    }
}
