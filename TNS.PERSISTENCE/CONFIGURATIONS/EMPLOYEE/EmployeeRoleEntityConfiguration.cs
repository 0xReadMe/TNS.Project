using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TNS.PERSISTENCE.ENTITIES.EMPLOYEE;

namespace TNS.PERSISTENCE.CONFIGURATIONS.EMPLOYEE;

public partial class EmployeeRoleEntityConfiguration : IEntityTypeConfiguration<EmployeeRoleEntity>
{
    public void Configure(EntityTypeBuilder<EmployeeRoleEntity> builder)
    {
        builder
            .HasKey(r => new { r.EmployeeId, r.RoleId });
    }
}
