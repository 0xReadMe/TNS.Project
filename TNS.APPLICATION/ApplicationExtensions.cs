using Microsoft.Extensions.DependencyInjection;
using TNS.APPLICATION.SERVICES.SUBSCRIBER;
using TNS.APPLICATION.SERVICES.EQUIPMENT;
using TNS.APPLICATION.SERVICES.CRM;
using TNS.APPLICATION.SERVICES.EMPLOYEE;

namespace TNS.APPLICATION;

public static class ApplicationExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<BaseStationAddressService>();
        services.AddScoped<BaseStationService>();
        services.AddScoped<CRMService>();
        services.AddScoped<EmployeeService>();
        services.AddScoped<EquipmentService>();
        services.AddScoped<EventService>();
        services.AddScoped<PersonService>();
        services.AddScoped<ServiceService>();
        services.AddScoped<ServiceProvidedService>();
        services.AddScoped<ServiceTypeService>();
        services.AddScoped<SubscriberService>();
        return services;
    }
}
