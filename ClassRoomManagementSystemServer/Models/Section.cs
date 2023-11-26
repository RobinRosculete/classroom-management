using System;
using System.Collections.Generic;

namespace ClassRoomManagementSystemServer.Models;

public partial class Section
{
    public int SectionId { get; set; }

    public string CourseTitle { get; set; } = null!;

    public string Year { get; set; } = null!;

    public string Semester { get; set; } = null!;

    public string CourseCourseTitle { get; set; } = null!;

    public int TimeSlotTimeSlotId { get; set; }

    public int ClassroomClassroomId { get; set; }

    public virtual Classroom ClassroomClassroom { get; set; } = null!;

    public virtual Course CourseCourseTitleNavigation { get; set; } = null!;

    public virtual TimeSlot TimeSlotTimeSlot { get; set; } = null!;
}
