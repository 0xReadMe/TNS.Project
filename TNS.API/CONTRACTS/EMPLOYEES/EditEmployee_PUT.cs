using TNS.CORE.VO;

namespace TNS.API.CONTRACTS.EMPLOYEES;

public record EditEmployee_PUT
(
    int RoleId,
    string      FullName,                       // ФИО сотрудника
    string      Password,                       
    DateOnly    DateOfBirth,                    // дата рождения
    string?     Telegram,                       // telegram
    string      Email,                          // e-mail
    string Login                           // авторизация (номер телефона)
);
