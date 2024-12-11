using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Mohtawa.Application.Helpers;
using Mohtawa.Domain.Mappers;
using Mohtawa.Infrastructure.Contexts;
using System.Text;

namespace Mohtawa_API.Extensions
{
    public static class ConfigurationExtension
    {
        public static void ConfigureAuthentication(this WebApplicationBuilder builder)
        {
            var jwtTokenConfig = builder.Configuration.GetIdentityConfiguration();

            builder.Services.AddSingleton(jwtTokenConfig);

            builder.Services.AddIdentity<IdentityUser, IdentityRole>()
                    .AddEntityFrameworkStores<LibraryIdentityContext>()
                    .AddRoles<IdentityRole>()
                    .AddDefaultTokenProviders();

            builder.Services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 4;
                options.Password.RequiredUniqueChars = 0;
            });


            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            // Adding Jwt Bearer
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = jwtTokenConfig.Audience,
                    ValidIssuer = jwtTokenConfig.Issuer,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtTokenConfig.Secret))
                };
            });
        }
        public static void ConfigureAutoMapper(this WebApplicationBuilder builder)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MapperProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();

            builder.Services.AddSingleton(mapper);
        }
        public static void ConfigureCorePolicy(this WebApplicationBuilder builder, string defaultApiCorsPolicy)
        {
            var policy = builder.Configuration.GetCorsConfiguration();
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(
                    name: defaultApiCorsPolicy,
                    p =>
                    {
                        p.AllowAnyOrigin()
                         .AllowAnyHeader()
                         .AllowAnyMethod();
                    });
            });
        }


        public static JwtTokenConfig GetIdentityConfiguration(this IConfiguration configuration)
        {
            if (configuration is null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            var identityConfiguration = configuration.GetSection("jwtTokenConfig");

            return identityConfiguration?.Get<JwtTokenConfig>() ?? new JwtTokenConfig();
        }

        public static CorsConfigurationModel GetCorsConfiguration(this IConfiguration configuration)
        {
            if (configuration is null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            var corsConfiguration = configuration.GetSection("Api:Cors");

            return corsConfiguration?.Get<CorsConfigurationModel>() ?? new CorsConfigurationModel();
        }
    }
}
