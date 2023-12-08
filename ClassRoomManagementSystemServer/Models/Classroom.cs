using System;
using System.Collections.Generic;

namespace ClassRoomManagementSystemServer.Models;

public partial class Classroom
{
    public int ClassroomId { get; set; }

    public int RoomNum { get; set; }

    public int Capacity { get; set; }

    public TimeOnly BlackoutHoursStart { get; set; }

    public TimeOnly BlackoutHoursEnd { get; set; }

    public string DepartmentName { get; set; } = null!;

    public virtual Department DepartmentNameNavigation { get; set; } = null!;

    public virtual ICollection<Equipment> Equipment { get; set; } = new List<Equipment>();

    public virtual ICollection<Request> Requests { get; set; } = new List<Request>();

    public virtual ICollection<Section> Sections { get; set; } = new List<Section>();
}
