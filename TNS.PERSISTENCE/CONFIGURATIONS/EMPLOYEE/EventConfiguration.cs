using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TNS.CORE.MODELS.EMPLOYEE;
using TNS.PERSISTENCE.ENTITIES.EMPLOYEE;

namespace TNS.PERSISTENCE.CONFIGURATIONS.EMPLOYEE;

public partial class EventConfiguration : IEntityTypeConfiguration<EventEntity>
{
    public void Configure(EntityTypeBuilder<EventEntity> builder)
    {
        builder.HasKey(events => events.Id);

        builder.HasMany(u => u.Roles)
            .WithMany(r => r.Events)
            .UsingEntity<EventRoleEntity>(
                l => l.HasOne<RoleEntity>().WithMany().HasForeignKey(r => r.RoleId),
                r => r.HasOne<EventEntity>().WithMany().HasForeignKey(u => u.EventId));

        builder.HasData(
            GenerateEvent(DateOnly.FromDateTime(DateTime.Now), "Планерка", new TimeOnly(9, 15)),
            GenerateEvent(DateOnly.FromDateTime(DateTime.Now), "Обед", new TimeOnly(12, 15)),
            GenerateEvent(DateOnly.FromDateTime(DateTime.Now), "Митинг", new TimeOnly(16, 15))
            );
    }

    private static EventEntity GenerateEvent(DateOnly eventDate,
                                       string? eventDescription,
                                       TimeOnly? eventTime)
    {
        Event s = Event.Create(eventDate, eventDescription, eventTime).Value;

        return new EventEntity
        {
           Id = s.Id,
           Date = s.Date,
           Time = s.Time,
           Description = s.Description
        };
    }
}
