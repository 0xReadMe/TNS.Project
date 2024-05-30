using CSharpFunctionalExtensions;

namespace TNS.CORE.MODELS
{
    public class Event
    {
        public Guid         Id                  { get; }    //  id события
        public Guid         PositionId          { get; }    //  id должности
        public DateOnly     Date                { get; }    //  дата события
        public string?      Description         { get; }    //  описание события
        public TimeOnly?    Time                { get; }    //  время события

        private Event(Guid      id,
                      Guid      positionId,
                      DateOnly  eventDate,
                      string?   eventDescription,
                      TimeOnly? eventTime)
        {
            Id                  = id;
            PositionId          = positionId;
            Date                = eventDate;
            Description         = eventDescription;
            Time                = eventTime;
        }

        public static Result<Event> Create(Guid         id,
                                           Guid         positionId,
                                           DateOnly     eventDate,
                                           string?      eventDescription,
                                           TimeOnly?    eventTime)
        {
            Event result = new Event(id,
                                     positionId,
                                     eventDate,
                                     eventDescription,
                                     eventTime);

            return Result.Success(result);
        }
    }
}
