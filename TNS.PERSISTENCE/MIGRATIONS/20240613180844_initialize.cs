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
                    Address = table.Column<string>(type: "text", nullable: false)
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
                    CommunicationProtocol = table.Column<string>(type: "text", nullable: false)
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
                    { new Guid("122581f5-b3ed-4d5c-b7bc-9e7a9507d386"), "Коломна, Александровский парк, д. 7", "Военно-исторический музей артиллерии, инженерных войск и войск связи" },
                    { new Guid("660bea47-cda6-4ee7-a044-1df5305bf360"), "Коломна, Кронверкский пр., д. 5", "Учебный корпус Колледж Коломна, здание рядом с мечетью" },
                    { new Guid("c2c3ffce-e82c-47c6-8c8a-f76fa3b12aa6"), "Коломна, ул. Блохина, д. 9", "Гостинница Советская, в центре города" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "DateOfBirth", "Email", "FullName", "Login", "PasswordHash", "PhotoId", "Telegram" },
                values: new object[,]
                {
                    { new Guid("173eb815-fd0d-43eb-a3cf-7c3ce671ce16"), new DateOnly(2003, 12, 12), "yayaya@ya.ru", "Анастасия Игоревна Саппортина", "+79152145255", "5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8", "SorsePhoto\\ProfilePhoto3.jpg", "" },
                    { new Guid("9d4166a8-5efa-4e40-bda7-e2d0000091c0"), new DateOnly(2003, 12, 12), "yayaya@ya.ru", "Ангелина Инженеровна Техническая", "+79152145254", "5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8", "SorsePhoto\\ProfilePhoto2.jpg", "" },
                    { new Guid("e01cd101-4535-4b2d-9766-74ee7fea637b"), new DateOnly(2003, 12, 12), "yayaya@ya.ru", "Вячеслава Админовична Главных", "+79152145253", "5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8", "SorsePhoto\\ProfilePhoto1.jpg", "" },
                    { new Guid("e6b96d54-45ad-4a20-898f-74cd2f6ea11d"), new DateOnly(2003, 12, 12), "yayaya@ya.ru", "Вячеслав Александрович Мордник", "+79152145252", "5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8", "SorsePhoto\\ProfilePhoto3.jpg", "" }
                });

            migrationBuilder.InsertData(
                table: "Equipments",
                columns: new[] { "Id", "Address", "AttenuationCoefficient", "DTT", "Frequency", "Name", "SerialNumber" },
                values: new object[,]
                {
                    { new Guid("03109b32-9650-4551-bfa5-e94248aba625"), "Коломна, Депутатская ул., д. 8", "10.5", "ADSL", 45.5, "Транспондер", "АО567-ТНС-24" },
                    { new Guid("0e82f982-aeb3-4899-ba87-8f2f26a1ef86"), "Коломна, Депутатская ул., д. 8", "25.5", "Optical Fiber", 10.5, "Оптические волоконные усилители", "АО599-ТНС-24" },
                    { new Guid("d635f4e4-2dd7-430b-88bb-33bd777ac423"), "Коломна, Депутатская ул., д. 8", "0.5", "5G", 235.5, "ИРТЫШ", "АО999-ТНС-24" },
                    { new Guid("dadf153a-09d6-49e9-ac35-50d5c4d279dc"), "Коломна, Депутатская ул., д. 8", "12.5", "SHDSL", 50.200000000000003, "Агрегирующий транспондер", "АО500-ТНС-24" }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Date", "Description", "Time" },
                values: new object[,]
                {
                    { new Guid("4d9139fc-e491-4477-bf6e-8dc600f2b97e"), new DateOnly(2024, 6, 13), "Митинг", new TimeOnly(16, 15, 0) },
                    { new Guid("7e2b526a-caf3-48c7-8ab1-f1e3855b77b6"), new DateOnly(2024, 6, 13), "Планерка", new TimeOnly(9, 15, 0) },
                    { new Guid("f805297f-f3a8-4cf8-b9fd-95cf02503584"), new DateOnly(2024, 6, 13), "Обед", new TimeOnly(12, 15, 0) }
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
                    { new Guid("28d8b7d0-d667-4ddf-b8c6-98f620df1a95"), "Управление договором/контактными данными" },
                    { new Guid("394e0598-a74f-4cf0-80f4-4b8018b6caf9"), "Диагностика и настройка оборудования/подключения" },
                    { new Guid("3de0f547-a34d-4d08-99b4-23dca8391d23"), "Оплата услуг" },
                    { new Guid("ce46f275-60a2-4369-873f-6ecf3ed42f26"), "Подключение" },
                    { new Guid("f6a636a3-2d9a-483e-bb24-d957f8c51c11"), "Управление тарифом/услугой" }
                });

            migrationBuilder.InsertData(
                table: "ServiceTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("048e7593-97f0-488d-9819-3b0b3e0e9a20"), "Изменение контактных данных" },
                    { new Guid("1729071b-88d9-456d-bc80-4d29fd0fa7dd"), "Получение квитанции на оплату услуги" },
                    { new Guid("173ceffb-0b6b-4d17-9443-271523578a76"), "Нет доступа к услуге" },
                    { new Guid("3b812b26-3a88-4971-8a7f-1b88c2bfeec7"), "Изменение условий договора" },
                    { new Guid("4c03f2d2-7661-4b56-97ff-7e1c53b4568e"), "Выписка по платежам" },
                    { new Guid("742dd3c2-31e0-4948-8b18-7b028364d2c3"), "Включение в договор дополнительной услуги" },
                    { new Guid("84766db7-fafe-4856-8bb9-4356c752c7a1"), "Низкая скорость соединения" },
                    { new Guid("8c1ebe26-5b4b-42d6-9744-c4d5f5422167"), "Разрыв соединения" },
                    { new Guid("91301712-fea9-459a-834b-8decfb81fb7e"), "Изменение адреса предоставления услуг" },
                    { new Guid("98935bd1-da2c-4eaf-9029-01f640910277"), "Отключение услуги" },
                    { new Guid("9cf0a224-1b1f-413a-8e09-4ab469eb0dfb"), "Подключение услуг на существующей инфраструктуре" },
                    { new Guid("b8df5708-17df-4381-b330-7070e8504294"), "Информация о платежах" },
                    { new Guid("c2813eab-c234-4a86-9572-4fa5853b0022"), "Подключение услуг с новой инфраструктурой" },
                    { new Guid("d9935308-9a88-41f5-887f-d3c8848707a6"), "Изменение тарифа" },
                    { new Guid("f8cac35b-1ca5-4ceb-ade9-1f89f8f90010"), "Приостановка предоставления услуги" }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("46a6b6f2-c71e-4057-9ed3-09d5cd7bd964"), "Видеонаблюдение" },
                    { new Guid("a3a96f13-0167-44b2-9ed1-0e4d2cdbe54d"), "Телевидение" },
                    { new Guid("baae4bab-000d-4508-96c5-d5a355279eb0"), "Интернет" },
                    { new Guid("ffe400f7-068f-4fa9-98d1-4b24b613baf5"), "Мобильная связь" }
                });

            migrationBuilder.InsertData(
                table: "Subscribers",
                columns: new[] { "Id", "ContractNumber", "ContractType", "DateOfContractConclusion", "DateOfTerminationOfTheContract", "PersonId", "PersonalBill", "ReasonForTerminationOfContract", "Services", "SubscriberNumber", "TypeOfEquipment" },
                values: new object[,]
                {
                    { new Guid("0320d090-d3a3-477c-b283-dc7b3484eeb1"), "50-785493420-KOLOMNA-11-2014", false, new DateOnly(2014, 11, 5), new DateOnly(2022, 11, 12), new Guid("00000000-0000-0000-0000-000000000000"), 785493420L, "Не указана", "Интернет", "50-785493420-KOLOMNA", "Сервер" },
                    { new Guid("272882da-b0a5-469a-adae-53a397c4ea51"), "50-785493418-KOLOMNA-12-2019", false, new DateOnly(2019, 12, 10), new DateOnly(2044, 6, 12), new Guid("00000000-0000-0000-0000-000000000000"), 785493418L, "Истечение срока договора", "Интернет", "50-785493418-KOLOMNA", "Маршрутизатор" },
                    { new Guid("3861813a-45aa-471d-b4b3-6485f3b03610"), "50-785493424-KOLOMNA-01-2020", false, new DateOnly(2020, 1, 12), new DateOnly(2024, 1, 12), new Guid("00000000-0000-0000-0000-000000000000"), 785493424L, "Нарушение условий договора", "Мобильная связь", "50-785493424-KOLOMNA", "Ноутбук" },
                    { new Guid("565f79c2-451a-49d0-8925-b0b8cf294c27"), "50-785493423-KOLOMNA-03-2010", false, new DateOnly(2010, 3, 27), new DateOnly(2022, 11, 12), new Guid("00000000-0000-0000-0000-000000000000"), 785493423L, "Финансовые трудности", "Мобильная связь", "50-785493423-KOLOMNA", "Телефон" },
                    { new Guid("ab635843-dc9d-43d2-83db-c8c87fdc23df"), "50-785493424-KOLOMNA-01-2020", false, new DateOnly(2020, 1, 12), new DateOnly(2044, 6, 12), new Guid("00000000-0000-0000-0000-000000000000"), 785493424L, "Истечение срока договора", "Мобильная связь", "50-785493424-KOLOMNA", "Планшет" },
                    { new Guid("bd4c1411-f376-4ffd-8966-0a1e4238241f"), "50-785493424-KOLOMNA-05-2020", false, new DateOnly(2020, 5, 11), new DateOnly(2044, 6, 12), new Guid("00000000-0000-0000-0000-000000000000"), 785493424L, "Истечение срока договора", "Телевидение", "50-785493424-KOLOMNA", "Ноутбук" },
                    { new Guid("d069c6d3-6014-4d3a-9675-e3b8570c91d2"), "50-785493422-KOLOMNA-07-2013", false, new DateOnly(2013, 7, 5), new DateOnly(2022, 11, 12), new Guid("00000000-0000-0000-0000-000000000000"), 785493422L, "Не указана", "Интернет", "50-785493422-KOLOMNA", "Модем" },
                    { new Guid("f51ccd49-e507-45a9-95ef-0a2119832276"), "50-785493417-KOLOMNA-11-2018", false, new DateOnly(2018, 11, 12), new DateOnly(2044, 6, 12), new Guid("00000000-0000-0000-0000-000000000000"), 785493417L, "Истечение срока договора", "Интернет", "50-785493417-KOLOMNA", "Маршрутизатор" },
                    { new Guid("fafb5279-9cad-4d7e-aaa8-11cba9524f53"), "50-785493419-KOLOMNA-11-2014", false, new DateOnly(2014, 11, 5), new DateOnly(2022, 11, 12), new Guid("00000000-0000-0000-0000-000000000000"), 785493419L, "Не указана", "Интернет", "50-785493419-KOLOMNA", "Коммутатор" },
                    { new Guid("fcee4a72-067a-46b2-aa72-41a21f88d2af"), "50-785493421-KOLOMNA-06-2015", false, new DateOnly(2015, 6, 5), new DateOnly(2023, 5, 12), new Guid("00000000-0000-0000-0000-000000000000"), 785493421L, "Не указана", "Интернет", "50-785493421-KOLOMNA", "Шлюз" }
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
