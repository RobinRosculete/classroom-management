using System;
using System.Collections.Generic;

namespace ClassRoomManagementSystemServer.Models;

public partial class SectionTimeSlot
{
    public uint SectionTimeSlotId { get; set; }

    public DateOnly Day { get; set; }

    public TimeOnly StartTime { get; set; }

    public TimeOnly EndTime { get; set; }

    public string Semester { get; set; } = null!;

    public uint Year { get; set; }

    public uint CourseId { get; set; }

    public uint SectionId { get; set; }

    public virtual Section Section { get; set; } = null!;
}
