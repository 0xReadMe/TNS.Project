using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TNS.PERSISTENCE.ENTITIES.CRM;

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
    }
}
