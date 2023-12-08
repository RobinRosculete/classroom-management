using System;
namespace ClassRoomManagementSystemServer.DTOs;
public class RoomAssignmentReport
	{

    public string classroomDepartmentName { get; set; } = null!;
    public string requestDepartmentName { get; set; } = null!;

    public string BuildingName { get; set; } = null!;

    public string CourseTitle { get; set; } = null!;

    public string Day{ get; set; } = null!;

    public int SectionId { get; set; }

    public int Year { get; set; }

    public string Semester { get; set; } = null!;

    public int RoomNum { get; set; }

    public int Capacity { get; set; }

    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }
}


