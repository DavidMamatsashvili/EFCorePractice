using EFandDBPractise.Models;
using Microsoft.EntityFrameworkCore;

namespace EFandDBPractise.Data
{
    public class EFContext:DbContext
    {
        private readonly string connectionString = @"Data Source=DESKTOP-2RL2NRE\SQLEXPRESS;Initial Catalog=UserProducts;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";
        public EFContext(DbContextOptions<EFContext> options) : base(options)
        {
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder builder)
        //{
        //    builder.UseSqlServer(connectionString);
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //table name
            modelBuilder.Entity<Product>().ToTable("products");

            //columns
            //product
            modelBuilder.Entity<Product>().Property(p => p.ProductId).HasColumnName("product_id").IsRequired();
            modelBuilder.Entity<Product>().Property(p => p.ProductName).HasColumnName("product_name").HasMaxLength(255).IsRequired();
            modelBuilder.Entity<Product>().Property(p => p.BrandId).HasColumnName("brand_id").IsRequired();
            modelBuilder.Entity<Product>().Property(p => p.CategoryId).HasColumnName("category_id").IsRequired();
            modelBuilder.Entity<Product>().Property(p => p.ModelYear).HasColumnName("model_year").IsRequired();
            modelBuilder.Entity<Product>().Property(p => p.Price).HasColumnName("list_price").HasColumnType("decimal(10,2)").IsRequired();

            //exclude products from migrations
            modelBuilder.Entity<Product>().ToTable("products", t => t.ExcludeFromMigrations());

            //order
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Product)
                .WithMany(p => p.Orders)
                .HasForeignKey(o => o.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            //constraints
            modelBuilder.Entity<Product>().HasKey(p => p.ProductId); //primary key
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
