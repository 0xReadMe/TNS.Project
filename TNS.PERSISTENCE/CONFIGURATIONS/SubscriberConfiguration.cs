using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TNS.PERSISTENCE.ENTITIES;

namespace TNS.PERSISTENCE.CONFIGURATIONS;

public partial class SubscriberConfiguration : IEntityTypeConfiguration<SubscriberEntity>
{
    public void Configure(EntityTypeBuilder<SubscriberEntity> builder)
    {
        builder.HasKey(sub => sub.Id);

        builder
            .HasOne(sub => sub.Person)
            .WithOne(person => person.Subscriber)
            .HasForeignKey<PersonEntity>(person => person.SubscriberId);

        builder
            .HasMany(sub => sub.CRM_RequestEntities)
            .WithOne(CRM => CRM.Subscriber)
            .HasForeignKey(CRM => CRM.SubscriberId);
    }
}