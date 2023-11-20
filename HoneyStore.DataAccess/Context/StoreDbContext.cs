using HoneyStore.DataAccess.Entities;
using HoneyStore.DataAccess.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HoneyStore.DataAccess.Context
{
    public class StoreDbContext : IdentityDbContext<User, Role, int>
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<ProductPhoto> ProductPhotos { get; set; }

        public DbSet<Producer> Producers { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Wish> Wishes { get; set; }

        public DbSet<CartItem> CartItems { get; set; }

        public DbSet<Order> Orders { get; set; }

        public StoreDbContext(DbContextOptions<StoreDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            #region ProductCategory

            builder.Entity<ProductCategory>()
                .HasKey(bc => new { bc.ProductId, bc.CategoryId });
            builder.Entity<ProductCategory>()
                .HasOne(bc => bc.Product)
                .WithMany(b => b.ProductCategories)
                .HasForeignKey(bc => bc.ProductId);
            builder.Entity<ProductCategory>()
                .HasOne(bc => bc.Category)
                .WithMany(c => c.ProductCategories)
                .HasForeignKey(bc => bc.CategoryId);

            #endregion

            #region Wish

            builder.Entity<Wish>().HasKey(w => new
            {
                w.ProductId,
                w.UserId
            });

            #endregion

        }
    }
}
