using TNS.PERSISTENCE.ENTITIES;
using Microsoft.EntityFrameworkCore;
using TNS.CORE.VO;

namespace TNS.PERSISTENCE
{
    // IOptions<AuthorizationOptions> authOptions
    public class TNSDbContext(
        DbContextOptions<TNSDbContext> options) : DbContext(options)
    {
        public DbSet<EmployeeEntity>            Employees           { get; set; }
        public DbSet<BaseStationAddressEntity>  BaseStationAddresses{ get; set; }
        public DbSet<BaseStationEntity>         BaseStations        { get; set; }
        public DbSet<CRM_requestEntity>         CRM_Requests        { get; set; }
        public DbSet<EmployeePositionEntity>    EmployeePositions   { get; set; }
        public DbSet<EquipmentEntity>           Equipments          { get; set; }
        public DbSet<EventEntity>               Events              { get; set; }
        public DbSet<PersonEntity>              Persons             { get; set; }
        public DbSet<ServiceEntity>             Services            { get; set; }
        public DbSet<ServiceProvidedEntity>     ServiceProvided     { get; set; }
        public DbSet<ServiceTypeEntity>         ServiceTypes        { get; set; }
        public DbSet<SubscriberEntity>          Subscribers         { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TNSDbContext).Assembly);
        }
    }
}
