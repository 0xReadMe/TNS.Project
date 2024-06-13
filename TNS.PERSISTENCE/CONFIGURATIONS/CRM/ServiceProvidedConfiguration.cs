using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TNS.CORE.MODELS.CRM;
using TNS.PERSISTENCE.ENTITIES.CRM;

namespace TNS.PERSISTENCE.CONFIGURATIONS.CRM;

public partial class ServiceProvidedConfiguration : IEntityTypeConfiguration<ServiceProvidedEntity>
{
    public void Configure(EntityTypeBuilder<ServiceProvidedEntity> builder)
    {
        builder.HasKey(x => x.Id);

        builder
            .HasMany(Service => Service.CRM_RequestEntities)
            .WithOne(CRM => CRM.ServiceProvided)
            .HasForeignKey(CRM => CRM.ServiceProvidedId);
              
        
        builder.HasData(
            GenerateService("Подключение"),
            GenerateService("Управление договором/контактными данными"),
            GenerateService("Диагностика и настройка оборудования/подключения"),
            GenerateService("Оплата услуг"),
            GenerateService("Управление тарифом/услугой")
            );
    }

    private static ServiceProvidedEntity GenerateService(string name)
    {
        ServiceProvided s = ServiceProvided.Create(name).Value;

        return new ServiceProvidedEntity
        {
            Id = s.Id,
            Name = s.Name,
        };
    }
}
