using System;
namespace ClassRoomManagementSystemServer.DTOs;
public class RoomAssignmentReport
	{
    public string DepartmentName { get; set; } = null!;

    public string BuildingName { get; set; } = null!;

    public string CourseTitle { get; set; } = null!;

    public int SectionId { get; set; }

    public string Year { get; set; } = null!;

    public string Semester { get; set; } = null!;

    public int RoomNum { get; set; }

    public int Capacity { get; set; }

    public TimeOnly Starttime { get; set; }
    public TimeOnly EndTime { get; set; }
}


