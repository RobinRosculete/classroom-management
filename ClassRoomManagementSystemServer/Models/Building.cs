using System;
using System.Collections.Generic;

namespace ClassRoomManagementSystemServer.Models;

public partial class Building
{
    public string BuildingName { get; set; } = null!;

    public uint NumberClassrooms { get; set; }

    public virtual ICollection<Classroom> Classrooms { get; set; } = new List<Classroom>();

    public virtual Department? Department { get; set; }
}
