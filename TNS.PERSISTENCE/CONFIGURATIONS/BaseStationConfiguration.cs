using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TNS.PERSISTENCE.ENTITIES;

namespace TNS.PERSISTENCE.CONFIGURATIONS;

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