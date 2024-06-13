using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TNS.CORE.ENUMS;
using TNS.PERSISTENCE.ENTITIES.EMPLOYEE;

namespace TNS.PERSISTENCE.CONFIGURATIONS.EMPLOYEE;

public partial class RolePermissionConfiguration(AuthorizationOptions authorization) : IEntityTypeConfiguration<RolePermissionEntity>
{
    private readonly AuthorizationOptions _authorization = authorization;

    public void Configure(EntityTypeBuilder<RolePermissionEntity> builder)
    {
        builder.HasKey(r => new { r.RoleId, r.PermissionId });

        var rolePermissions = ParseRolePermissions();
        builder.HasData(rolePermissions);
    }

    private RolePermissionEntity[] ParseRolePermissions()
    {
        return _authorization.RolePermissions
            .SelectMany(rp => rp.Permissions
                .Select(p => new RolePermissionEntity
                {
                    RoleId = (int)Enum.Parse<Role>(rp.Role),
                    PermissionId = (int)Enum.Parse<Permissions>(p)
                }))
                .ToArray();
    }
}
