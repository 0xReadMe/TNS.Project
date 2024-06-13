using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TNS.CORE.MODELS.EQUIPMENT;
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

        //builder.HasData(
        //    GenerateBaseStations(Guid.Parse("d55dbf48-ff58-4d1c-8e3f-5be8cd8943ee"), "Циско-280", 280, 1500, "Всенаправленная", 10, "TCP/IP"),
        //    GenerateBaseStations(Guid.Parse("d55dbf48-ff58-4d1c-8e3f-5be8cd8943ee"), "Каска-255", 255, 100, "Направленная", 10, "TELNET"),
        //    GenerateBaseStations(Guid.Parse("d55dbf48-ff58-4d1c-8e3f-5be8cd8943ee"), "ТНС-580", 580, 500, "Бинаправленная", 10, "HTTP")
        //    );
    }

    private static BaseStationEntity GenerateBaseStations(Guid adressId,
                                             string baseStationName,
                                             double S,
                                             int frequency,
                                             string typeAntenna,
                                             int handover,
                                             string communicationProtocol,
                                             bool isWorking)
    {
        BaseStation s = BaseStation.Create(adressId,
                                             baseStationName,
                                             S,
                                             frequency,
                                             typeAntenna,
                                             handover,
                                             communicationProtocol,
                                             isWorking).Value;

        return new BaseStationEntity
        {
            Id = s.Id,
            AddressId = s.AddressId,
            BaseStationName = s.BaseStationName,
            S = s.S,
            Frequency = s.Frequency,
            TypeAntenna = s.TypeAntenna,
            Handover = s.Handover,
            CommunicationProtocol = s.CommunicationProtocol,
            IsWorking = isWorking
        };
    }
}