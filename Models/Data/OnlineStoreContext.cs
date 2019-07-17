using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace OnlineStore.Models.Data
{
    public partial class OnlineStoreContext : DbContext
    {
        public OnlineStoreContext()
        {
        }

        public OnlineStoreContext(DbContextOptions<OnlineStoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<PurchaseHistory> PurchaseHistory { get; set; }
        public virtual DbSet<User> User { get; set; }
          
//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Server=.\\;Database=OnlineStore;Trusted_Connection=True;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Name).HasDefaultValueSql("('Default Name')");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__Product__Categor__3B75D760");
            });

            modelBuilder.Entity<PurchaseHistory>(entity =>
            { 
                entity.HasOne(d => d.Product)
                    .WithMany(p => p.PurchaseHistory)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__PurchaseH__Count__4316F928");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.PurchaseHistory)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__PurchaseH__UserI__440B1D61");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Nickname).HasDefaultValueSql("('Default Nickname')");

                entity.Property(e => e.Phone).HasDefaultValueSql("('No phone')");
            });
        }
    }
}
