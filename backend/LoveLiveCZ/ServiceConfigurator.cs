using System.Data;
using System.Security.Claims;
using System.Text;
using System.Text.Json.Serialization;
using LoveLiveCZ.DatabaseServices;
using LoveLiveCZ.DatabaseServices.Interfaces;
using LoveLiveCZ.Files;
using LoveLiveCZ.Manager;
using LoveLiveCZ.Models.Database;
using LoveLiveCZ.Utilities.Enums;
using LoveLiveCZ.Validation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Npgsql;

namespace LoveLiveCZ;

public static class ServiceConfigurator
{
    public static WebApplicationBuilder Configure(this WebApplicationBuilder builder)
    {
        builder.ConfigureGeneral();
        builder.ConfigureDatabase();
        builder.ConfigureManagers();
        builder.ConfigureLocalServices();
        return builder;
    }

    private static void ConfigureGeneral(this WebApplicationBuilder builder)
    {
        var configuration = builder.Configuration;

        builder.Services.AddControllers()
            .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

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

        builder.Services.AddAuthorization(options =>
        {
            options.AddPolicy("Developers", policy =>
                policy.RequireClaim(ClaimTypes.Role, 
                    UserRoleType.Developer.ToString()));

            options.AddPolicy("Moderators", policy =>
                policy.RequireClaim(ClaimTypes.Role,
                    UserRoleType.Developer.ToString(),
                    UserRoleType.Moderator.ToString()));
        });

        builder.Services.AddMvc();
    }

    private static void ConfigureDatabase(this WebApplicationBuilder builder)
    {
        var configuration = builder.Configuration;
        var databaseConnectionString = configuration.GetConnectionString("PostgreSQL");

        builder.Services.AddDbContext<LoveLiveCzDatabaseContext>(options =>
        {
            options.UseNpgsql(databaseConnectionString);
            options.UseNpgsql(x => x.MigrationsAssembly("LoveLiveCZ"));
        });

        builder.Services.AddScoped<IDbConnection>(_ => new NpgsqlConnection(databaseConnectionString));
        builder.Services.AddScoped<Func<IDbConnection>>(_ => () => new NpgsqlConnection(databaseConnectionString));

        builder.Services.AddScoped<IPostDatabaseService, PostDatabaseService>();
        builder.Services.AddScoped<IUserDatabaseService, UserDatabaseService>();
        builder.Services.AddScoped<IAttachmentDatabaseService, AttachmentDatabaseService>();
    }

    private static void ConfigureManagers(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<PostManager>();
        builder.Services.AddScoped<UserManager>();
        builder.Services.AddScoped<AttachmentManager>();
    }

    private static void ConfigureLocalServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<ImageFileVerifier>();
        builder.Services.AddSingleton<Validator>();
    }
}