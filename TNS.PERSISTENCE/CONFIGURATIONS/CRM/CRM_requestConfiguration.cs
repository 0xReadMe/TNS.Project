using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TNS.CORE.MODELS.CRM;
using TNS.CORE.MODELS.EMPLOYEE;
using TNS.CORE.VO;
using TNS.PERSISTENCE.ENTITIES.CRM;
using TNS.PERSISTENCE.ENTITIES.EMPLOYEE;

namespace TNS.PERSISTENCE.CONFIGURATIONS.CRM;

public partial class CRM_requestConfiguration : IEntityTypeConfiguration<CRM_requestEntity>
{
    public void Configure(EntityTypeBuilder<CRM_requestEntity> builder)
    {
        builder.HasKey(CRM => CRM.Id);

        builder
            .HasOne(CRM => CRM.Subscriber)
            .WithMany(Sub => Sub.CRM_RequestEntities)
            .HasForeignKey(CRM => CRM.SubscriberId);

        builder
            .HasOne(CRM => CRM.Service)
            .WithMany(Service => Service.CRM_RequestEntities)
            .HasForeignKey(CRM => CRM.ServiceId);

        builder
            .HasOne(CRM => CRM.ServiceProvided)
            .WithMany(Service => Service.CRM_RequestEntities)
            .HasForeignKey(CRM => CRM.ServiceProvidedId);

        builder
            .HasOne(CRM => CRM.ServiceType)
            .WithMany(Service => Service.CRM_RequestEntities)
            .HasForeignKey(CRM => CRM.ServiceTypeId);

        //builder.HasData(
        //    GenerateCRM(Guid.Parse("d55dbf48-ff58-4d1c-8e3f-5be8cd8943ee"), DateOnly.FromDateTime(DateTime.Now), Guid.Parse("d55dbf48-ff58-4d1c-8e3f-5be8cd8943ee"), Guid.Parse("d55dbf48-ff58-4d1c-8e3f-5be8cd8943ee"), Guid.Parse("d55dbf48-ff58-4d1c-8e3f-5be8cd8943ee"),
        //    "Новая", "Техническое обслуживание", "Описание проблемы", DateOnly.FromDateTime(DateTime.Now).AddDays(7)),
        //    GenerateCRM(Guid.Parse("d55dbf48-ff58-4d1c-8e3f-5be8cd8943ee"), DateOnly.FromDateTime(DateTime.Now), Guid.Parse("d55dbf48-ff58-4d1c-8e3f-5be8cd8943ee"), Guid.Parse("d55dbf48-ff58-4d1c-8e3f-5be8cd8943ee"), Guid.Parse("d55dbf48-ff58-4d1c-8e3f-5be8cd8943ee"),
        //    "Новая", "Консультация", "Описание проблемы", DateOnly.FromDateTime(DateTime.Now).AddDays(3)),
        //    GenerateCRM(Guid.Parse("d55dbf48-ff58-4d1c-8e3f-5be8cd8943ee"), DateOnly.FromDateTime(DateTime.Now), Guid.Parse("d55dbf48-ff58-4d1c-8e3f-5be8cd8943ee"), Guid.Parse("d55dbf48-ff58-4d1c-8e3f-5be8cd8943ee"), Guid.Parse("d55dbf48-ff58-4d1c-8e3f-5be8cd8943ee"),
        //    "Новая", "Техническое обслуживание", "Описание проблемы", DateOnly.FromDateTime(DateTime.Now).AddDays(7)),
        //    GenerateCRM(Guid.Parse("d55dbf48-ff58-4d1c-8e3f-5be8cd8943ee"), DateOnly.FromDateTime(DateTime.Now), Guid.Parse("d55dbf48-ff58-4d1c-8e3f-5be8cd8943ee"), Guid.Parse("d55dbf48-ff58-4d1c-8e3f-5be8cd8943ee"), Guid.Parse("d55dbf48-ff58-4d1c-8e3f-5be8cd8943ee"),
        //    "Новая", "Консультация", "Описание проблемы", DateOnly.FromDateTime(DateTime.Now).AddDays(3))
        //    );
    }

    private static CRM_requestEntity GenerateCRM(Guid subscriberId,
                                             DateOnly creationDate,
                                             Guid serviceId,
                                             Guid serviceProvidedId,
                                             Guid serviceTypeId,
                                             string status,
                                             string typeOfProblem,
                                             string problemDescription,
                                             DateOnly closingDate)
    {
        CRM_request s = CRM_request.Create(subscriberId,
                                             creationDate,
                                             serviceId,
                                             serviceProvidedId,
                                             serviceTypeId,
                                             status,
                                             typeOfProblem,
                                             problemDescription,
                                             closingDate).Value;

        return new CRM_requestEntity
        {
            Id = s.Id,
            SubscriberId = s.SubscriberId,
            CreationDate = s.CreationDate,
            ServiceId = s.ServiceId,
            ServiceProvidedId = s.ServiceProvidedId,
            ServiceTypeId = s.ServiceTypeId,
            Status = s.Status,
            TypeOfProblem = s.TypeOfProblem,
            ProblemDescription = s.ProblemDescription,
            ClosingDate = s.ClosingDate
        };
    }
}