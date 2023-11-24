using System;
using System.Collections.Generic;

namespace ClassRoomManagementSystemServer.Models;

public partial class Equipment
{
    public uint EquipmentId { get; set; }

    public string EquipmentType { get; set; } = null!;

    public uint ClassroomId { get; set; }

    public uint CourseId { get; set; }

    public virtual Classroom Classroom { get; set; } = null!;

    public virtual Course Course { get; set; } = null!;
}
