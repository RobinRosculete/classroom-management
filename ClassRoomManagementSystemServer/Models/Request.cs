using System;
using System.Collections.Generic;

namespace ClassRoomManagementSystemServer.Models;

public partial class Request
{
    public uint RequestId { get; set; }

    public string? Descritption { get; set; }

    public uint ClassroomId { get; set; }

    public virtual Classroom Classroom { get; set; } = null!;
}
