using bangazon.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// allows passing datetimes without time zone data 
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// allows our api endpoints to access the database through Entity Framework Core
builder.Services.AddNpgsql<BangazonDbContext>(builder.Configuration["BangazonDbConnectionString"]);

// Set the JSON serializer options
builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//Get product types (categories)
app.MapGet("/api/categories", (BangazonDbContext db) =>
{
    return db.ProductTypes.ToList();

});

//create ProductType (category)
app.MapPost("/categories", ( BangazonDbContext db, ProductType productType) =>
{
    db.ProductTypes.Add(productType);
    db.SaveChanges();
    return Results.Created($"/api/categories/productType.Id", productType);
});



//Get user by ID (User profile)  Issue #19
app.MapGet("/api/user/{id}", (BangazonDbContext db, int id) =>
{
    var user = db.Users.Single(x => x.Id == id);
   
    if(user == null)
    {
        return Results.NotFound();
    }
    return Results.Ok(user);

});

//Get ALL Products  Issue #10
app.MapGet("/api/products", (BangazonDbContext db) =>
{
    var products = db.Products.ToList();

    if (products == null)
    {
        return Results.NotFound();
    }
    return Results.Ok(products);

});

// Get Product by ID (product details) Issue #7
app.MapGet("/api/products/{id}", (BangazonDbContext db, int id) =>
{
    var product = db.Products.Single(x => x.Id == id);
    if (product == null)
    {
        return Results.NotFound();
    }
    return Results.Ok(product);

});

//create Product 
app.MapPost("/products", (BangazonDbContext db, Product product) =>
{
    db.Products.Add(product);
    db.SaveChanges();
    return Results.Created($"/api/categories/product.Id", product);
});



//app.MapGet("/order/{id}", (BangazonDbContext db, int id) =>
//{
//    var ordersList = db.ProductOrders.Where(x => x.OrderId == id).ToList();
//    List<Product> products = new List<Product>();
//    foreach (ProductOrder order in ordersList)
//    {
//        products.Add(db.Products.Single(x => x.Id == order.ProductId));
//    }
//    return products;
//});

app.MapGet("/order/{id}", (BangazonDbContext db, int id) =>
{

    var order = db.Orders.Where(x => x.Id == id).Include(x => x.Products).FirstOrDefault();

    //var products = db.ProductOrders
    //    .Where(po => po.OrderId == id)
    //    .SelectMany(po => db.Products.Where(p => p.Id == po.ProductId))
    //    .ToList();

    return order;


});

app.Run();

