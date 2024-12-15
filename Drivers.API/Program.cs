using Drivers.BL.Services.Drivers;
using Drivers.DAL.Repositories.Drivers;
using Shared;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<DataBaseSettings>(builder.Configuration.GetSection("MongoDataBase"));

builder.Services.AddScoped<IDriverRepository, DriverRepository>();
builder.Services.AddScoped<IDriverService ,DriverService>();


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
