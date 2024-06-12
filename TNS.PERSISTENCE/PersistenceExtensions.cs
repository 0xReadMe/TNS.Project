using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TNS.CORE.INTERFACES.REPOSITORY.CRM;
using TNS.CORE.INTERFACES.REPOSITORY.EMPLOYEE;
using TNS.CORE.INTERFACES.REPOSITORY.EQUIPMENT;
using TNS.CORE.INTERFACES.REPOSITORY.SUBSCRIBER;
using TNS.PERSISTENCE.REPOSITORIES.CRM;
using TNS.PERSISTENCE.REPOSITORIES.EMPLOYEE;
using TNS.PERSISTENCE.REPOSITORIES.EQUIPMENT;
using TNS.PERSISTENCE.REPOSITORIES.SUBSCRIBER;

namespace TNS.PERSISTENCE;

public static class PersistenceExtensions
{
    public static IServiceCollection AddPersistence(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<TNSDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString(nameof(TNSDbContext)));
        });

        services.AddScoped<IBaseStationAddressRepository, BaseStationAddressRepository>();
        services.AddScoped<IBaseStationRepository, BaseStationRepository>();
        services.AddScoped<ICRMRepository, CRMRepository>();
        services.AddScoped<IEmployeePositionRepository, EmployeePositionRepository>();
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        services.AddScoped<IEquipmentRepository, EquipmentRepository>();
        services.AddScoped<IEventRepository, EventRepository>();
        services.AddScoped<IPersonRepository, PersonRepository>();
        services.AddScoped<IServiceProvidedRepository, ServiceProvidedRepository>();
        services.AddScoped<IServiceTypeRepository, ServiceTypeRepository>();
        services.AddScoped<IServiceRepository, ServiceRepository>();
        services.AddScoped<ISubscriberRepository, SubscriberRepository>();

        return services;
    }
}
