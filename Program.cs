using storeManagerDotNet.DTO;
using storeManagerDotNet.Extensions;
using storeManagerDotNet.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddAutoMapper(typeof(StoreManagerProfile));
builder.Services.AddEntityFramework(builder.Configuration);
builder.Services.AddRepositories();
builder.Services.AddServices();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseMiddleware(typeof(GlobalErrorsMiddleware));

app.UseAuthorization();

app.MapControllers();

app.Run();
