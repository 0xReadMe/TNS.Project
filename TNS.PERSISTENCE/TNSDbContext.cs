using TNS.PERSISTENCE.ENTITIES;
using Microsoft.EntityFrameworkCore;
using TNS.CORE.VO;

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

            //modelBuilder.Entity<EmployeeEntity>().Property(e => e.Login).HasColumnType("nvarchar(24)");

            modelBuilder
                .Entity<EmployeeEntity>()
                .Property(e => e.Login)
                .HasConversion(
                                v => v.Number,
                                v => PhoneNumber.Create(v).Value
                                );

            //modelBuilder.ApplyConfiguration(new RolePermissionConfiguration(authOptions.Value));
        }
    }
}
