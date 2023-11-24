using System;
using System.Collections.Generic;

namespace ClassRoomManagementSystemServer.Models;

public partial class Department
{
    public uint DepartmentId { get; set; }

    public string DepartmentName { get; set; } = null!;

    public float Budget { get; set; }

    public string BuildingName { get; set; } = null!;

    public virtual Building BuildingNameNavigation { get; set; } = null!;

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
}
