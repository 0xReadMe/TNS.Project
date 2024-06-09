using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

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
                name: "IX_Employees_PositionId",
                table: "Employees",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_SubscriberId",
                table: "Persons",
                column: "SubscriberId",
                unique: true);
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
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Equipments");

            migrationBuilder.DropTable(
                name: "Persons");

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
        }
    }
}
