using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace bangazon.Models;


public class BangazonDbContext : DbContext
{
    public DbSet<Order> Orders { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<OrderStatus> OrderStatuses { get; set; }
    public DbSet<PaymentType> PaymentTypes { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductType> ProductTypes { get; set; }

    public DbSet<UserPaymentType> UserPaymentTypes { get; set; }

    public DbSet<ProductOrder> ProductOrders { get; set; }

    public BangazonDbContext(DbContextOptions<BangazonDbContext> context) : base(context)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // seed data with Users
        modelBuilder.Entity<User>().HasData(new User[]
        {
        new User {Id = 1, Name="Sarah Smile", Address="1234 South Street", authId="", Email="ssmiles@gmail.com", Phone="555-222-4444", isSeller=false},
        new User {Id = 2, Name="Jimmy Slim", Address="5432 North Street", authId="", Email="jslim@gmail.com", Phone="555-333-4444", isSeller=false},
        new User {Id = 3, Name="Mikey Mouth", Address="1234 East Street", authId="", Email="mmouth@gmail.com", Phone="555-444-4444", isSeller=false},
        new User {Id = 4, Name="Andy Artsmith ", Address="6789 West Street", authId="", Email="aartsmith@gmail.com", Phone="555-666-4444", isSeller=false}
        });

        // seed data with Order 
        modelBuilder.Entity<Order>().HasData(new Order[]
        {
        new Order {Id = 1, UserId=1, StatusId=1, OrderDate= DateTime.Now, User_PaymentId=1},
        new Order {Id = 2, UserId=2, StatusId=1, OrderDate= DateTime.Now, User_PaymentId=2},
        });

        //seed data with ProductOrder
        modelBuilder.Entity<ProductOrder>().HasData(new ProductOrder[]
        {
        new ProductOrder {Id = 1, OrderId=1, ProductId=1},
        new ProductOrder {Id = 2, OrderId=2, ProductId=2},
        });

        //seed data with OrderStatus
        modelBuilder.Entity<OrderStatus>().HasData(new OrderStatus[]
       {
        new OrderStatus {Id = 1, Status = "Open"},
        new OrderStatus {Id = 2, Status = "Closed"},
        new OrderStatus {Id = 3, Status = "Pending"},
        new OrderStatus {Id = 4, Status = "Complete"},
        new OrderStatus {Id = 5, Status = "Canceled"},

       });

        //seed data with Payment Type
        modelBuilder.Entity<PaymentType>().HasData(new PaymentType[]
       {
        new PaymentType {Id = 1, PaymentMethod = "Visa"},
        new PaymentType {Id = 2, PaymentMethod = "Mastercard"},
        new PaymentType {Id = 3, PaymentMethod = "Debit card"},
        new PaymentType {Id = 4, PaymentMethod = "Gift card"},

       });

        modelBuilder.Entity<UserPaymentType>().HasData(new UserPaymentType[]
     {
        new UserPaymentType {Id = 1, UserId=1, PaymentTypeId=2},
        

     });

        //seed data with Product
        modelBuilder.Entity<Product>().HasData(new Product[]
       {
        new Product {Id = 1, ProductName = "Fender Telecaster", ProductDescription="Telecaster guitar", ProductPrice=850.00M, ProductTypeId=1, SellerId=1},
        new Product {Id = 2, ProductName = "Fender Stratocaster", ProductDescription="Stratocaster guitar", ProductPrice=1050.00M, ProductTypeId=1, SellerId=1},
        new Product {Id = 3, ProductName = "Fender Jazzmaster", ProductDescription="Jazzmaster guitar", ProductPrice=1800.00M, ProductTypeId=1, SellerId=1},
        new Product {Id = 4, ProductName = "Fender Jazz Bass", ProductDescription="4-string Jazz bass guitar", ProductPrice=650.00M, ProductTypeId=2, SellerId=1},

       });

        //seed data with ProductType
        modelBuilder.Entity<ProductType>().HasData(new ProductType[]
       {
        new ProductType {Id = 1, Type="Guitar"},
        new ProductType {Id = 2, Type="Bass"},
        new ProductType {Id = 3, Type="Banjo"},
        new ProductType {Id = 4, Type="Mandolin"},

       });
    }
 

}
