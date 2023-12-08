using System;
namespace ClassRoomManagementSystemServer.DTOs;

	public class SectionRequest
	{
    public string Day { get; set; } = null!;
    public TimeOnly Starttime { get; set; }
    public TimeOnly EndTime { get; set; }
    public string CourseTitle { get; set; } = null!;
    public short Year { get; set; }
    public string Semester { get; set; } = null!;
    public string DepartmentName { get; set; } = null!;

}


