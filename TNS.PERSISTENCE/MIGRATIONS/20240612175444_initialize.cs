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
                name: "EmployeePositions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PositionName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeePositions", x => x.Id);
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
                    PositionId = table.Column<Guid>(type: "uuid", nullable: false),
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
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PositionId = table.Column<Guid>(type: "uuid", nullable: false),
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
                    table.ForeignKey(
                        name: "FK_Employees_EmployeePositions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "EmployeePositions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeePositionEntityEventEntity",
                columns: table => new
                {
                    EventsId = table.Column<Guid>(type: "uuid", nullable: false),
                    employeePositionsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeePositionEntityEventEntity", x => new { x.EventsId, x.employeePositionsId });
                    table.ForeignKey(
                        name: "FK_EmployeePositionEntityEventEntity_EmployeePositions_employe~",
                        column: x => x.employeePositionsId,
                        principalTable: "EmployeePositions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeePositionEntityEventEntity_Events_EventsId",
                        column: x => x.EventsId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeePositionEntityRoleEntity",
                columns: table => new
                {
                    EmployeePositionsId = table.Column<Guid>(type: "uuid", nullable: false),
                    RolesId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeePositionEntityRoleEntity", x => new { x.EmployeePositionsId, x.RolesId });
                    table.ForeignKey(
                        name: "FK_EmployeePositionEntityRoleEntity_EmployeePositions_Employee~",
                        column: x => x.EmployeePositionsId,
                        principalTable: "EmployeePositions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeePositionEntityRoleEntity_Roles_RolesId",
                        column: x => x.RolesId,
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
                    table.PrimaryKey("PK_RolePermissionEntity", x => new { x.PermissionId, x.RoleId });
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
                table: "Subscribers",
                columns: new[] { "Id", "ContractNumber", "ContractType", "DateOfContractConclusion", "DateOfTerminationOfTheContract", "PersonId", "PersonalBill", "ReasonForTerminationOfContract", "Services", "SubscriberNumber", "TypeOfEquipment" },
                values: new object[,]
                {
                    { new Guid("2372b9cf-6ed4-4690-a955-0d05c71f44d7"), "50-785493420-KOLOMNA-11-2014", false, new DateOnly(2014, 11, 5), new DateOnly(2022, 11, 12), new Guid("00000000-0000-0000-0000-000000000000"), 785493420L, "Не указана", "Интернет", "50-785493420-KOLOMNA", "Сервер" },
                    { new Guid("401eb0cc-22f1-49a4-9a00-053b75a7f7fa"), "50-785493424-KOLOMNA-01-2020", false, new DateOnly(2020, 1, 12), new DateOnly(2044, 6, 12), new Guid("00000000-0000-0000-0000-000000000000"), 785493424L, "Истечение срока договора", "Мобильная связь", "50-785493424-KOLOMNA", "Планшет" },
                    { new Guid("589e669e-0b4c-4405-8213-9a259dae84fd"), "50-785493421-KOLOMNA-06-2015", false, new DateOnly(2015, 6, 5), new DateOnly(2023, 5, 12), new Guid("00000000-0000-0000-0000-000000000000"), 785493421L, "Не указана", "Интернет", "50-785493421-KOLOMNA", "Шлюз" },
                    { new Guid("7c5fa9d4-00d9-4dc1-a5d0-c64c03155203"), "50-785493424-KOLOMNA-05-2020", false, new DateOnly(2020, 5, 11), new DateOnly(2044, 6, 12), new Guid("00000000-0000-0000-0000-000000000000"), 785493424L, "Истечение срока договора", "Телевидение", "50-785493424-KOLOMNA", "Ноутбук" },
                    { new Guid("8c9a031b-6262-4e07-90c0-0d765f06767d"), "50-785493419-KOLOMNA-11-2014", false, new DateOnly(2014, 11, 5), new DateOnly(2022, 11, 12), new Guid("00000000-0000-0000-0000-000000000000"), 785493419L, "Не указана", "Интернет", "50-785493419-KOLOMNA", "Коммутатор" },
                    { new Guid("a580a05a-4cfa-4457-8b8a-e2cffc368cf0"), "50-785493417-KOLOMNA-11-2018", false, new DateOnly(2018, 11, 12), new DateOnly(2044, 6, 12), new Guid("00000000-0000-0000-0000-000000000000"), 785493417L, "Истечение срока договора", "Интернет", "50-785493417-KOLOMNA", "Маршрутизатор" },
                    { new Guid("ac091089-8c71-4e96-b79e-c60517561527"), "50-785493418-KOLOMNA-12-2019", false, new DateOnly(2019, 12, 10), new DateOnly(2044, 6, 12), new Guid("00000000-0000-0000-0000-000000000000"), 785493418L, "Истечение срока договора", "Интернет", "50-785493418-KOLOMNA", "Маршрутизатор" },
                    { new Guid("c22ba44a-ef06-4ff2-b5dd-8a1d3207c964"), "50-785493423-KOLOMNA-03-2010", false, new DateOnly(2010, 3, 27), new DateOnly(2022, 11, 12), new Guid("00000000-0000-0000-0000-000000000000"), 785493423L, "Финансовые трудности", "Мобильная связь", "50-785493423-KOLOMNA", "Телефон" },
                    { new Guid("c8644cc5-55ac-4d5a-a0db-107ab0174ae5"), "50-785493422-KOLOMNA-07-2013", false, new DateOnly(2013, 7, 5), new DateOnly(2022, 11, 12), new Guid("00000000-0000-0000-0000-000000000000"), 785493422L, "Не указана", "Интернет", "50-785493422-KOLOMNA", "Модем" },
                    { new Guid("dce8f11b-fdb8-4c9e-ad8c-f4b69d975c4d"), "50-785493424-KOLOMNA-01-2020", false, new DateOnly(2020, 1, 12), new DateOnly(2024, 1, 12), new Guid("00000000-0000-0000-0000-000000000000"), 785493424L, "Нарушение условий договора", "Мобильная связь", "50-785493424-KOLOMNA", "Ноутбук" }
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
                name: "IX_EmployeePositionEntityEventEntity_employeePositionsId",
                table: "EmployeePositionEntityEventEntity",
                column: "employeePositionsId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePositionEntityRoleEntity_RolesId",
                table: "EmployeePositionEntityRoleEntity",
                column: "RolesId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_PositionId",
                table: "Employees",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_SubscriberId",
                table: "Persons",
                column: "SubscriberId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissionEntity_RoleId",
                table: "RolePermissionEntity",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BaseStations");

            migrationBuilder.DropTable(
                name: "CRM_Requests");

            migrationBuilder.DropTable(
                name: "EmployeePositionEntityEventEntity");

            migrationBuilder.DropTable(
                name: "EmployeePositionEntityRoleEntity");

            migrationBuilder.DropTable(
                name: "EmployeeRoleEntity");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Equipments");

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
                name: "Events");

            migrationBuilder.DropTable(
                name: "EmployeePositions");

            migrationBuilder.DropTable(
                name: "Subscribers");

            migrationBuilder.DropTable(
                name: "PermissionEntity");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
