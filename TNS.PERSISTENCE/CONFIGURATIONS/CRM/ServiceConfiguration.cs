using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TNS.CORE.MODELS.CRM;
using TNS.CORE.MODELS.EMPLOYEE;
using TNS.PERSISTENCE.ENTITIES.CRM;
using TNS.PERSISTENCE.ENTITIES.EMPLOYEE;

namespace TNS.PERSISTENCE.CONFIGURATIONS.CRM;

public partial class ServiceConfiguration : IEntityTypeConfiguration<ServiceEntity>
{
    public void Configure(EntityTypeBuilder<ServiceEntity> builder)
    {
        builder.HasKey(x => x.Id);

        builder
            .HasMany(Service => Service.CRM_RequestEntities)
            .WithOne(CRM => CRM.Service)
            .HasForeignKey(CRM => CRM.ServiceId);

        builder.HasData(
            GenerateService("Интернет"),
            GenerateService("Мобильная связь"),
            GenerateService("Телевидение"),
            GenerateService("Видеонаблюдение")
            );
    }

    private static ServiceEntity GenerateService(string name)
    {
        Service s = Service.Create(name).Value;

        return new ServiceEntity
        {
            Id = s.Id,
            Name = s.Name,
        };
    }
}
