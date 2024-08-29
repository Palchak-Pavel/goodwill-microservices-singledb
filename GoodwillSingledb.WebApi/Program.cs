using GoodwillSingledb.Persistence;
using GoodwillSingledb.Application.Common.Mappings;
using GoodwillSingledb.Application.Interfaces;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
var host = WebApplication.CreateBuilder(args).Build();
var devCorsPolicy = "devCorsPolicy";
builder.Services.AddCors(options =>
{
    options.AddPolicy(devCorsPolicy, builder => {
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

builder.Services.AddScoped<IGoodwillSingleDbContext, GoodwillSingleDbContext>();
builder.Services.AddAutoMapper(typeof(AssemblyMappingProfile));
//using (var scope = host.Services.CreateScope())
//{
//var serviceProvider = scope.ServiceProvider;
//try
// {
//   var context = serviceProvider.GetRequiredService<GoodwillSingleDbContext>();
//   DbInitializer.Initialize(context);
// }
//  catch (Exception exception)
//  {

//  }
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
//app.MapGet("/", () => "Hello World!");

//app.Run();
