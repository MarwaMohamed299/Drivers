using Drivers.BL.Services.Drivers;
using Drivers.BL.Services.Trips;
using Drivers.DAL.Repositories;
using Drivers.DAL.Repositories.Drivers;
using Drivers.DAL.Repositories.Trips;
using MongoDB.Driver;
using Shared;

var builder = WebApplication.CreateBuilder(args);


builder.Services.Configure<DataBaseSettings>(builder.Configuration.GetSection("MongoDataBase"));

// Register MongoDB client and database as a singleton
builder.Services.AddSingleton<IMongoClient>(sp =>
{
    var settings = builder.Configuration.GetSection("MongoDataBase").Get<DataBaseSettings>();
    return new MongoClient(settings!.ConnectionString);
});

builder.Services.AddScoped(sp =>
{
    var settings = builder.Configuration.GetSection("MongoDataBase").Get<DataBaseSettings>();
    var client = sp.GetRequiredService<IMongoClient>();
    return client.GetDatabase(settings!.DataBaseName); 
});

// Register repositories and services
builder.Services.AddScoped<IDriverRepository, DriverRepository>();
builder.Services.AddScoped<IDriverService, DriverService>();

builder.Services.AddScoped<ITripRepository, TripsRepository>();
builder.Services.AddScoped<ITripsService, TripsService>();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
