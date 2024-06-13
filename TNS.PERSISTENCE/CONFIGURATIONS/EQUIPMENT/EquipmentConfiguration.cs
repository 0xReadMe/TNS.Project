using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TNS.CORE.MODELS.EQUIPMENT;
using TNS.PERSISTENCE.ENTITIES.EQUIPMENT;

namespace TNS.PERSISTENCE.CONFIGURATIONS.EQUIPMENT;

public partial class EquipmentConfiguration : IEntityTypeConfiguration<EquipmentEntity>
{
    public void Configure(EntityTypeBuilder<EquipmentEntity> builder)
    {
        builder.HasKey(equip => equip.Id);

        builder.HasData(
            GenerateEquipment("АО567-ТНС-24", "Транспондер", 45.5, "10.5", "ADSL", "Коломна, Депутатская ул., д. 8", true),
            GenerateEquipment("АО500-ТНС-24", "Агрегирующий транспондер", 50.2, "12.5", "SHDSL", "Коломна, Депутатская ул., д. 8", true),
            GenerateEquipment("АО599-ТНС-24", "Оптические волоконные усилители", 10.5, "25.5", "Optical Fiber", "Коломна, Депутатская ул., д. 8", true),
            GenerateEquipment("АО999-ТНС-24", "ИРТЫШ", 235.5, "0.5", "5G", "Коломна, Депутатская ул., д. 8", true)
            );
    }

    private static EquipmentEntity GenerateEquipment(string serialNumber,
                                                              string name,
                                                              double frequency,
                                                              string attenuationCoefficient,
                                                              string DTT,
                                                              string address,
                                                              bool isWorking)
    {
        Equipment s = Equipment.Create(serialNumber,
                                           name,
                                           frequency,
                                           attenuationCoefficient,
                                           DTT,
                                           address,
                                           isWorking).Value;

        return new EquipmentEntity
        {
            Id = s.Id,
            Name = s.Name,
            SerialNumber = s.SerialNumber,
            Frequency = s.Frequency,
            AttenuationCoefficient = s.AttenuationCoefficient,
            DTT = s.DTT,
            Address = s.Address,
            IsWorking = s.IsWorking
        };
    }
}
