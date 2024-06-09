using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TNS.CORE.VO;
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

        builder
            .Property(person => person.PhoneNumber)
            .HasConversion(phoneNumber => phoneNumber.Number, stringNumber => PhoneNumber.Create(stringNumber).Value);

        builder
            .Property(person => person.Email)
            .HasConversion(email => email.email, stringEmail => Email.Create(stringEmail).Value);

        builder
            .ComplexProperty(person => person.Passport, pass =>
            {
                pass.IsRequired();
                pass.Property(field => field.IssuedBy).HasColumnName("IssuedBy");
                pass.Property(field => field.Series).HasColumnName("Series");
                pass.Property(field => field.DateOfIssueOfPassport).HasColumnName("DateOfIssuePassport");
                pass.Property(field => field.DivisionCode).HasColumnName("DivisionCode");
                pass.Property(field => field.Number).HasColumnName("Number");
                pass.Property(field => field.ResidenceAddress).HasColumnName("ResidenceAddress");
                pass.Property(field => field.ResidentialAddress).HasColumnName("ResidentialAddress");
            });
    }
}
