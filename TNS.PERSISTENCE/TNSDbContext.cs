using Microsoft.EntityFrameworkCore;
using TNS.PERSISTENCE.ENTITIES.EQUIPMENT;
using TNS.PERSISTENCE.ENTITIES.EMPLOYEE;
using TNS.PERSISTENCE.ENTITIES.CRM;
using TNS.PERSISTENCE.ENTITIES.SUBSCRIBER;
using Microsoft.Extensions.Options;
using TNS.PERSISTENCE.CONFIGURATIONS.EMPLOYEE;

namespace TNS.PERSISTENCE;

public class TNSDbContext(DbContextOptions<TNSDbContext> options, IOptions<AuthorizationOptions> authOptions) : DbContext(options)
{
    public DbSet<EmployeeEntity>            Employees           { get; set; }
    public DbSet<BaseStationAddressEntity>  BaseStationAddresses{ get; set; }
    public DbSet<BaseStationEntity>         BaseStations        { get; set; }
    public DbSet<CRM_requestEntity>         CRM_Requests        { get; set; }
    public DbSet<EquipmentEntity>           Equipments          { get; set; }
    public DbSet<EventEntity>               Events              { get; set; }
    public DbSet<PersonEntity>              Persons             { get; set; }
    public DbSet<ServiceEntity>             Services            { get; set; }
    public DbSet<ServiceProvidedEntity>     ServiceProvided     { get; set; }
    public DbSet<ServiceTypeEntity>         ServiceTypes        { get; set; }
    public DbSet<SubscriberEntity>          Subscribers         { get; set; }
    public DbSet<RoleEntity>                Roles               { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TNSDbContext).Assembly);
        modelBuilder.ApplyConfiguration(new RolePermissionConfiguration(authOptions.Value));
    }
}
