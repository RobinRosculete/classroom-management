using System;
using System.Collections.Generic;

namespace ClassRoomManagementSystemServer.Models;

public partial class Department
{
    public string DepartmentName { get; set; } = null!;

    public string BuildingName { get; set; } = null!;

    public float? Budget { get; set; }

    public virtual Building BuildingNameNavigation { get; set; } = null!;

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

    public virtual ICollection<Request> Requests { get; set; } = new List<Request>();
}
