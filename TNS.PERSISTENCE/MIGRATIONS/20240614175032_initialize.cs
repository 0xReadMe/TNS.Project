using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TNS.PERSISTENCE.Migrations
{
    /// <inheritdoc />
    public partial class initialize : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BaseStationAddresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    Location = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseStationAddresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FullName = table.Column<string>(type: "text", nullable: false),
                    PhotoId = table.Column<string>(type: "text", nullable: false),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: false),
                    Telegram = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Login = table.Column<string>(type: "text", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Equipments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SerialNumber = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Frequency = table.Column<double>(type: "double precision", nullable: false),
                    AttenuationCoefficient = table.Column<string>(type: "text", nullable: false),
                    DTT = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    IsWorking = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Time = table.Column<TimeOnly>(type: "time without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PermissionEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceProvided",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceProvided", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subscribers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PersonId = table.Column<Guid>(type: "uuid", nullable: false),
                    SubscriberNumber = table.Column<string>(type: "text", nullable: false),
                    ContractNumber = table.Column<string>(type: "text", nullable: false),
                    ContractType = table.Column<bool>(type: "boolean", nullable: false),
                    ReasonForTerminationOfContract = table.Column<string>(type: "text", nullable: false),
                    PersonalBill = table.Column<long>(type: "bigint", nullable: false),
                    Services = table.Column<string>(type: "text", nullable: false),
                    DateOfContractConclusion = table.Column<DateOnly>(type: "date", nullable: false),
                    DateOfTerminationOfTheContract = table.Column<DateOnly>(type: "date", nullable: false),
                    TypeOfEquipment = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscribers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BaseStations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AddressId = table.Column<Guid>(type: "uuid", nullable: false),
                    BaseStationName = table.Column<string>(type: "text", nullable: false),
                    S = table.Column<double>(type: "double precision", nullable: false),
                    Frequency = table.Column<int>(type: "integer", nullable: false),
                    TypeAntenna = table.Column<string>(type: "text", nullable: false),
                    Handover = table.Column<int>(type: "integer", nullable: false),
                    CommunicationProtocol = table.Column<string>(type: "text", nullable: false),
                    IsWorking = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseStations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BaseStations_BaseStationAddresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "BaseStationAddresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeRoleEntity",
                columns: table => new
                {
                    EmployeeId = table.Column<Guid>(type: "uuid", nullable: false),
                    RoleId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeRoleEntity", x => new { x.EmployeeId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_EmployeeRoleEntity_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeRoleEntity_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventRoleEntity",
                columns: table => new
                {
                    EventId = table.Column<Guid>(type: "uuid", nullable: false),
                    RoleId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventRoleEntity", x => new { x.EventId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_EventRoleEntity_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventRoleEntity_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RolePermissionEntity",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "integer", nullable: false),
                    PermissionId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePermissionEntity", x => new { x.RoleId, x.PermissionId });
                    table.ForeignKey(
                        name: "FK_RolePermissionEntity_PermissionEntity_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "PermissionEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolePermissionEntity_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CRM_Requests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SubscriberId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreationDate = table.Column<DateOnly>(type: "date", nullable: false),
                    ClosingDate = table.Column<DateOnly>(type: "date", nullable: false),
                    ServiceId = table.Column<Guid>(type: "uuid", nullable: false),
                    ServiceProvidedId = table.Column<Guid>(type: "uuid", nullable: false),
                    ServiceTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    TypeOfProblem = table.Column<string>(type: "text", nullable: false),
                    ProblemDescription = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CRM_Requests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CRM_Requests_ServiceProvided_ServiceProvidedId",
                        column: x => x.ServiceProvidedId,
                        principalTable: "ServiceProvided",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CRM_Requests_ServiceTypes_ServiceTypeId",
                        column: x => x.ServiceTypeId,
                        principalTable: "ServiceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CRM_Requests_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CRM_Requests_Subscribers_SubscriberId",
                        column: x => x.SubscriberId,
                        principalTable: "Subscribers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SubscriberId = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    MiddleName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Gender = table.Column<char>(type: "character(1)", nullable: false),
                    DOB = table.Column<DateOnly>(type: "date", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    DateOfIssuePassport = table.Column<DateOnly>(type: "date", nullable: false),
                    DivisionCode = table.Column<string>(type: "text", nullable: false),
                    IssuedBy = table.Column<string>(type: "text", nullable: false),
                    Number = table.Column<int>(type: "integer", nullable: false),
                    ResidenceAddress = table.Column<string>(type: "text", nullable: false),
                    ResidentialAddress = table.Column<string>(type: "text", nullable: false),
                    Series = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Persons_Subscribers_SubscriberId",
                        column: x => x.SubscriberId,
                        principalTable: "Subscribers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "BaseStationAddresses",
                columns: new[] { "Id", "Address", "Location" },
                values: new object[,]
                {
                    { new Guid("7700afab-9bbb-4e26-beca-669041206973"), "Коломна, ул. Блохина, д. 9", "Гостинница Советская, в центре города" },
                    { new Guid("f69caf17-3674-4714-804e-c6aa5816f3d4"), "Коломна, Александровский парк, д. 7", "Военно-исторический музей артиллерии, инженерных войск и войск связи" },
                    { new Guid("fd6beaf0-979a-412a-ab16-987428691ea1"), "Коломна, Кронверкский пр., д. 5", "Учебный корпус Колледж Коломна, здание рядом с мечетью" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "DateOfBirth", "Email", "FullName", "Login", "PasswordHash", "PhotoId", "Telegram" },
                values: new object[,]
                {
                    { new Guid("47d97bc9-d872-4c0b-862f-f74c50949d95"), new DateOnly(2003, 12, 12), "yayaya@ya.ru", "Анастасия Игоревна Саппортина", "+79152145255", "5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8", "SorsePhoto\\ProfilePhoto3.jpg", "" },
                    { new Guid("a470a7af-efe1-4a94-b4a9-7929fbf2c800"), new DateOnly(2003, 12, 12), "yayaya@ya.ru", "Вячеслава Админовична Главных", "+79152145253", "5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8", "SorsePhoto\\ProfilePhoto1.jpg", "" },
                    { new Guid("bfcc7c0e-a779-4e8f-806c-d439436a636e"), new DateOnly(2003, 12, 12), "yayaya@ya.ru", "Вячеслав Александрович Мордник", "+79152145252", "5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8", "SorsePhoto\\ProfilePhoto3.jpg", "" },
                    { new Guid("d2d86ee5-698c-412e-b083-5369dcb04195"), new DateOnly(2003, 12, 12), "yayaya@ya.ru", "Ангелина Инженеровна Техническая", "+79152145254", "5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8", "SorsePhoto\\ProfilePhoto2.jpg", "" }
                });

            migrationBuilder.InsertData(
                table: "Equipments",
                columns: new[] { "Id", "Address", "AttenuationCoefficient", "DTT", "Frequency", "IsWorking", "Name", "SerialNumber" },
                values: new object[,]
                {
                    { new Guid("25fa5e47-cccf-4021-a8b0-9fedfb745180"), "Коломна, Депутатская ул., д. 8", "25.5", "Optical Fiber", 10.5, true, "Оптические волоконные усилители", "АО599-ТНС-24" },
                    { new Guid("3521fc29-a257-44d7-9e1e-60fa48810029"), "Коломна, Депутатская ул., д. 8", "12.5", "SHDSL", 50.200000000000003, true, "Агрегирующий транспондер", "АО500-ТНС-24" },
                    { new Guid("5523e143-30d3-4d02-89b1-f617a78ba53c"), "Коломна, Депутатская ул., д. 8", "10.5", "ADSL", 45.5, true, "Транспондер", "АО567-ТНС-24" },
                    { new Guid("7dc62c77-9fc3-4c10-83fe-9632659377f6"), "Коломна, Депутатская ул., д. 8", "0.5", "5G", 235.5, true, "ИРТЫШ", "АО999-ТНС-24" }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Date", "Description", "Time" },
                values: new object[,]
                {
                    { new Guid("2bb4a17c-03a7-4e5d-a463-04c321cee8b0"), new DateOnly(2024, 6, 14), "Обед", new TimeOnly(12, 15, 0) },
                    { new Guid("8d3e588c-45a7-4215-952e-20d6fc17bb9d"), new DateOnly(2024, 6, 14), "Митинг", new TimeOnly(16, 15, 0) },
                    { new Guid("a3ca49fe-476e-4415-88f7-d85dd75a269c"), new DateOnly(2024, 6, 14), "Планерка", new TimeOnly(9, 15, 0) }
                });

            migrationBuilder.InsertData(
                table: "PermissionEntity",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Read" },
                    { 2, "Write" },
                    { 3, "Update" },
                    { 4, "Delete" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "Boss" },
                    { 3, "Engineer" },
                    { 4, "Support" }
                });

            migrationBuilder.InsertData(
                table: "ServiceProvided",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("55f827c5-6f23-44d2-8bcb-c9b0144dd232"), "Диагностика и настройка оборудования/подключения" },
                    { new Guid("5afc7580-de8b-46cc-8313-ab693d57b1ed"), "Оплата услуг" },
                    { new Guid("770716ae-faab-4ba6-b253-005b797e30df"), "Подключение" },
                    { new Guid("7c75e8b2-6f35-4915-b742-57abea58b0d5"), "Управление договором/контактными данными" },
                    { new Guid("fb57e7b8-86ea-4f0a-94cb-97078b69b2f6"), "Управление тарифом/услугой" }
                });

            migrationBuilder.InsertData(
                table: "ServiceTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("24a6d24c-2503-4562-956c-fa8dcda6d81e"), "Низкая скорость соединения" },
                    { new Guid("349c682d-29ee-486c-998a-9a3da0c67688"), "Включение в договор дополнительной услуги" },
                    { new Guid("5104e9d3-1290-44bd-ba5f-47b7860096f8"), "Разрыв соединения" },
                    { new Guid("88b99cc1-9c86-4bc6-93de-3012b2871f7a"), "Изменение тарифа" },
                    { new Guid("8f8702d9-3944-48ee-be10-41bb5a45e8ec"), "Отключение услуги" },
                    { new Guid("b59878dc-85bf-4a9f-a9ba-62d17f54ebfb"), "Получение квитанции на оплату услуги" },
                    { new Guid("bcb77237-d356-46fb-8f47-82e30146abed"), "Изменение контактных данных" },
                    { new Guid("be67f6d1-57de-4004-8135-d0ef610f4ea5"), "Подключение услуг на существующей инфраструктуре" },
                    { new Guid("c8c2a0f5-483c-4fda-bee8-9aa98d47be75"), "Изменение адреса предоставления услуг" },
                    { new Guid("e413fbcf-50e3-41c1-b4d7-b124daf2c7e2"), "Изменение условий договора" },
                    { new Guid("f10a5c7e-f51f-4d17-8165-d24f879e4b9e"), "Выписка по платежам" },
                    { new Guid("f2ff5f07-ab6d-4395-af43-feb0ec121783"), "Нет доступа к услуге" },
                    { new Guid("f718d578-5358-4167-ad41-29b88261aa17"), "Информация о платежах" },
                    { new Guid("fb04ebb4-4a7f-418b-977b-0962e66886ad"), "Приостановка предоставления услуги" },
                    { new Guid("fbcc7b3b-eb7a-43c3-9232-4d9d89dae9ce"), "Подключение услуг с новой инфраструктурой" }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("707bcafd-2dae-4548-9eb1-e9e9f0ae6d29"), "Интернет" },
                    { new Guid("b01114f6-dfd8-43a9-8585-a8e88ba85b89"), "Мобильная связь" },
                    { new Guid("c32e6896-0932-450e-a5a9-d94e6eb68eb5"), "Видеонаблюдение" },
                    { new Guid("fab1b894-fcac-434d-b0f8-daba7955264d"), "Телевидение" }
                });

            migrationBuilder.InsertData(
                table: "Subscribers",
                columns: new[] { "Id", "ContractNumber", "ContractType", "DateOfContractConclusion", "DateOfTerminationOfTheContract", "PersonId", "PersonalBill", "ReasonForTerminationOfContract", "Services", "SubscriberNumber", "TypeOfEquipment" },
                values: new object[,]
                {
                    { new Guid("1337d42d-db5f-4d00-99f7-8736c2766093"), "50-785493418-KOLOMNA-12-2019", false, new DateOnly(2019, 12, 10), new DateOnly(2044, 6, 12), new Guid("00000000-0000-0000-0000-000000000000"), 785493418L, "Истечение срока договора", "Интернет", "50-785493418-KOLOMNA", "Маршрутизатор" },
                    { new Guid("29c2e5b6-f987-4e5b-b843-514ba1b35e47"), "50-785493423-KOLOMNA-03-2010", false, new DateOnly(2010, 3, 27), new DateOnly(2022, 11, 12), new Guid("00000000-0000-0000-0000-000000000000"), 785493423L, "Финансовые трудности", "Мобильная связь", "50-785493423-KOLOMNA", "Телефон" },
                    { new Guid("3435fb5d-978a-4262-a6d0-159bb1b1809c"), "50-785493424-KOLOMNA-01-2020", false, new DateOnly(2020, 1, 12), new DateOnly(2044, 6, 12), new Guid("00000000-0000-0000-0000-000000000000"), 785493424L, "Истечение срока договора", "Мобильная связь", "50-785493424-KOLOMNA", "Планшет" },
                    { new Guid("5271e7df-fb9e-45af-a027-319d85f0f4bc"), "50-785493417-KOLOMNA-11-2018", false, new DateOnly(2018, 11, 12), new DateOnly(2044, 6, 12), new Guid("00000000-0000-0000-0000-000000000000"), 785493417L, "Истечение срока договора", "Интернет", "50-785493417-KOLOMNA", "Маршрутизатор" },
                    { new Guid("539d3153-599e-46d7-b188-2d7e7c96edf3"), "50-785493419-KOLOMNA-11-2014", false, new DateOnly(2014, 11, 5), new DateOnly(2022, 11, 12), new Guid("00000000-0000-0000-0000-000000000000"), 785493419L, "Не указана", "Интернет", "50-785493419-KOLOMNA", "Коммутатор" },
                    { new Guid("9bf4a621-2232-49fd-8658-ff9d4c090027"), "50-785493422-KOLOMNA-07-2013", false, new DateOnly(2013, 7, 5), new DateOnly(2022, 11, 12), new Guid("00000000-0000-0000-0000-000000000000"), 785493422L, "Не указана", "Интернет", "50-785493422-KOLOMNA", "Модем" },
                    { new Guid("a3c6130c-6dda-47e6-94b2-3814c606f4e3"), "50-785493420-KOLOMNA-11-2014", false, new DateOnly(2014, 11, 5), new DateOnly(2022, 11, 12), new Guid("00000000-0000-0000-0000-000000000000"), 785493420L, "Не указана", "Интернет", "50-785493420-KOLOMNA", "Сервер" },
                    { new Guid("e821500f-2a79-41f6-bd70-f216e66255de"), "50-785493424-KOLOMNA-05-2020", false, new DateOnly(2020, 5, 11), new DateOnly(2044, 6, 12), new Guid("00000000-0000-0000-0000-000000000000"), 785493424L, "Истечение срока договора", "Телевидение", "50-785493424-KOLOMNA", "Ноутбук" },
                    { new Guid("f088681a-7da2-4e29-8ef4-bf702ee5adc8"), "50-785493421-KOLOMNA-06-2015", false, new DateOnly(2015, 6, 5), new DateOnly(2023, 5, 12), new Guid("00000000-0000-0000-0000-000000000000"), 785493421L, "Не указана", "Интернет", "50-785493421-KOLOMNA", "Шлюз" },
                    { new Guid("ffec7fb3-5e70-4f8a-98c2-1991125a5acd"), "50-785493424-KOLOMNA-01-2020", false, new DateOnly(2020, 1, 12), new DateOnly(2024, 1, 12), new Guid("00000000-0000-0000-0000-000000000000"), 785493424L, "Нарушение условий договора", "Мобильная связь", "50-785493424-KOLOMNA", "Ноутбук" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BaseStations_AddressId",
                table: "BaseStations",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_CRM_Requests_ServiceId",
                table: "CRM_Requests",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_CRM_Requests_ServiceProvidedId",
                table: "CRM_Requests",
                column: "ServiceProvidedId");

            migrationBuilder.CreateIndex(
                name: "IX_CRM_Requests_ServiceTypeId",
                table: "CRM_Requests",
                column: "ServiceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CRM_Requests_SubscriberId",
                table: "CRM_Requests",
                column: "SubscriberId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeRoleEntity_RoleId",
                table: "EmployeeRoleEntity",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_EventRoleEntity_RoleId",
                table: "EventRoleEntity",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_SubscriberId",
                table: "Persons",
                column: "SubscriberId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissionEntity_PermissionId",
                table: "RolePermissionEntity",
                column: "PermissionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BaseStations");

            migrationBuilder.DropTable(
                name: "CRM_Requests");

            migrationBuilder.DropTable(
                name: "EmployeeRoleEntity");

            migrationBuilder.DropTable(
                name: "Equipments");

            migrationBuilder.DropTable(
                name: "EventRoleEntity");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "RolePermissionEntity");

            migrationBuilder.DropTable(
                name: "BaseStationAddresses");

            migrationBuilder.DropTable(
                name: "ServiceProvided");

            migrationBuilder.DropTable(
                name: "ServiceTypes");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Subscribers");

            migrationBuilder.DropTable(
                name: "PermissionEntity");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
