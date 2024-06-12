using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TNS.PERSISTENCE.ENTITIES.EQUIPMENT;

namespace TNS.PERSISTENCE.CONFIGURATIONS.EQUIPMENT;

public partial class BaseStationConfiguration : IEntityTypeConfiguration<BaseStationEntity>
{
    public void Configure(EntityTypeBuilder<BaseStationEntity> builder)
    {
        builder.HasKey(station => station.Id);

        builder
            .HasOne(station => station.Address)
            .WithMany(address => address.BaseStations)
            .HasForeignKey(station => station.AddressId);
    }
}