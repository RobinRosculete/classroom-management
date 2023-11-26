using System;
using System.Collections.Generic;

namespace ClassRoomManagementSystemServer.Models;

public partial class Equipment
{
    public int EquipmentId { get; set; }

    public string EquipmentType { get; set; } = null!;

    public int ClassroomClassroomId { get; set; }

    public string CourseCourseTitle { get; set; } = null!;

    public virtual Classroom ClassroomClassroom { get; set; } = null!;

    public virtual Course CourseCourseTitleNavigation { get; set; } = null!;
}
