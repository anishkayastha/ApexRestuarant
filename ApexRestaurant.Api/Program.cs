
using ApexRestaurant.Repository;
using ApexRestaurant.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/* RepositoryModule.Register(builder.Services,
    builder.Configuration.GetConnectionString("DefaultConnection"),  "ApexRestaurant.Api"); */

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
if(string.IsNullOrEmpty(connectionString))
{
    Console.WriteLine("Connection String not found in appsettings.json");
    return;
}
RepositoryModule.Register(builder.Services, connectionString, "ApexRestaurant.Api");

ServicesModule.Register(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();