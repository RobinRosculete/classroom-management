using System;
using System.Collections.Generic;

namespace ClassRoomManagementSystemServer.Models;

public partial class Section
{
    public int SectionId { get; set; }

    public short Year { get; set; }

    public string Semester { get; set; } = null!;

    public string CourseTitle { get; set; } = null!;

    public int TimeSlotId { get; set; }

    public int? ClassroomId { get; set; }

    public virtual Classroom? Classroom { get; set; }

    public virtual Course CourseTitleNavigation { get; set; } = null!;

    public virtual TimeSlot TimeSlot { get; set; } = null!;
}
