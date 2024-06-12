using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
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
    }
}
