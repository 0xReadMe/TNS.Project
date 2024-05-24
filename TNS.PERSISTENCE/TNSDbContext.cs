using TNS.PERSISTENCE.CONFIGURATIONS;
using TNS.PERSISTENCE.ENTITIES;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace TNS.PERSISTENCE
{
    // IOptions<AuthorizationOptions> authOptions
    public class TNSDbContext(
        DbContextOptions<TNSDbContext> options) : DbContext(options)
    {
        public DbSet<EmployeeEntity> Employee {  get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TNSDbContext).Assembly);

            //modelBuilder.ApplyConfiguration(new RolePermissionConfiguration(authOptions.Value));
        }
    }
}
