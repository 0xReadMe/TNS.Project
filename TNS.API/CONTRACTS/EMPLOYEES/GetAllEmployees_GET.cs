using TNS.CORE.VO;

namespace TNS.API.CONTRACTS.EMPLOYEES;

public record GetAllEmployees_GET
(
    Guid id,
    string fullName,                   // ФИО сотрудника
    string photoId,                    // путь к фото
    DateOnly dateOfBirth,                // дата рождения
    string? telegram,                   // telegram
    string email,                      // e-mail
    string login,                      // авторизация (номер телефона)
    string passwordHash                // авторизация (пароль)
);
