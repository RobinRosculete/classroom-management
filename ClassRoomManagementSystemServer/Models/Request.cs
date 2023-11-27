using System;
using System.Collections.Generic;

namespace ClassRoomManagementSystemServer.Models;

public partial class Request
{
    public int RequestId { get; set; }

    public string Description { get; set; } = null!;

    public string DepartmentDepartmentName { get; set; } = null!;

    public int ClassroomClassroomId { get; set; }

    public virtual Classroom ClassroomClassroom { get; set; } = null!;

    public virtual Department DepartmentDepartmentNameNavigation { get; set; } = null!;
}
