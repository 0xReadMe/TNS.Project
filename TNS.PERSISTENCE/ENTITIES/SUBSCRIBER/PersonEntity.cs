using TNS.CORE.VO;

namespace TNS.PERSISTENCE.ENTITIES.SUBSCRIBER;

public class PersonEntity
{
    public required Guid                Id          { get; set; }   //  id человека
    public          Guid                SubscriberId{ get; set; }   //  id абонента
    public          SubscriberEntity    Subscriber  { get; }        //  for configuration
    public required string              FirstName   { get; set; }   //  имя
    public required string              MiddleName  { get; set; }   //  отчество
    public required string              LastName    { get; set; }   //  фамилия
    public required char                Gender      { get; set; }   //  пол
    public required DateOnly            DOB         { get; set; }   //  дата рождения
    public required PhoneNumber         PhoneNumber { get; set; }   //  номер телефона
    public required Email               Email       { get; set; }   //  e-mail
    public required Passport            Passport    { get; set; }   //  паспорт
}
