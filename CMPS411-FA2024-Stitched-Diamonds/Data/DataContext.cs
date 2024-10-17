using CMPS411_FA2024_Stitched_Diamonds.Controllers;
using CMPS411_FA2024_Stitched_Diamonds.Entities;
using Microsoft.EntityFrameworkCore;

namespace CMPS411_FA2024_Stitched_Diamonds.Data
{
    public sealed class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) 
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Order> Orders { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>()
                .Property(x => x.Name)
                .IsRequired();

            modelBuilder.Entity<Product>()
                .Property(x => x.Description)
                .IsRequired();

            modelBuilder.Entity<Product>()
                .Property(x => x.Details)
                .IsRequired();

            modelBuilder.Entity<Product>()
                .Property(x => x.Price)
                .IsRequired();

            modelBuilder.Entity<Product>()
                .Property(x => x.ImageUrl)
                .IsRequired();

            modelBuilder.Entity<Categories>()
                .Property(x => x.Type)
                .IsRequired();

            modelBuilder.Entity<Categories>()
                .Property(x => x.Category_Type)
                .IsRequired();

            modelBuilder.Entity<Material>()
                .Property(x => x.Type)
                .IsRequired();

            modelBuilder.Entity<Material>()
                .Property(x => x.Is_Allergen_Free)
                .IsRequired();

            modelBuilder.Entity<Material>()
                .Property(x => x.Quantity_In_Stock)
                .IsRequired();

        }
    }
}
