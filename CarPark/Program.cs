using CarPark.Models;
using CarPark.Repos;
using CarPark.Repos.Interfaces;
using CarPark.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

var mongoDbSettings = builder.Configuration.GetSection("MongoDbSettings").Get<MongoDbSettings>();
var client = new MongoClient(mongoDbSettings.ConnectionString);
var database = client.GetDatabase(mongoDbSettings.DatabaseName);

builder.Services.AddSingleton<IMongoDatabase>(database);

var weatherForecastAPISettings = builder.Configuration.GetSection("WeatherForecastAPISettings").Get<WeatherForecastAPISettings>();
builder.Services.AddSingleton<WeatherForecastService>(new WeatherForecastService(weatherForecastAPISettings.Key));

builder.Services.AddScoped<ICarRepo, CarRepo>();
builder.Services.AddScoped<IDriverRepo, DriverRepo>();
builder.Services.AddScoped<ITripTicketRepo, TripTicketRepo>();

builder.Services.AddWebOptimizer(p =>
{
    p.MinifyCssFiles();
    p.MinifyJsFiles();
    p.AddJavaScriptBundle("js/bundle.js", "js/first.js", "js/second.js");
    p.AddCssBundle("css/bundle.css", "css/first.css", "css/second.css");
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseWebOptimizer();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.MapGet("/api/GetCars", async ([FromServices] ICarRepo repo, string query = "", int count = 100) =>
{
    var items = await repo.GetAllAsync(
                expression: x => x.Name.ToLower().Contains(query.ToLower()) || x.Make.ToLower().Contains(query.ToLower()),
                limit: count);

    return items;
});

app.MapGet("/api/GetDrivers", async ([FromServices] IDriverRepo repo, string query = "", int count = 100) =>
{
    var items = await repo.GetAllAsync(
                expression: x => x.Name.ToLower().Contains(query.ToLower()),
                limit: count);

    return items;
});

app.Run();
