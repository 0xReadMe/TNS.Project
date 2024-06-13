using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TNS.CORE.MODELS.EMPLOYEE;
using TNS.CORE.MODELS.EQUIPMENT;
using TNS.CORE.VO;
using TNS.PERSISTENCE.ENTITIES.EMPLOYEE;
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

        builder.HasData(
            GenerateBaseStationAddress("Коломна, Кронверкский пр., д. 5", "Учебный корпус Колледж Коломна, здание рядом с мечетью"),
            GenerateBaseStationAddress("Коломна, ул. Блохина, д. 9", "Гостинница Советская, в центре города"),
            GenerateBaseStationAddress("Коломна, Александровский парк, д. 7", "Военно-исторический музей артиллерии, инженерных войск и войск связи")
            );
    }

    private static BaseStationAddressEntity GenerateBaseStationAddress(string address, string location)
    {
        BaseStationAddress s = BaseStationAddress.Create(address, location).Value;

        return new BaseStationAddressEntity
        {
            Id = s.Id,
            Address = s.Address,
            Location = s.Location
        };
    }
}
