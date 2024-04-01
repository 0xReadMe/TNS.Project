using System;
using System.Collections.Generic;

namespace TestBackEnd.Database;

public partial class Subscriber
{
    public int Id { get; set; }

    public string SubscriberNumber { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public string? Gender { get; set; }

    public DateOnly Dob { get; set; }

    public string Phone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string ResidenceAddress { get; set; } = null!;

    public string ResidentialAddress { get; set; } = null!;

    public int PassportSeries { get; set; }

    public int PassportNumber { get; set; }

    public string DivisionCode { get; set; } = null!;

    public string IssuedBy { get; set; } = null!;

    public DateOnly DateOfIssueOfPassport { get; set; }

    public string ContractNumber { get; set; } = null!;

    public DateOnly DateOfContractConclusion { get; set; }

    public string ContractType { get; set; } = null!;

    public string? ReasonForTerminationOfContract { get; set; }

    public int PersonalBill { get; set; }

    public string? Services { get; set; }

    public string? DateOfTerminationOfTheContract { get; set; }

    public string SerialNumberOfEquipment { get; set; } = null!;
}
