using System;
using System.Collections.Generic;

namespace ClassRoomManagementSystemServer.Models;

public partial class Equipment
{
    public int EquipmentId { get; set; }

    public string EquipmentType { get; set; } = null!;

    public int ClassroomId { get; set; }

    public string? CourseTitle { get; set; }

    public virtual Classroom Classroom { get; set; } = null!;

    public virtual Course? CourseTitleNavigation { get; set; }
}
