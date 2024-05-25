using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TNS.PERSISTENCE.ENTITIES;

namespace TNS.PERSISTENCE.CONFIGURATIONS
{
    public partial class EmployeeConfiguration : IEntityTypeConfiguration<EmployeeEntity>
    {
        public void Configure(EntityTypeBuilder<EmployeeEntity> builder)
        {
            builder.HasKey(emp => emp.Id);

            builder
                .HasOne(emp => emp.Position)
                .WithMany(pos => pos.Employees)
                .HasForeignKey(emp => emp.PositionId);
        }
    }

    public partial class EmployeePositionConfiguration : IEntityTypeConfiguration<EmployeePositionEntity>
    {
        public void Configure(EntityTypeBuilder<EmployeePositionEntity> builder)
        {
            builder.HasKey(pos => pos.Id);

            builder
                .HasMany(pos => pos.Employees)
                .WithOne(emp => emp.Position)
                .HasForeignKey(emp => emp.PositionId);
        }
    }
}
