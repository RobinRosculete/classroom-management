using System;
using System.Collections.Generic;

namespace ClassRoomManagementSystemServer.Models;

public partial class Course
{
    public string CourseTitle { get; set; } = null!;

    public float? Credits { get; set; }

    public string DepartmentName { get; set; } = null!;

    public virtual Department DepartmentNameNavigation { get; set; } = null!;

    public virtual ICollection<Equipment> Equipment { get; set; } = new List<Equipment>();

    public virtual ICollection<Section> Sections { get; set; } = new List<Section>();
}
