using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.EntityFrameworkCore;
using TNS.API.EXTENSIONS;
using TNS.APPLICATION.SERVICES;
using TNS.CORE.INTERFACES.REPOSITORY;
using TNS.PERSISTENCE;
using TNS.PERSISTENCE.MAPPINGS;
using TNS.PERSISTENCE.REPOSITORIES;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

// Add services to the container.

services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.AddDbContext<TNSDbContext>(options =>
{
    options.UseNpgsql(configuration.GetConnectionString("TNSDbContext"));
});
services.AddScoped<IEmployeeRepository, EmployeeRepository>();
services.AddScoped<EmployeeService>();
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
