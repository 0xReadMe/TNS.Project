using System;
using System.Collections.Generic;

namespace TNS.Database;

public partial class Employee
{
    public int Id { get; set; }

    public string FullName { get; set; } = null!;

    public int PositionId { get; set; }

    public string? PhotoId { get; set; }
}
