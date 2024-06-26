﻿namespace TNS.Front_end.Employee.MODELS;

public record EditEmployee_PUT
(
    string      FullName,                       // ФИО сотрудника
    string      PhotoId,                        // путь к фото
    DateOnly    DateOfBirth,                    // дата рождения
    string?     Telegram,                       // telegram
    string      Email,                          // e-mail
    string Login                           // авторизация (номер телефона)
);
