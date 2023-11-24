using System;
using System.Collections.Generic;

namespace ClassRoomManagementSystemServer.Models;

public partial class Section
{
    public uint SectionId { get; set; }

    public string Semester { get; set; } = null!;

    public uint Year { get; set; }

    public uint CourseId { get; set; }

    public uint ClassroomId { get; set; }

    public virtual Classroom Classroom { get; set; } = null!;

    public virtual Course Course { get; set; } = null!;

    public virtual ICollection<SectionTimeSlot> SectionTimeSlots { get; set; } = new List<SectionTimeSlot>();
}
