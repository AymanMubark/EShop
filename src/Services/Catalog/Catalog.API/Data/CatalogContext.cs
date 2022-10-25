using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Catalog.API.Entites;

namespace Catalog.API.Data
{
    public class CatalogContext : DbContext
    {
        public CatalogContext(DbContextOptions<CatalogContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<ChoiceCategory> ChoiceCategories { get; set; } = null!;
        public DbSet<Choice> Choices { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<ProductChoice> ProductChoices { get; set; } = null!;
        public DbSet<ProductInformation> ProductInformation { get; set; } = null!;

    }
}
