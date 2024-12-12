using Serilog;
using Mohtawa.Application;
using Mohtawa.Infrastructure;
using Mohtawa_API.Extensions;
using Mohtawa_API.Middlewares;
using Bonluck.Application.Helpers;
using Mohtawa.Domain.Contracts;
using Microsoft.AspNetCore.Builder;


var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog((hostingContext, loggerConfiguration) => loggerConfiguration.ReadFrom.Configuration(hostingContext.Configuration));
var configuration = builder.Configuration;
string DefaultCorsPolicy = "DefaultCorsPolicy";


builder.Services
    .AddApplication()
    .AddInfrastructure(configuration.GetConnectionString("ConnectionString"));


// auto mappper configuration
builder.ConfigureAutoMapper();

//identity configuration
builder.ConfigureAuthentication();

// core Policy configuration
builder.ConfigureCorePolicy(DefaultCorsPolicy);

builder.Services.AddSingleton<IResponseHelper, ResponseHelper>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseRouting();


app.UseCors(DefaultCorsPolicy);


app.UseHttpsRedirection();


app.UseAuthorization();
app.UseAuthentication();


app.UseMiddleware<InterceptorMiddleware>();
app.MapControllers();

app.Run();
