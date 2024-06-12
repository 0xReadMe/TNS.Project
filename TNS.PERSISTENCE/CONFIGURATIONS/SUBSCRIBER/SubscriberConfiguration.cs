using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TNS.CORE.MODELS.CRM;
using TNS.CORE.MODELS.SUBSCRIBER;
using TNS.PERSISTENCE.ENTITIES.SUBSCRIBER;

namespace TNS.PERSISTENCE.CONFIGURATIONS.SUBSCRIBER;

public partial class SubscriberConfiguration : IEntityTypeConfiguration<SubscriberEntity>
{
    public void Configure(EntityTypeBuilder<SubscriberEntity> builder)
    {
        builder.HasKey(sub => sub.Id);

        builder
            .HasOne(sub => sub.Person)
            .WithOne(person => person.Subscriber)
            .HasForeignKey<PersonEntity>(person => person.SubscriberId);

        builder
            .HasMany(sub => sub.CRM_RequestEntities)
            .WithOne(CRM => CRM.Subscriber)
            .HasForeignKey(CRM => CRM.SubscriberId);

        builder.HasData(
            GenerateSubscriber(new DateOnly(2018, 11, 12), new DateOnly(DateOnly.FromDateTime(DateTime.Now.AddYears(20)).Year, 6, 12),
                                "Истечение срока договора", "Маршрутизатор", "Интернет",
                                false, 785493417),

            GenerateSubscriber(new DateOnly(2019, 12, 10), new DateOnly(DateOnly.FromDateTime(DateTime.Now.AddYears(20)).Year, 6, 12),
                                "Истечение срока договора", "Маршрутизатор", "Интернет",
                                false, 785493418),

            GenerateSubscriber(new DateOnly(2014, 11, 5), new DateOnly(2022, 11, 12),
                                null, "Коммутатор", "Интернет", 
                                false, 785493419),

            GenerateSubscriber(new DateOnly(2014, 11, 5), new DateOnly(2022, 11, 12),
                                null, "Сервер", "Интернет",
                                false, 785493420),

            GenerateSubscriber(new DateOnly(2015, 6, 5), new DateOnly(2023, 5, 12),
                                null, "Шлюз", "Интернет",
                                false, 785493421),

            GenerateSubscriber(new DateOnly(2013, 7, 5), new DateOnly(2022, 11, 12),
                                null, "Модем", "Интернет",
                                false, 785493422),

            GenerateSubscriber(new DateOnly(2010, 3, 27), new DateOnly(2022, 11, 12),
                                "Финансовые трудности", "Телефон", "Мобильная связь",
                                false, 785493423),

            GenerateSubscriber(new DateOnly(2020, 1, 12), new DateOnly(2024, 1, 12),
                                "Нарушение условий договора", "Ноутбук", "Мобильная связь",
                                false, 785493424),

            GenerateSubscriber(new DateOnly(2020, 1, 12), new DateOnly(DateOnly.FromDateTime(DateTime.Now.AddYears(20)).Year, 6, 12),
                                "Истечение срока договора", "Планшет", "Мобильная связь",
                                false, 785493424),

            GenerateSubscriber(new DateOnly(2020, 5, 11), new DateOnly(DateOnly.FromDateTime(DateTime.Now.AddYears(20)).Year, 6, 12),
                                "Истечение срока договора", "Ноутбук", "Телевидение",
                                false, 785493424)
            );
    }

    private static SubscriberEntity GenerateSubscriber(DateOnly dateOfContractConclusion,
                                                DateOnly dateOfTerminationOfTheContract,
                                                string? reasonForTerminationOfContract,
                                                string typeOfEquipment,
                                                string services,
                                                bool contractType,
                                                uint personalBill) 
    {
        Subscriber s = Subscriber.Create(dateOfContractConclusion,
                                                  dateOfTerminationOfTheContract,
                                                  reasonForTerminationOfContract,
                                                  typeOfEquipment,
                                                  services,
                                                  contractType,
                                                  personalBill).Value;
        return new SubscriberEntity
        {
            SubscriberNumber                = s.SubscriberNumber,
            Id                              = s.Id,
            ContractNumber                  = s.ContractNumber,
            DateOfContractConclusion        = s.DateOfContractConclusion,
            DateOfTerminationOfTheContract  = s.DateOfTerminationOfTheContract,
            ContractType                    = s.ContractType,
            ReasonForTerminationOfContract  = s.ReasonForTerminationOfContract,
            PersonalBill                    = s.PersonalBill,
            Services                        = s.Services,
            TypeOfEquipment                 = s.TypeOfEquipment
        };
    }
}