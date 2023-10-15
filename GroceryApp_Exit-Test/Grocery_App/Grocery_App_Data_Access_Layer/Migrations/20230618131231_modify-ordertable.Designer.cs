﻿// <auto-generated />
using System;
using Grocery_App_Data_Access_Layer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Grocery_App_Data_Access_Layer.Migrations
{
    [DbContext(typeof(Grocery_Context))]
    [Migration("20230618131231_modify-ordertable")]
    partial class modifyordertable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Grocery_App_Data_Access_Layer.Entities.CartEntity", b =>
                {
                    b.Property<int>("CartId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CartId"), 1L, 1);

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("RegisterId")
                        .HasColumnType("int");

                    b.HasKey("CartId");

                    b.HasIndex("ProductId");

                    b.HasIndex("RegisterId");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("Grocery_App_Data_Access_Layer.Entities.OrderEntity", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"), 1L, 1);

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ProductEntityProductId")
                        .HasColumnType("int");

                    b.Property<int>("QuantityOfItems")
                        .HasColumnType("int");

                    b.Property<int>("RegisterId")
                        .HasColumnType("int");

                    b.Property<int>("TotalPrice")
                        .HasColumnType("int");

                    b.HasKey("OrderId");

                    b.HasIndex("ProductEntityProductId");

                    b.HasIndex("RegisterId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Grocery_App_Data_Access_Layer.Entities.ProductEntity", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"), 1L, 1);

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Discount")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("Specification")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Grocery_App_Data_Access_Layer.Entities.RegisterEntity", b =>
                {
                    b.Property<int>("RegisterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RegisterId"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("MemberSince")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Phone")
                        .HasColumnType("bigint");

                    b.Property<bool>("isAdmin")
                        .HasColumnType("bit");

                    b.HasKey("RegisterId");

                    b.ToTable("Registers");

                    b.HasData(
                        new
                        {
                            RegisterId = 3,
                            Email = "admin1@gmail.com",
                            MemberSince = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Admin1",
                            Password = "admin1@123456",
                            Phone = 2345678909L,
                            isAdmin = true
                        },
                        new
                        {
                            RegisterId = 4,
                            Email = "admin2@gmail.com",
                            MemberSince = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Admin2",
                            Password = "admin2@123457",
                            Phone = 1234567896L,
                            isAdmin = true
                        },
                        new
                        {
                            RegisterId = 5,
                            Email = "admin3@gmail.com",
                            MemberSince = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Admin3",
                            Password = "admin3@123455",
                            Phone = 1234567896L,
                            isAdmin = true
                        });
                });

            modelBuilder.Entity("Grocery_App_Data_Access_Layer.Entities.ReviewEntity", b =>
                {
                    b.Property<int>("ReviewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReviewId"), 1L, 1);

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<int>("RegisterId")
                        .HasColumnType("int");

                    b.HasKey("ReviewId");

                    b.HasIndex("ProductId");

                    b.HasIndex("RegisterId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("Grocery_App_Data_Access_Layer.Entities.CartEntity", b =>
                {
                    b.HasOne("Grocery_App_Data_Access_Layer.Entities.ProductEntity", "Product")
                        .WithMany("Carts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Grocery_App_Data_Access_Layer.Entities.RegisterEntity", "Register")
                        .WithMany("Carts")
                        .HasForeignKey("RegisterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Register");
                });

            modelBuilder.Entity("Grocery_App_Data_Access_Layer.Entities.OrderEntity", b =>
                {
                    b.HasOne("Grocery_App_Data_Access_Layer.Entities.ProductEntity", null)
                        .WithMany("Orders")
                        .HasForeignKey("ProductEntityProductId");

                    b.HasOne("Grocery_App_Data_Access_Layer.Entities.RegisterEntity", "Register")
                        .WithMany("Orders")
                        .HasForeignKey("RegisterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Register");
                });

            modelBuilder.Entity("Grocery_App_Data_Access_Layer.Entities.ReviewEntity", b =>
                {
                    b.HasOne("Grocery_App_Data_Access_Layer.Entities.ProductEntity", "Product")
                        .WithMany("Reviews")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Grocery_App_Data_Access_Layer.Entities.RegisterEntity", "Register")
                        .WithMany("Reviews")
                        .HasForeignKey("RegisterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Register");
                });

            modelBuilder.Entity("Grocery_App_Data_Access_Layer.Entities.ProductEntity", b =>
                {
                    b.Navigation("Carts");

                    b.Navigation("Orders");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("Grocery_App_Data_Access_Layer.Entities.RegisterEntity", b =>
                {
                    b.Navigation("Carts");

                    b.Navigation("Orders");

                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}
