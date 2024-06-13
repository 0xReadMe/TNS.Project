using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TNS.CORE.MODELS.CRM;
using TNS.PERSISTENCE.ENTITIES.CRM;

namespace TNS.PERSISTENCE.CONFIGURATIONS.CRM;

public partial class ServiceTypeConfiguration : IEntityTypeConfiguration<ServiceTypeEntity>
{
    public void Configure(EntityTypeBuilder<ServiceTypeEntity> builder)
    {
        builder.HasKey(x => x.Id);

        builder
            .HasMany(Service => Service.CRM_RequestEntities)
            .WithOne(CRM => CRM.ServiceType)
            .HasForeignKey(CRM => CRM.ServiceTypeId);


        builder.HasData(
            GenerateService("Подключение услуг с новой инфраструктурой"),
            GenerateService("Подключение услуг на существующей инфраструктуре"),
            GenerateService("Изменение условий договора"),
            GenerateService("Включение в договор дополнительной услуги"),
            GenerateService("Изменение контактных данных"),
            GenerateService("Изменение тарифа"),
            GenerateService("Изменение адреса предоставления услуг"),
            GenerateService("Отключение услуги"),
            GenerateService("Приостановка предоставления услуги"),
            GenerateService("Нет доступа к услуге"),
            GenerateService("Разрыв соединения"),
            GenerateService("Низкая скорость соединения"),
            GenerateService("Выписка по платежам"),
            GenerateService("Информация о платежах"),
            GenerateService("Получение квитанции на оплату услуги")
            );
    }

    private static ServiceTypeEntity GenerateService(string name)
    {
        ServiceType s = ServiceType.Create(name).Value;

        return new ServiceTypeEntity
        {
            Id = s.Id,
            Name = s.Name,
        };
    }
}
