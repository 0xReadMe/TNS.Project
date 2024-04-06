using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;

namespace TNS.Database;

public class Subscriber
{
    public const int ENTITY_MAX_LENGTH = 100;

    private Subscriber(
// enter data to constructor
        )
    {
        
    }

    //public Guid Id { get; }
    //public string SubscriberNumber { get; } = null!;
    //public string FullName { get; } = null!;
    //public string? Gender { get; }
    //public DateOnly Dob { get; }
    //public string Phone { get; } = null!;
    //public string Email { get; } = null!;
    //public string ResidenceAddress { get; } = null!;
    //public string ResidentialAddress { get; } = null!;
    //public int PassportSeries { get; }
    //public int PassportNumber { get; }
    //public string DivisionCode { get; } = null!;
    //public string IssuedBy { get; } = null!;
    //public DateOnly DateOfIssueOfPassport { get; }
    //public string ContractNumber { get; } = null!;
    //public DateOnly DateOfContractConclusion { get; }
    //public string ContractType { get; } = null!;
    //public string? ReasonForTerminationOfContract { get; }
    //public int PersonalBill { get; }
    //public string? Services { get; }
    //public string? DateOfTerminationOfTheContract { get; }
    //public string SerialNumberOfEquipment { get; } = null!;

    public static Result<Subscriber> Create()
    {
        //validation data IsNullOrEmtpy..
        //return Result.Failure<Subscriber>($"")
        Subscriber subscriber = new();
        return Result.Success(subscriber);
    }
}
