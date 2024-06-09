using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TNS.PERSISTENCE.ENTITIES;

namespace TNS.PERSISTENCE.CONFIGURATIONS;

public partial class ServiceProvidedConfiguration : IEntityTypeConfiguration<ServiceProvidedEntity>
{
    public void Configure(EntityTypeBuilder<ServiceProvidedEntity> builder)
    {
        builder.HasKey(x => x.Id);

        builder
            .HasMany(Service => Service.CRM_RequestEntities)
            .WithOne(CRM => CRM.ServiceProvided)
            .HasForeignKey(CRM => CRM.ServiceProvidedId);
    }
}
