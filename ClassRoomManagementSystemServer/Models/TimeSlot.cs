using System;
using System.Collections.Generic;

namespace ClassRoomManagementSystemServer.Models;

public partial class TimeSlot
{
    public int TimeSlotId { get; set; }

    public string Day { get; set; } = null!;

    public TimeOnly StartTime { get; set; }

    public TimeOnly EndTime { get; set; }

    public virtual ICollection<Section> Sections { get; set; } = new List<Section>();
}
