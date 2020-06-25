using Microsoft.EntityFrameworkCore;
using MAS_projekt.Models.Orders;
using MAS_projekt.Models.People;
using MAS_projekt.Models.Products;
using System;
using System.Linq;
using System.Configuration;
using System.Collections.Generic;

namespace MAS_projekt
{
    

    public class MasDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"data source=(LocalDb)\MSSQLLocalDB;initial catalog=MAS_projekt.Model;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var address1 = new Address
            {
                Id = 1,
                Street = "Marsza³kowska",
                HouseNumber = "1A",
                City = "Warszawa",
                PostalCode = "00-001"
            };
            var address2 = new Address
            {
                Id = 2,
                Street = "Z³ota",
                HouseNumber = "44",
                City = "Warszawa",
                PostalCode = "00-001"
            };
            modelBuilder.Entity<Address>().HasData(address1, address2);

            var person1 =
                new Person
                {
                    FirstName = "Jan",
                    LastName = "Kowalski",
                    DateOfBirth = DateTime.Now.AddYears(-20),
                    PhoneNumber = "1234567890",
                    Email = "test@test.com",
                    AddressId = 1,
                    Id = 1
                };
            var person2 =
                new Person
                {
                    FirstName = "Anna",
                    LastName = "Nowak",
                    DateOfBirth = DateTime.Now.AddYears(-18),
                    PhoneNumber = "675849321",
                    Email = "anna@nowak.com",
                    AddressId = 2,
                    Id = 2
                };
            modelBuilder.Entity<Person>().HasData(person1, person2);

            var client1 = new Client
            {
                Id = 1L,
                PersonId = 1
            };
            var client2 = new Client
            {
                Id = 2L,
                PersonId = 2
            };
            modelBuilder.Entity<Client>().HasData(client1, client2);

            var category1 = new Category
            {
                Id = 1,
                Name = "Komputery"
            };
            var category2 = new Category
            {
                Id = 2,
                Name = "Komputery stacjonarne",
                SupercategoryId = 1
            };
            var category3 = new Category
            {
                Id = 3,
                Name = "Laptopy",
                SupercategoryId = 1
            };
            modelBuilder.Entity<Category>().HasData(category1, category2, category3);

            var product1 = new Desktop()
            {
                Id = 1,
                CategoryId = 2,
                Name = "Inspiron",
                Brand = "DELL",
                Description = "Komputer stacjonarny DELL Inspiron",
                NumberOfItemsInStock = 10,
                Price = 1399.99,
                Type = "Biznesowy"
            };
            var product2 = new Laptop()
            {
                Id = 2,
                CategoryId = 3,
                Name = "AREA",
                Brand = "Alienware",
                Description = "Laptoop Alienware Areea 51m",
                NumberOfItemsInStock = 15,
                Price = 7999.99,
                Type = "Gamingowy",
                DisplaySize = 17.0,
                MaximumBatteryLife = 120,
            };
            modelBuilder.Entity<Desktop>().HasData(product1);
            modelBuilder.Entity<Laptop>().HasData(product2);

            var item1 = new Item()
            {
                Id = 1,
                ProductId = 2,
                Amount = 3,
                OrderId = 1
            };
            var item2 = new Item()
            {
                Id = 2,
                ProductId = 1,
                Amount = 1,
                OrderId = 1
            };
            var item3 = new Item()
            {
                Id = 3,
                ProductId = 1,
                Amount = 3,
                OrderId = 2
            };
            var item4 = new Item()
            {
                Id = 4,
                ProductId = 1,
                Amount = 2,
                OrderId = 3
            };
            var item5 = new Item()
            {
                Id = 5,
                ProductId = 2,
                Amount = 1,
                OrderId = 3
            };
            modelBuilder.Entity<Item>().HasData(item1, item2, item3, item4, item5);

            var order1 = new 
            {
                Id = 1,
                ClientId = 1L,
                Created = DateTime.Now.AddDays(-10),
                OrderNumber = 56789L,
                State = OrderState.IN_PROGRESS
            };
            var order2 = new 
            {
                Id = 2,
                ClientId = 1L,
                Created = DateTime.Now.AddDays(-3),
                OrderNumber = 1234567L,
                State = OrderState.CREATED
            };
            var order3 = new
            {
                Id = 3,
                ClientId = 2L,
                Created = DateTime.Now.AddDays(-17),
                OrderNumber = 78525345L,
                State = OrderState.IN_PROGRESS
            };
            modelBuilder.Entity<Order>().HasData(order1, order2, order3);
        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Report> Reports { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
    }
}