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
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Account> Accounts { get; set; }


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

            modelBuilder.Entity<Product>()
                .Property(x => x.Quantity_In_Stock)
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

            modelBuilder.Entity<Order>()
                .Property(x => x.Date)
                .IsRequired();

            modelBuilder.Entity<Order>()
                .Property(x => x.Number)
                .IsRequired();

            modelBuilder.Entity<Order>()
                .Property(x => x.Total_Price)
                .IsRequired();

            modelBuilder.Entity<Order>()
                .Property(x => x.Payment_Method)
                .IsRequired();

            modelBuilder.Entity<Sale>()
                .Property(x => x.Quantity_Sold)
                .IsRequired();

            modelBuilder.Entity<Sale>()
                .Property(x => x.Unit_Price)
                .IsRequired();

            modelBuilder.Entity<Account>()
                .Property(x => x.First_Name)
                .IsRequired();

            modelBuilder.Entity<Account>()
                .Property(x => x.Last_Name)
                .IsRequired();

            modelBuilder.Entity<Account>()
                .Property(x => x.Username)
                .IsRequired();

            modelBuilder.Entity<Account>()
                .Property(x => x.Email)
                .IsRequired();

            modelBuilder.Entity<Account>()
                .Property(x => x.Password)
                .IsRequired();

            modelBuilder.Entity<Account>()
                .Property(x => x.Phone_Number)
                .IsRequired();

            modelBuilder.Entity<Account>()
                .Property(x => x.Shipping_Address)
                .IsRequired();

            modelBuilder.Entity<Account>()
                .Property(x => x.Billing_Address)
                .IsRequired();

            modelBuilder.Entity<Account>()
                .Property(x => x.Create_Date)
                .IsRequired();

            modelBuilder.Entity<Account>()
                .Property(x => x.Is_Active)
                .IsRequired();

            modelBuilder.Entity<Account>()
                .Property(x => x.Role)
                .IsRequired();

        }
    }
}
