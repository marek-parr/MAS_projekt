﻿// <auto-generated />
using System;
using MAS_projekt;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MAS_projekt.Migrations
{
    [DbContext(typeof(MasDbContext))]
    partial class MasDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MAS_projekt.Models.Orders.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int?>("ShoppingCartId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ShoppingCartId");

                    b.ToTable("Items");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amount = 3,
                            OrderId = 1
                        },
                        new
                        {
                            Id = 2,
                            Amount = 1,
                            OrderId = 1
                        },
                        new
                        {
                            Id = 3,
                            Amount = 3,
                            OrderId = 2
                        });
                });

            modelBuilder.Entity("MAS_projekt.Models.Orders.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CanceledOrRejected")
                        .HasColumnType("datetime2");

                    b.Property<long>("ClientId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<long>("OrderNumber")
                        .HasColumnType("bigint");

                    b.Property<int?>("ReportId")
                        .HasColumnType("int");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("ReportId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ClientId = 1L,
                            Created = new DateTime(2020, 6, 15, 1, 49, 7, 430, DateTimeKind.Local).AddTicks(5480),
                            OrderNumber = 56789L,
                            State = 1
                        },
                        new
                        {
                            Id = 2,
                            ClientId = 1L,
                            Created = new DateTime(2020, 6, 22, 1, 49, 7, 430, DateTimeKind.Local).AddTicks(5480),
                            OrderNumber = 1234567L,
                            State = 0
                        });
                });

            modelBuilder.Entity("MAS_projekt.Models.Orders.Report", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Month")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Reports");
                });

            modelBuilder.Entity("MAS_projekt.Models.Orders.ShoppingCart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("ClientId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ClientId")
                        .IsUnique();

                    b.ToTable("ShoppingCarts");
                });

            modelBuilder.Entity("MAS_projekt.Models.People.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ApartmentNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HouseNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Addresses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            City = "Warszawa",
                            HouseNumber = "1A",
                            PostalCode = "00-001",
                            Street = "Marszałkowska"
                        });
                });

            modelBuilder.Entity("MAS_projekt.Models.People.Client", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<int?>("PreferredAddressId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PersonId")
                        .IsUnique();

                    b.HasIndex("PreferredAddressId");

                    b.ToTable("Clients");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            PersonId = 1
                        });
                });

            modelBuilder.Entity("MAS_projekt.Models.People.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateOfDismissal")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfEmployment")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<double>("Salary")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("PersonId")
                        .IsUnique();

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("MAS_projekt.Models.People.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("People");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AddressId = 1,
                            DateOfBirth = new DateTime(2000, 6, 25, 1, 49, 7, 423, DateTimeKind.Local).AddTicks(5479),
                            Email = "test@test.com",
                            FirstName = "Jan",
                            LastName = "Kowalski",
                            PhoneNumber = "1234567890"
                        });
                });

            modelBuilder.Entity("MAS_projekt.Models.Products.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SupercategoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SupercategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Komputery"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Komputery stacjonarne",
                            SupercategoryId = 1
                        },
                        new
                        {
                            Id = 3,
                            Name = "Laptopy",
                            SupercategoryId = 1
                        });
                });

            modelBuilder.Entity("MAS_projekt.Models.Products.Desktop", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfItemsInStock")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Desktop");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Brand = "DELL",
                            CategoryId = 2,
                            Description = "Komputer stacjonarny DELL Inspiron",
                            Name = "Inspiron",
                            NumberOfItemsInStock = 10,
                            Price = 1399.99,
                            Type = "Biznesowy"
                        });
                });

            modelBuilder.Entity("MAS_projekt.Models.Products.Laptop", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("DisplaySize")
                        .HasColumnType("float");

                    b.Property<int>("MaximumBatteryLife")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfItemsInStock")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Laptop");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            Brand = "Alienware",
                            CategoryId = 3,
                            Description = "Laptoop Alienware Areea 51m",
                            DisplaySize = 17.0,
                            MaximumBatteryLife = 120,
                            Name = "AREA",
                            NumberOfItemsInStock = 15,
                            Price = 7999.9899999999998,
                            Type = "Gamingowy"
                        });
                });

            modelBuilder.Entity("MAS_projekt.Models.Orders.Item", b =>
                {
                    b.HasOne("MAS_projekt.Models.Orders.Order", "Order")
                        .WithMany("Items")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MAS_projekt.Models.Orders.ShoppingCart", null)
                        .WithMany("Items")
                        .HasForeignKey("ShoppingCartId");
                });

            modelBuilder.Entity("MAS_projekt.Models.Orders.Order", b =>
                {
                    b.HasOne("MAS_projekt.Models.People.Client", "Client")
                        .WithMany("Orders")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MAS_projekt.Models.Orders.Report", null)
                        .WithMany("Orders")
                        .HasForeignKey("ReportId");
                });

            modelBuilder.Entity("MAS_projekt.Models.Orders.ShoppingCart", b =>
                {
                    b.HasOne("MAS_projekt.Models.People.Client", "Client")
                        .WithOne("ShoppingCart")
                        .HasForeignKey("MAS_projekt.Models.Orders.ShoppingCart", "ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MAS_projekt.Models.People.Client", b =>
                {
                    b.HasOne("MAS_projekt.Models.People.Person", "Person")
                        .WithOne("Client")
                        .HasForeignKey("MAS_projekt.Models.People.Client", "PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MAS_projekt.Models.People.Address", "PreferredAddress")
                        .WithMany()
                        .HasForeignKey("PreferredAddressId");
                });

            modelBuilder.Entity("MAS_projekt.Models.People.Employee", b =>
                {
                    b.HasOne("MAS_projekt.Models.People.Person", "Person")
                        .WithOne("Employee")
                        .HasForeignKey("MAS_projekt.Models.People.Employee", "PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MAS_projekt.Models.People.Person", b =>
                {
                    b.HasOne("MAS_projekt.Models.People.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MAS_projekt.Models.Products.Category", b =>
                {
                    b.HasOne("MAS_projekt.Models.Products.Category", "Supercategory")
                        .WithMany("Subcategories")
                        .HasForeignKey("SupercategoryId");
                });

            modelBuilder.Entity("MAS_projekt.Models.Products.Desktop", b =>
                {
                    b.HasOne("MAS_projekt.Models.Products.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MAS_projekt.Models.Products.Laptop", b =>
                {
                    b.HasOne("MAS_projekt.Models.Products.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
