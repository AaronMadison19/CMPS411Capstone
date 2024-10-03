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

        }
    }
}
