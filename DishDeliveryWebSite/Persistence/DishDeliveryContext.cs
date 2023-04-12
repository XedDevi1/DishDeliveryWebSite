using DishDeliveryWebSite.Models;
using Microsoft.EntityFrameworkCore;

namespace DishDeliveryWebSite.Persistence
{
    public partial class DishDeliveryContext : DbContext
    {
        public DishDeliveryContext()
        {
        }

        public DishDeliveryContext(DbContextOptions<DishDeliveryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Dish> Dishes { get; set; } = null!;
        public virtual DbSet<DishDescription> DishDescriptions { get; set; } = null!;
        public virtual DbSet<FoodProduct> FoodProducts { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<Unit> Units { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Achivment)
                    .HasMaxLength(Int16.MaxValue)
                    .HasColumnName("achivment");

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(Int16.MaxValue)
                    .HasColumnName("categoryName");
            });

            modelBuilder.Entity<Dish>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.CategoryId).HasColumnName("categoryId");

                entity.Property(e => e.DishName)
                    .HasMaxLength(Int16.MaxValue)
                    .HasColumnName("dishName");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("price");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Dishes)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_Dishes.categoryId");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Dish)
                    .HasForeignKey<Dish>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Dishes.id");

                entity.HasMany(d => d.FoodProducts)
                    .WithMany(p => p.Dishes)
                    .UsingEntity<Dictionary<string, object>>(
                        "DishesFoodProduct",
                        l => l.HasOne<FoodProduct>().WithMany().HasForeignKey("FoodProductId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_DishesFoodProducts.foodProductId"),
                        r => r.HasOne<Dish>().WithMany().HasForeignKey("DishId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_DishesFoodProducts.dishId"),
                        j =>
                        {
                            j.HasKey("DishId", "FoodProductId").HasName("PK__DishesFo__4FAEFD83985E6EA6");

                            j.ToTable("DishesFoodProducts");

                            j.IndexerProperty<int>("DishId").HasColumnName("dishId");

                            j.IndexerProperty<int>("FoodProductId").HasColumnName("foodProductId");
                        });

                entity.HasMany(d => d.Orders)
                    .WithMany(p => p.Dishes)
                    .UsingEntity<Dictionary<string, object>>(
                        "MenuOrder",
                        l => l.HasOne<Order>().WithMany().HasForeignKey("OrderId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_MenuOrder.orderId"),
                        r => r.HasOne<Dish>().WithMany().HasForeignKey("DishId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_MenuOrder.dishId"),
                        j =>
                        {
                            j.HasKey("DishId", "OrderId").HasName("PK__MenuOrde__B66B6096F1139BAF");

                            j.ToTable("MenuOrder");

                            j.IndexerProperty<int>("DishId").HasColumnName("dishId");

                            j.IndexerProperty<int>("OrderId").HasColumnName("orderId");
                        });
            });

            modelBuilder.Entity<DishDescription>(entity =>
            {
                entity.ToTable("DishDescription");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Calories).HasColumnName("calories");

                entity.Property(e => e.Carbohydrates).HasColumnName("carbohydrates");

                entity.Property(e => e.Fats).HasColumnName("fats");

                entity.Property(e => e.Protein).HasColumnName("protein");
            });

            modelBuilder.Entity<FoodProduct>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(Int16.MaxValue)
                    .HasColumnName("productName");

                entity.Property(e => e.UnitId).HasColumnName("unitId");

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.FoodProducts)
                    .HasForeignKey(d => d.UnitId)
                    .HasConstraintName("FK_FoodProducts.unitId");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DeliveryDate)
                    .HasColumnType("date")
                    .HasColumnName("deliveryDate");

                entity.Property(e => e.DishList)
                    .HasMaxLength(Int16.MaxValue)
                    .HasColumnName("dishList");

                entity.Property(e => e.TotalPrice)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("totalPrice");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Order.userId");
            });

            modelBuilder.Entity<Unit>(entity =>
            {
                entity.ToTable("Unit");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.UnitName)
                    .HasMaxLength(Int16.MaxValue)
                    .HasColumnName("unitName");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasMaxLength(Int16.MaxValue)
                    .HasColumnName("address");

                entity.Property(e => e.Email)
                    .HasMaxLength(Int16.MaxValue)
                    .HasColumnName("email");

                entity.Property(e => e.Name)
                    .HasMaxLength(Int16.MaxValue)
                    .HasColumnName("name");

                entity.Property(e => e.Phone)
                    .HasMaxLength(Int16.MaxValue)
                    .HasColumnName("phone");

                entity.Property(e => e.SurName)
                    .HasMaxLength(Int16.MaxValue)
                    .HasColumnName("surName");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
