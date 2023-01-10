using UrlApp.Data;

using Microsoft.EntityFrameworkCore;
//using UrlApp.Data.Contract;
using UrlApp.Data.Models;
using AutoMapper;
using UrlApp.WebAPI;
using UrlApp.Data.Contract;
using UrlApp.Service.Services;
using UrlApp.Service.Contracts;
//using UrlApp.Service.Contract;
//using UrlApp.Service;



var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IUrlService, UrlService>();
builder.Services.AddScoped<IUrlShortenerService, UrlShortenerService>();
builder.Services.AddScoped<IUrlRepository, UrlRepository>();

var mapperConfig = new MapperConfiguration(mc => {
    mc.AddProfile(new UrlProfile());
});
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

//builder.Services.AddDbContext<UrlDbContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDbContext<UrlDbContext>();
// Add services to the container.
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
