using bangazon.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;
using System.Linq;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.Hosting;
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

//ADD CORS
builder.Services.AddCors(options =>
{
	options.AddPolicy(MyAllowSpecificOrigins,
												policy =>
												{
													policy.WithOrigins("http://localhost:3000",
																								"http://localhost:7040")
																								.AllowAnyHeader()
																								.AllowAnyMethod();
												});
});

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

//Add for Cors
app.UseCors(MyAllowSpecificOrigins);

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

//DELETE Product
app.MapDelete("/api/product/{id}", (BangazonDbContext db, int id) =>
{
    Product product = db.Products.SingleOrDefault(o => o.Id == id);
    if (product == null)
    {
        return Results.NotFound();
    }
    db.Products.Remove(product);
    db.SaveChanges();
    return Results.NoContent();

});

app.MapPost("/order", (BangazonDbContext db, Order order) =>
{

    db.Orders.Add(order);
    db.SaveChanges();
    return Results.Created($"/api/categories/product.Id", order);
});

//DELETE Order
app.MapDelete("/api/order/{id}", (BangazonDbContext db, int id) =>
{
    Order order = db.Orders.SingleOrDefault(o => o.Id == id);
    if (order == null)
    {
        return Results.NotFound();
    }
    db.Orders.Remove(order);
    db.SaveChanges();
    return Results.NoContent();

});


//GET Order with Products by OrderId
app.MapGet("/api/order/{id}/products", (BangazonDbContext db, int id) =>
{

    var order = db.Orders.Where(x => x.Id == id).Include(x =>x.Products).FirstOrDefault();

    return order;


});


//GET Product with related order
app.MapGet("/api/product/{id}/orders", (BangazonDbContext db, int id) =>
{
    var product = db.Products.Include(p => p.Orders).FirstOrDefault(p => p.Id == id);
    return product;
});

//Get All products that have orders
app.MapGet("/api/product/orders", (BangazonDbContext db) =>
{
    var product = db.Products.Where(p => p.Orders.Any()).ToList();
    return product;
});

//Get a sellers products that have been ordered
app.MapGet("/api/product/orders/{sellerId}", (BangazonDbContext db, int id ) =>
{
    var product = db.Products.Where(p => p.Orders.Any()).Where(x => x.SellerId == id).ToList();
    return product;
});


//ADD LIST of Products to Order
app.MapPost("/api/order/{id}/addproduct/", (BangazonDbContext db, int id, List<int> productIdsToAdd) =>
{
    var order = db.Orders.FirstOrDefault(o => o.Id == id);
    var productsToAdd = db.Products.Where(p => productIdsToAdd.Contains(p.Id)).ToList();
    try
    {
        if (order.StatusId == 1)
        {
            foreach (var product in productsToAdd)

            {

                order.Products.Add(product);
            }
            db.SaveChanges();
            return Results.Ok(order);

        }
        else
        {
            return Results.BadRequest("Order not in OPEN status - unable to add products");
        }
    }
    catch (NullReferenceException)
    {
        return Results.BadRequest("Invalid OrderId ");
    }
    
});

app.Run();

