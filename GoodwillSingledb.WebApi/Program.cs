using GoodwillSingledb.Persistence;
using GoodwillSingledb.Application.Common.Mappings;
using GoodwillSingledb.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using GoodwillSingledb.Application;
using System.Reflection;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();


builder.Services.AddApplication();

//TODO: Вопрос №2: почему метод AddApplication тут ты вызывал, а метод AddPersistence нет
builder.Services.AddPersistence(builder.Configuration);

//TODO: Вопрос №3: Если весь маппинг в проекте Application, почему эту конфигурацию не убрать внутрь метода AddApplication?
//builder.Services.AddAutoMapper(typeof(AssemblyMappingProfile));

var app = builder.Build();
app.UseHttpsRedirection();
//app.UseCors(devCorsPolicy);
app.MapControllers();
app.Run();
//var host = WebApplication.CreateBuilder(args).Build();
//var devCorsPolicy = "devCorsPolicy";
// builder.Services.AddAutoMapper(config =>
// {
//     config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
//     config.AddProfile(new AssemblyMappingProfile(typeof(IGoodwillSingleDbContext).Assembly));
// });
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy(devCorsPolicy, builder => {
//        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
//    });
//});

// builder.Services.AddMediatR(cfg =>
// {
//     cfg.RegisterServicesFromAssembly(typeof(GoodwillSingledb.Application.DependencyInjection).Assembly);
// });
//builder.Services.AddMediatR(typeof(GoodwillSingledb.Application.DependencyInjection).Assembly);
//builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
//builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));


//var connectionString = builder.Configuration.GetConnectionString("DbConnection");


//builder.Services.AddPersistence(Configuration);
//builder.Services.AddControllers();

//}


// app.UseEndpoints(endpoints =>
// {
//     endpoints.MapGet("/", async context =>
//     {
//         await context.Response.WriteAsync("Hello World!");
//     });
//     endpoints.MapControllers();
// });

