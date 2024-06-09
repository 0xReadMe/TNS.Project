using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TNS.CORE.VO;
using TNS.PERSISTENCE.ENTITIES;

namespace TNS.PERSISTENCE.CONFIGURATIONS;

public partial class EmployeeConfiguration : IEntityTypeConfiguration<EmployeeEntity>
{
    public void Configure(EntityTypeBuilder<EmployeeEntity> builder)
    {
        builder.HasKey(emp => emp.Id);

        builder
            .HasOne(emp => emp.Position)
            .WithMany(pos => pos.Employees)
            .HasForeignKey(emp => emp.PositionId);

        builder
            .Property(e => e.Login)
            .HasConversion(v => v.Number, v => PhoneNumber.Create(v).Value);
    }
}