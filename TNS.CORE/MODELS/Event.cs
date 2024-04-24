using System;
using System.Collections.Generic;

namespace TNS.Database;

public partial class Event
{
    public int Id { get; set; }

    public int PositionId { get; set; }

    public DateOnly EventDate { get; set; }

    public string EventDescription { get; set; } = null!;

    public TimeOnly? EventTime { get; set; }
}
