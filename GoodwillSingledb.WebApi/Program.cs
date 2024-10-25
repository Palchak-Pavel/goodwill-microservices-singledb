using GoodwillSingledb.Application;
using GoodwillSingledb.Persistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddApplication();

builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            // указывает, будет ли валидироваться издатель при валидации токена
            ValidateIssuer = true,
            // строка, представляющая издателя
            ValidIssuer = AuthOptions.ISSUER,
            // будет ли валидироваться потребитель токена
            ValidateAudience = true,
            // установка потребителя токена
            ValidAudience = AuthOptions.Audience,
            // будет ли валидироваться время существования
            ValidateLifetime = true,
            // установка ключа безопасности
            IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
            // валидация ключа безопасности
            ValidateIssuerSigningKey = true,
        };
    });

var app = builder.Build();
app.UseHttpsRedirection();
app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();
app.Run();

public static class HashAlgorithms
{
    public static string GetBySHA512(Encoding encoding, string stringToHash)
    {
        using (var provider = SHA512.Create())
        {
            var buffer = encoding.GetBytes(stringToHash);
            var hashBytes = provider.ComputeHash(buffer);
            var hash = hashBytes.Aggregate(string.Empty, (current, b) => current + $"{b:x2}");
            return hash;
        }
    }
}

public static class AuthOptions
{
    private static readonly string _audience = "~3749#gfhp!3hgg_h8%43fe@wb4yu9h&$f3_2nf43i*03";
    public const string ISSUER = "GoodWill_AuthServer";
    public const int LIFETIME = 360;
    public static string Audience => HashAlgorithms.GetBySHA512(Encoding.UTF8, _audience);
    public static string Secret { get; } = "IxrAjDoa2FqElO7IhrSrUJELhUckePEPVpaePlS_Xaw";
    public static SymmetricSecurityKey GetSymmetricSecurityKey()
    {
        return new SymmetricSecurityKey(Encoding.Unicode.GetBytes(Secret));
    }
}