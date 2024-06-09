using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TNS.PERSISTENCE.ENTITIES;

namespace TNS.PERSISTENCE.CONFIGURATIONS;

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
