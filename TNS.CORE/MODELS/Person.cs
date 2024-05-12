using CSharpFunctionalExtensions;
using TNS.CORE.VO;

namespace TNS.CORE.MODELS
{
    public class Person
    {
        public Guid         Id              { get; }
        public Guid         SubscriberId    { get; }
        public string       FirstName       { get; } = string.Empty;
        public string       MiddleName      { get; } = null!;
        public string       LastName        { get; } = string.Empty;
        public char         Gender          { get; }
        public DateTime     DOB             { get; }
        public PhoneNumber  PhoneNumber     { get; }
        public Email?       Email           { get; } = null!;
        public Passport     Passport        { get; }

        private Person(Guid         id,
                       Guid         subscriberId,
                       string       firstName,
                       string       middleName,
                       string       lastName,
                       char         gender,
                       DateTime     DOB,
                       PhoneNumber  phoneNumber,
                       Email?       email,
                       Passport     passport) 
        {
            Id              = id;
            SubscriberId    = subscriberId;
            FirstName       = firstName;
            MiddleName      = middleName;
            LastName        = lastName;
            Gender          = gender;
            this.DOB        = DOB;
            PhoneNumber     = phoneNumber;
            Email           = email;
            Passport        = passport;
        }

        public static Result<Person> Create(Guid        id,
                                            Guid        subscriberId,
                                            string      firstName,
                                            string      middleName,
                                            string      lastName,
                                            char        gender,
                                            DateTime    DOB,
                                            PhoneNumber phoneNumber,
                                            Email?      email,
                                            Passport    passport)
        {
            Person person = new Person(id,
                                       subscriberId,
                                       firstName,
                                       middleName,
                                       lastName,
                                       gender,
                                       DOB,
                                       phoneNumber,
                                       email,
                                       passport);

            return Result.Success(person);
        } 
    }
}
