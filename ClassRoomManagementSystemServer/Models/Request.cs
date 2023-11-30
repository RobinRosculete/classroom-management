using System;
using System.Collections.Generic;

namespace ClassRoomManagementSystemServer.Models;

public partial class Request
{
    public int RequestId { get; set; }

    public string Description { get; set; } = null!;

    public string DepartmentName { get; set; } = null!;

    public int ClassroomId { get; set; }

    public virtual Classroom Classroom { get; set; } = null!;

    public virtual Department DepartmentNameNavigation { get; set; } = null!;
}
