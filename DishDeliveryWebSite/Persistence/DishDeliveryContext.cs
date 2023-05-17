using DishDeliveryWebSite.Helpers;
using DishDeliveryWebSite.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace DishDeliveryWebSite.Persistence
{
    public partial class DishDeliveryContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public DishDeliveryContext()
        {
        }

        public DishDeliveryContext(DbContextOptions<DishDeliveryContext> options)
            : base(options)
        {
        }

        public DbSet<DishCategory> DishCategories { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<DishDescription> DishDescriptions { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<RefreshToken>()
                .HasKey(t => new { t.UserId, t.Token });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("Id");

                entity.Property(e => e.Achivment)
                    .HasMaxLength(Int16.MaxValue)
                    .HasColumnName("Achivment");

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(Int16.MaxValue)
                    .HasColumnName("CategoryName");
            });

            modelBuilder.Entity<Dish>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("Id");

                entity.Property(e => e.DishName)
                    .HasMaxLength(Int16.MaxValue)
                    .HasColumnName("DishName");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("Price");
            });

            modelBuilder.Entity<DishDescription>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("Id");

                entity.Property(e => e.Calories).HasColumnName("Calories");

                entity.Property(e => e.Carbohydrates).HasColumnName("Carbohydrates");

                entity.Property(e => e.Fats).HasColumnName("Fats");

                entity.Property(e => e.Protein).HasColumnName("Protein");

                entity.HasOne(d => d.Dish)
                    .WithOne(p => p.DishDescription)
                    .HasForeignKey<DishDescription>(d => d.DishId);
            });

            modelBuilder.Entity<DishCategory>()
                .HasKey(dc => new {dc.CategoryId, dc.DishId});

            modelBuilder.Entity<DishCategory>()
                .HasOne(d => d.Dish)
                .WithMany(d => d.Categories)
                .HasForeignKey(d => d.DishId);

            modelBuilder.Entity<DishCategory>()
                .HasOne(c => c.Category)
                .WithMany(c => c.Dishes)
                .HasForeignKey(c => c.CategoryId);

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("Id");

                entity.Property(e => e.DeliveryDate)
                    .HasColumnType("date")
                    .HasColumnName("DeliveryDate");

                entity.Property(e => e.DishList)
                    .HasMaxLength(Int16.MaxValue)
                    .HasColumnName("DishList");

                entity.Property(e => e.TotalPrice)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("TotalPrice");

                entity.Property(e => e.UserId).HasColumnName("UserId");
            });

            modelBuilder.Entity<OrderDish>()
                .HasKey(dc => new { dc.OrderId, dc.DishId });

            modelBuilder.Entity<OrderDish>()
                .HasOne(d => d.Dish)
                .WithMany(d => d.Orders)
                .HasForeignKey(d => d.DishId);

            modelBuilder.Entity<OrderDish>()
                .HasOne(c => c.Order)
                .WithMany(c => c.Dishes)
                .HasForeignKey(c => c.OrderId);

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Address)
                    .HasMaxLength(Int16.MaxValue)
                    .HasColumnName("Address");

                entity.Property(e => e.Name)
                    .HasMaxLength(Int16.MaxValue)
                    .HasColumnName("Name");

                entity.Property(e => e.Surname)
                    .HasMaxLength(Int16.MaxValue)
                    .HasColumnName("Surname");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
