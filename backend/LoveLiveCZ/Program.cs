using System.Data;
using System.Text;
using System.Text.Json.Serialization;
using LoveLiveCZ.DatabaseServices;
using LoveLiveCZ.DatabaseServices.Interfaces;
using LoveLiveCZ.Files;
using LoveLiveCZ.Manager;
using LoveLiveCZ.Models.Database;
using LoveLiveCZ.Validation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
// Add services to the container.
builder.Services.AddControllers()
    .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var databaseConnectionString = configuration.GetConnectionString("PostgreSQL");
builder.Services.AddScoped<IDbConnection>(_ => new NpgsqlConnection(databaseConnectionString));
builder.Services.AddScoped<Func<IDbConnection>>(_ => () => new NpgsqlConnection(databaseConnectionString));
builder.Services.AddDbContext<LoveLiveCZDatabaseContext>(options =>
{
    options.UseNpgsql(databaseConnectionString);
    options.UseNpgsql(x => x.MigrationsAssembly("LoveLiveCZ"));
});

builder.Services.AddScoped<PostManager>();
builder.Services.AddScoped<UserManager>();
builder.Services.AddScoped<AttachmentManager>();
builder.Services.AddScoped<IPostDatabaseService, PostDatabaseService>();
builder.Services.AddScoped<IUserDatabaseService, UserDatabaseService>();
builder.Services.AddScoped<IAttachmentDatabaseService, AttachmentDatabaseService>();

builder.Services.AddSingleton<ImageFileVerifier>();
builder.Services.AddSingleton<Validator>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(x =>
    {
        x.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = configuration["Jwt:Issuer"],
            ValidAudience = configuration["Jwt:Issuer"],
            IssuerSigningKey =
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(configuration["Jwt:Key"] ?? throw new InvalidOperationException()))
        };
    });

builder.Services.AddAuthorization();

builder.Services.AddMvc();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Migrate latest database changes during startup
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider
        .GetRequiredService<LoveLiveCZDatabaseContext>();

    // Here is the migration executed
    dbContext.Database.Migrate();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();