using GoodwillSingledb.Persistence;
using GoodwillSingledb.Application.Common.Mappings;
using GoodwillSingledb.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using GoodwillSingledb.Application;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
var host = WebApplication.CreateBuilder(args).Build();
var devCorsPolicy = "devCorsPolicy";
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy(devCorsPolicy, builder => {
//        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
//    });
//});

builder.Services.AddScoped<IGoodwillSingleDbContext, GoodwillSingleDbContext>();
builder.Services.AddAutoMapper(typeof(AssemblyMappingProfile));
builder.Services.AddApplication();
//builder.Services.AddPersistence(Configuration);
builder.Services.AddControllers();

host.Run();
//}
app.UseHttpsRedirection();
app.UseCors(devCorsPolicy);
app.UseEndpoints(endpoints =>
{
    endpoints.MapGet("/", async context =>
    {
        await context.Response.WriteAsync("Hello World!");
    });
    endpoints.MapControllers();
});

