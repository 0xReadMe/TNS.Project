using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TNS.PERSISTENCE.ENTITIES;

namespace TNS.PERSISTENCE.CONFIGURATIONS;

public partial class PersonConfiguration : IEntityTypeConfiguration<PersonEntity>
{
    public void Configure(EntityTypeBuilder<PersonEntity> builder)
    {
        builder.HasKey(person => person.Id);

        builder
            .HasOne(person => person.Subscriber)
            .WithOne(sub => sub.Person)
            .HasForeignKey<SubscriberEntity>(sub => sub.PersonId);
    }
}
