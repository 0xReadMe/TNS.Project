using TNS.CORE.VO;

namespace TNS.API.CONTRACTS.EMPLOYEES;

public record GetAllEmployees_GET
(
    Guid Id,
    int RoleId,
    string FullName,                   // ФИО сотрудника
    string PhotoId,                    // путь к фото
    DateOnly DateOfBirth,                // дата рождения
    string? Telegram,                   // telegram
    string Email,                      // e-mail
    string Login,                      // авторизация (номер телефона)
    string PasswordHash                // авторизация (пароль)
);
