using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TNS.PERSISTENCE.ENTITIES.EMPLOYEE;

namespace TNS.PERSISTENCE.CONFIGURATIONS.EMPLOYEE;

public partial class EventRoleEntityConfiguration : IEntityTypeConfiguration<EventRoleEntity>
{
    public void Configure(EntityTypeBuilder<EventRoleEntity> builder)
    {
        builder
            .HasKey(r => new { r.EventId, r.RoleId });
    }
}
