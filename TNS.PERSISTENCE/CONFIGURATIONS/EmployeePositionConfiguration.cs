using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TNS.PERSISTENCE.ENTITIES;

namespace TNS.PERSISTENCE.CONFIGURATIONS;

public partial class EmployeePositionConfiguration : IEntityTypeConfiguration<EmployeePositionEntity>
{
    public void Configure(EntityTypeBuilder<EmployeePositionEntity> builder)
    {
        builder.HasKey(pos => pos.Id);

        builder
            .HasMany(pos => pos.Employees)
            .WithOne(emp => emp.Position)
            .HasForeignKey(emp => emp.PositionId);

        builder
            .HasMany(pos => pos.Events)
            .WithMany(events => events.employeePositions);
    }
}