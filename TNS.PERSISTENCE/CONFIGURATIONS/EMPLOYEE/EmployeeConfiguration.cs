using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TNS.CORE.MODELS.EMPLOYEE;
using TNS.CORE.VO;
using TNS.PERSISTENCE.ENTITIES.EMPLOYEE;

namespace TNS.PERSISTENCE.CONFIGURATIONS.EMPLOYEE;

public partial class EmployeeConfiguration : IEntityTypeConfiguration<EmployeeEntity>
{
    public void Configure(EntityTypeBuilder<EmployeeEntity> builder)
    {
        builder.HasKey(emp => emp.Id);

        builder.HasMany(u => u.Roles)
            .WithMany(r => r.Employees)
            .UsingEntity<EmployeeRoleEntity>(
                l => l.HasOne<RoleEntity>().WithMany().HasForeignKey(r => r.RoleId),
                r => r.HasOne<EmployeeEntity>().WithMany().HasForeignKey(u => u.EmployeeId));

        builder
            .Property(e => e.Login)
            .HasConversion(v => v.Number, v => PhoneNumber.Create(v).Value);

        builder
            .Property(person => person.Email)
            .HasConversion(email => email.email, stringEmail => Email.Create(stringEmail).Value);

        builder.HasData(
            GenerateEmployee("Вячеслав Александрович Мордник", "SorsePhoto\\ProfilePhoto3.jpg", "@boss", new DateOnly(2003, 12, 12), 
            Email.Create("yayaya@ya.ru").Value, PhoneNumber.Create("+79152145252").Value, "5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8"),
            GenerateEmployee("Вячеслава Админовична Главных", "SorsePhoto\\ProfilePhoto1.jpg", "@admin", new DateOnly(2003, 12, 12),
            Email.Create("yayaya@ya.ru").Value, PhoneNumber.Create("+79152145253").Value, "5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8"),
            GenerateEmployee("Ангелина Инженеровна Техническая", "SorsePhoto\\ProfilePhoto2.jpg", "@engineer", new DateOnly(2003, 12, 12),
            Email.Create("yayaya@ya.ru").Value, PhoneNumber.Create("+79152145254").Value, "5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8"),
            GenerateEmployee("Анастасия Игоревна Саппортина", "SorsePhoto\\ProfilePhoto3.jpg", "@support", new DateOnly(2003, 12, 12),
            Email.Create("yayaya@ya.ru").Value, PhoneNumber.Create("+79152145255").Value, "5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8")
            );
    }

    private static EmployeeEntity GenerateEmployee(string fullName,
                                                   string? photoId,
                                                   string? telegram,
                                                   DateOnly DOB,
                                                   Email email,
                                                   PhoneNumber login,
                                                   string passwordHash)
    {
        Employee s = Employee.Create(
            fullName,
            photoId,
            telegram,
            DOB,
            email,
            login,
            passwordHash).Value;

        return new EmployeeEntity
        {
            Id = s.Id,
            FullName = s.FullName,
            PhotoId = s.PhotoId,
            DateOfBirth = s.DateOfBirth,
            Email = s.Email,
            Login = s.Login,
            PasswordHash = s.PasswordHash,
            Telegram = s.Telegram
        };
    }
}