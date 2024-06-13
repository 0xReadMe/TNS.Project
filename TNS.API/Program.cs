using Microsoft.AspNetCore.CookiePolicy;
using TNS.API.EXTENSIONS;
using TNS.APPLICATION;
using TNS.PERSISTENCE;
using TNS.PERSISTENCE.MAPPINGS;
using TNS.INFRASTRUCTURE;
using Microsoft.AspNetCore.Authorization;


var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

// Add services to the container.

services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();


//services.Configure<JwtOptions>(configuration.GetSection(nameof(JwtOptions)));
services.Configure<TNS.PERSISTENCE.AuthorizationOptions>(configuration.GetSection(nameof(TNS.PERSISTENCE.AuthorizationOptions)));

services
    .AddPersistence(configuration)
    .AddApplication()
    .AddInfrastructure();

services.AddProblemDetails();
services.AddAutoMapper(typeof(DataBaseMappings));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCookiePolicy(new CookiePolicyOptions
{
    MinimumSameSitePolicy = SameSiteMode.Strict,
    HttpOnly = HttpOnlyPolicy.Always,
    Secure = CookieSecurePolicy.Always
});

app.UseHttpsRedirection();
app.UseExceptionHandler();
app.UseAuthentication();
app.UseAuthorization();
app.AddMappedEndpoints();
app.Run();
