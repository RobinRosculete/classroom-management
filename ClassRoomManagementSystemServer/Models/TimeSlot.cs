using System;
using System.Collections.Generic;

namespace ClassRoomManagementSystemServer.Models;

public partial class TimeSlot
{
    public uint TimeSlotId { get; set; }

    public DateOnly Day { get; set; }

    public TimeOnly StartTime { get; set; }

    public TimeOnly EndTime { get; set; }

    public virtual ICollection<Section> Sections { get; set; } = new List<Section>();
}
