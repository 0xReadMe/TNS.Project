using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TNS.PERSISTENCE.ENTITIES.EQUIPMENT;

namespace TNS.PERSISTENCE.CONFIGURATIONS.EQUIPMENT;

public partial class BaseStationAddressConfiguration : IEntityTypeConfiguration<BaseStationAddressEntity>
{
    public void Configure(EntityTypeBuilder<BaseStationAddressEntity> builder)
    {
        builder.HasKey(address => address.Id);

        builder
            .HasMany(address => address.BaseStations)
            .WithOne(station => station.Address)
            .HasForeignKey(station => station.AddressId);
    }
}
