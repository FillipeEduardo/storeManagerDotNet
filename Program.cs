using Microsoft.EntityFrameworkCore;
using storeManagerDotNet.Data;
using storeManagerDotNet.DTO;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddAutoMapper(typeof(StoreManagerProfile));

var connectionString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<StoreContext>(opt => opt.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

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
