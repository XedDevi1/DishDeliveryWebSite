﻿// <auto-generated />
using System;
using DishDeliveryWebSite.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DishDeliveryWebSite.Migrations
{
    [DbContext(typeof(DishDeliveryContext))]
    [Migration("20230424122459_FixedProperties")]
    partial class FixedProperties
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DishDeliveryWebSite.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Achivment")
                        .HasMaxLength(32767)
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("achivment");

                    b.Property<string>("CategoryName")
                        .HasMaxLength(32767)
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("categoryName");

                    b.HasKey("Id");

                    b.ToTable("Category", (string)null);
                });

            modelBuilder.Entity("DishDeliveryWebSite.Models.Dish", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int")
                        .HasColumnName("categoryId");

                    b.Property<string>("DishName")
                        .HasMaxLength(32767)
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("dishName");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(18,0)")
                        .HasColumnName("price");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Dishes");
                });

            modelBuilder.Entity("DishDeliveryWebSite.Models.DishDescription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("Calories")
                        .HasColumnType("int")
                        .HasColumnName("calories");

                    b.Property<int?>("Carbohydrates")
                        .HasColumnType("int")
                        .HasColumnName("carbohydrates");

                    b.Property<int?>("Fats")
                        .HasColumnType("int")
                        .HasColumnName("fats");

                    b.Property<int?>("Protein")
                        .HasColumnType("int")
                        .HasColumnName("protein");

                    b.HasKey("Id");

                    b.ToTable("DishDescription", (string)null);
                });

            modelBuilder.Entity("DishDeliveryWebSite.Models.FoodProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ProductName")
                        .HasMaxLength(32767)
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("productName");

                    b.Property<int?>("UnitId")
                        .HasColumnType("int")
                        .HasColumnName("unitId");

                    b.HasKey("Id");

                    b.HasIndex("UnitId");

                    b.ToTable("FoodProducts");
                });

            modelBuilder.Entity("DishDeliveryWebSite.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("DeliveryDate")
                        .HasColumnType("date")
                        .HasColumnName("deliveryDate");

                    b.Property<string>("DishList")
                        .HasMaxLength(32767)
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("dishList");

                    b.Property<decimal?>("TotalPrice")
                        .HasColumnType("decimal(18,0)")
                        .HasColumnName("totalPrice");

                    b.Property<int?>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("userId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Order", (string)null);
                });

            modelBuilder.Entity("DishDeliveryWebSite.Models.RefreshToken", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "Token");

                    b.ToTable("RefreshTokens");
                });

            modelBuilder.Entity("DishDeliveryWebSite.Models.Unit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("UnitName")
                        .HasMaxLength(32767)
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("unitName");

                    b.HasKey("Id");

                    b.ToTable("Unit", (string)null);
                });

            modelBuilder.Entity("DishDeliveryWebSite.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasMaxLength(32767)
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("address");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .HasMaxLength(32767)
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasMaxLength(32767)
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("surName");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("DishesFoodProduct", b =>
                {
                    b.Property<int>("DishId")
                        .HasColumnType("int")
                        .HasColumnName("dishId");

                    b.Property<int>("FoodProductId")
                        .HasColumnType("int")
                        .HasColumnName("foodProductId");

                    b.HasKey("DishId", "FoodProductId")
                        .HasName("PK__DishesFo__4FAEFD83985E6EA6");

                    b.HasIndex("FoodProductId");

                    b.ToTable("DishesFoodProducts", (string)null);
                });

            modelBuilder.Entity("MenuOrder", b =>
                {
                    b.Property<int>("DishId")
                        .HasColumnType("int")
                        .HasColumnName("dishId");

                    b.Property<int>("OrderId")
                        .HasColumnType("int")
                        .HasColumnName("orderId");

                    b.HasKey("DishId", "OrderId")
                        .HasName("PK__MenuOrde__B66B6096F1139BAF");

                    b.HasIndex("OrderId");

                    b.ToTable("MenuOrder", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("DishDeliveryWebSite.Models.Dish", b =>
                {
                    b.HasOne("DishDeliveryWebSite.Models.Category", "Category")
                        .WithMany("Dishes")
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("FK_Dishes.categoryId");

                    b.HasOne("DishDeliveryWebSite.Models.DishDescription", "IdNavigation")
                        .WithOne("Dish")
                        .HasForeignKey("DishDeliveryWebSite.Models.Dish", "Id")
                        .IsRequired()
                        .HasConstraintName("FK_Dishes.id");

                    b.Navigation("Category");

                    b.Navigation("IdNavigation");
                });

            modelBuilder.Entity("DishDeliveryWebSite.Models.FoodProduct", b =>
                {
                    b.HasOne("DishDeliveryWebSite.Models.Unit", "Unit")
                        .WithMany("FoodProducts")
                        .HasForeignKey("UnitId")
                        .HasConstraintName("FK_FoodProducts.unitId");

                    b.Navigation("Unit");
                });

            modelBuilder.Entity("DishDeliveryWebSite.Models.Order", b =>
                {
                    b.HasOne("DishDeliveryWebSite.Models.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_Order.userId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DishDeliveryWebSite.Models.RefreshToken", b =>
                {
                    b.HasOne("DishDeliveryWebSite.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DishesFoodProduct", b =>
                {
                    b.HasOne("DishDeliveryWebSite.Models.Dish", null)
                        .WithMany()
                        .HasForeignKey("DishId")
                        .IsRequired()
                        .HasConstraintName("FK_DishesFoodProducts.dishId");

                    b.HasOne("DishDeliveryWebSite.Models.FoodProduct", null)
                        .WithMany()
                        .HasForeignKey("FoodProductId")
                        .IsRequired()
                        .HasConstraintName("FK_DishesFoodProducts.foodProductId");
                });

            modelBuilder.Entity("MenuOrder", b =>
                {
                    b.HasOne("DishDeliveryWebSite.Models.Dish", null)
                        .WithMany()
                        .HasForeignKey("DishId")
                        .IsRequired()
                        .HasConstraintName("FK_MenuOrder.dishId");

                    b.HasOne("DishDeliveryWebSite.Models.Order", null)
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .IsRequired()
                        .HasConstraintName("FK_MenuOrder.orderId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("DishDeliveryWebSite.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("DishDeliveryWebSite.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DishDeliveryWebSite.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("DishDeliveryWebSite.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DishDeliveryWebSite.Models.Category", b =>
                {
                    b.Navigation("Dishes");
                });

            modelBuilder.Entity("DishDeliveryWebSite.Models.DishDescription", b =>
                {
                    b.Navigation("Dish")
                        .IsRequired();
                });

            modelBuilder.Entity("DishDeliveryWebSite.Models.Unit", b =>
                {
                    b.Navigation("FoodProducts");
                });

            modelBuilder.Entity("DishDeliveryWebSite.Models.User", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
