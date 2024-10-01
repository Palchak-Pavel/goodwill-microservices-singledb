using GoodwillSingledb.Persistence;
using GoodwillSingledb.Application.Common.Mappings;
using GoodwillSingledb.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using GoodwillSingledb.Application;
using System.Reflection;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var host = WebApplication.CreateBuilder(args).Build();
var devCorsPolicy = "devCorsPolicy";
builder.Services.AddAutoMapper(config =>
{
    config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
    config.AddProfile(new AssemblyMappingProfile(typeof(IGoodwillSingleDbContext).Assembly));
});

builder.Services.AddScoped<IGoodwillSingleDbContext, GoodwillSingleDbContext>();

var connectionString = builder.Configuration.GetConnectionString("DbConnection");
builder.Services.AddDbContext<GoodwillSingleDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddAutoMapper(typeof(AssemblyMappingProfile));
builder.Services.AddApplication();
//builder.Services.AddPersistence(Configuration);
builder.Services.AddControllers();
var app = builder.Build();
app.UseRouting();
app.UseHttpsRedirection();
app.MapControllers();
app.UseCors(devCorsPolicy);
host.Run();

