using Microsoft.EntityFrameworkCore;
using WebAppHomeDecor.Domain.BaseEntities;
using WebAppHomeDecor.Domain.Entities;
namespace WebAppHomeDecor.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ItemToCart> ItemsToCart { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<Category>().ToTable("Category");
            modelBuilder.Entity<ItemToCart>().ToTable("ItemToCart");

            modelBuilder.Entity<BaseEntity>()
               .Property(e => e.Id)
               .ValueGeneratedOnAdd();

            modelBuilder.Entity<Product>()
                .Property(p => p.ProductPrice)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Product>()
                .Property(p => p.ProductName)
                .IsRequired();

            modelBuilder.Entity<Product>()
                .Property(p => p.ProductDescription)
                .IsRequired();

            modelBuilder.Entity<Product>()
                .Property(p => p.CategoryId)
                .IsRequired();

            modelBuilder.Entity<Product>()
                .Property(p => p.Quanlity)
                .IsRequired();

            modelBuilder.Entity<Category>()
                .Property(p => p.CategoryName)
                .IsRequired();

            modelBuilder.Entity<ItemToCart>()
                .HasKey(it => new { it.UserId, it.ProductId });


            base.OnModelCreating(modelBuilder);
            // Cấu hình các thực thể ở đây nếu cần
        }
    }
}
