using TNS.CORE.VO;

namespace TNS.API.CONTRACTS.EMPLOYEES;

public record Login_POST
(
    string Login,                      // авторизация (номер телефона)
    string Password                 // авторизация (пароль)
);