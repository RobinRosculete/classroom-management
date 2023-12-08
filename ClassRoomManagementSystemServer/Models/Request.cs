using System;
using System.Collections.Generic;

namespace ClassRoomManagementSystemServer.Models;

public partial class Request
{
    public int RequestId { get; set; }

    public string DepartmentName { get; set; } = null!;

    public int? ClassroomId { get; set; }

    public sbyte? Conflict { get; set; }

    public int SectionId { get; set; }

    public virtual Classroom? Classroom { get; set; }

    public virtual Department DepartmentNameNavigation { get; set; } = null!;
}
