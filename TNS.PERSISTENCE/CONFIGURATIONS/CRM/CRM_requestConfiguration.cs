using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TNS.PERSISTENCE.ENTITIES.CRM;

namespace TNS.PERSISTENCE.CONFIGURATIONS.CRM;

public partial class CRM_requestConfiguration : IEntityTypeConfiguration<CRM_requestEntity>
{
    public void Configure(EntityTypeBuilder<CRM_requestEntity> builder)
    {
        builder.HasKey(CRM => CRM.Id);

        builder
            .HasOne(CRM => CRM.Subscriber)
            .WithMany(Sub => Sub.CRM_RequestEntities)
            .HasForeignKey(CRM => CRM.SubscriberId);

        builder
            .HasOne(CRM => CRM.Service)
            .WithMany(Service => Service.CRM_RequestEntities)
            .HasForeignKey(CRM => CRM.ServiceId);

        builder
            .HasOne(CRM => CRM.ServiceProvided)
            .WithMany(Service => Service.CRM_RequestEntities)
            .HasForeignKey(CRM => CRM.ServiceProvidedId);

        builder
            .HasOne(CRM => CRM.ServiceType)
            .WithMany(Service => Service.CRM_RequestEntities)
            .HasForeignKey(CRM => CRM.ServiceTypeId);
    }
}