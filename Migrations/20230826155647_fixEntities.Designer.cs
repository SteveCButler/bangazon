﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using bangazon.Models;

#nullable disable

namespace bangazon.Migrations
{
    [DbContext(typeof(BangazonDbContext))]
    [Migration("20230826155647_fixEntities")]
    partial class fixEntities
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("bangazon.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("StatusId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<int>("User_PaymentId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            OrderDate = new DateTime(2023, 8, 26, 10, 56, 47, 121, DateTimeKind.Local).AddTicks(3007),
                            StatusId = 1,
                            UserId = 1,
                            User_PaymentId = 1
                        },
                        new
                        {
                            Id = 2,
                            OrderDate = new DateTime(2023, 8, 26, 10, 56, 47, 121, DateTimeKind.Local).AddTicks(3044),
                            StatusId = 1,
                            UserId = 2,
                            User_PaymentId = 2
                        });
                });

            modelBuilder.Entity("bangazon.Models.OrderStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("OrderStatuses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Status = "Open"
                        },
                        new
                        {
                            Id = 2,
                            Status = "Closed"
                        },
                        new
                        {
                            Id = 3,
                            Status = "Pending"
                        },
                        new
                        {
                            Id = 4,
                            Status = "Complete"
                        },
                        new
                        {
                            Id = 5,
                            Status = "Canceled"
                        });
                });

            modelBuilder.Entity("bangazon.Models.PaymentType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("PaymentMethod")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("PaymentTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            PaymentMethod = "Visa"
                        },
                        new
                        {
                            Id = 2,
                            PaymentMethod = "Mastercard"
                        },
                        new
                        {
                            Id = 3,
                            PaymentMethod = "Debit card"
                        },
                        new
                        {
                            Id = 4,
                            PaymentMethod = "Gift card"
                        });
                });

            modelBuilder.Entity("bangazon.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ProductDescription")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("ProductPrice")
                        .HasColumnType("numeric");

                    b.Property<int>("ProductTypeId")
                        .HasColumnType("integer");

                    b.Property<int>("SellerId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ProductDescription = "Telecaster guitar",
                            ProductName = "Fender Telecaster",
                            ProductPrice = 850.00m,
                            ProductTypeId = 1,
                            SellerId = 1
                        },
                        new
                        {
                            Id = 2,
                            ProductDescription = "Stratocaster guitar",
                            ProductName = "Fender Stratocaster",
                            ProductPrice = 1050.00m,
                            ProductTypeId = 1,
                            SellerId = 1
                        },
                        new
                        {
                            Id = 3,
                            ProductDescription = "Jazzmaster guitar",
                            ProductName = "Fender Jazzmaster",
                            ProductPrice = 1800.00m,
                            ProductTypeId = 1,
                            SellerId = 1
                        },
                        new
                        {
                            Id = 4,
                            ProductDescription = "4-string Jazz bass guitar",
                            ProductName = "Fender Jazz Bass",
                            ProductPrice = 650.00m,
                            ProductTypeId = 2,
                            SellerId = 1
                        });
                });

            modelBuilder.Entity("bangazon.Models.ProductType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("ProductId")
                        .HasColumnType("integer");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Type = "Guitar"
                        },
                        new
                        {
                            Id = 2,
                            Type = "Bass"
                        },
                        new
                        {
                            Id = 3,
                            Type = "Banjo"
                        },
                        new
                        {
                            Id = 4,
                            Type = "Mandolin"
                        });
                });

            modelBuilder.Entity("bangazon.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("authId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("isSeller")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "1234 South Street",
                            Email = "ssmiles@gmail.com",
                            Name = "Sarah Smile",
                            Phone = "555-222-4444",
                            authId = "",
                            isSeller = false
                        },
                        new
                        {
                            Id = 2,
                            Address = "5432 North Street",
                            Email = "jslim@gmail.com",
                            Name = "Jimmy Slim",
                            Phone = "555-333-4444",
                            authId = "",
                            isSeller = false
                        },
                        new
                        {
                            Id = 3,
                            Address = "1234 East Street",
                            Email = "mmouth@gmail.com",
                            Name = "Mikey Mouth",
                            Phone = "555-444-4444",
                            authId = "",
                            isSeller = false
                        },
                        new
                        {
                            Id = 4,
                            Address = "6789 West Street",
                            Email = "aartsmith@gmail.com",
                            Name = "Andy Artsmith ",
                            Phone = "555-666-4444",
                            authId = "",
                            isSeller = false
                        });
                });

            modelBuilder.Entity("OrderProduct", b =>
                {
                    b.Property<int>("OrdersId")
                        .HasColumnType("integer");

                    b.Property<int>("ProductsId")
                        .HasColumnType("integer");

                    b.HasKey("OrdersId", "ProductsId");

                    b.HasIndex("ProductsId");

                    b.ToTable("OrderProduct");

                    b.HasData(
                        new
                        {
                            OrdersId = 2,
                            ProductsId = 3
                        },
                        new
                        {
                            OrdersId = 2,
                            ProductsId = 4
                        });
                });

            modelBuilder.Entity("PaymentTypeUser", b =>
                {
                    b.Property<int>("PaymentTypesId")
                        .HasColumnType("integer");

                    b.Property<int>("UsersId")
                        .HasColumnType("integer");

                    b.HasKey("PaymentTypesId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("PaymentTypeUser");
                });

            modelBuilder.Entity("bangazon.Models.ProductType", b =>
                {
                    b.HasOne("bangazon.Models.Product", null)
                        .WithMany("ProductTypes")
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("OrderProduct", b =>
                {
                    b.HasOne("bangazon.Models.Order", null)
                        .WithMany()
                        .HasForeignKey("OrdersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("bangazon.Models.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PaymentTypeUser", b =>
                {
                    b.HasOne("bangazon.Models.PaymentType", null)
                        .WithMany()
                        .HasForeignKey("PaymentTypesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("bangazon.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("bangazon.Models.Product", b =>
                {
                    b.Navigation("ProductTypes");
                });
#pragma warning restore 612, 618
        }
    }
}
