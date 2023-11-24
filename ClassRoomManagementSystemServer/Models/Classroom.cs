using System;
using System.Collections.Generic;

namespace ClassRoomManagementSystemServer.Models;

public partial class Classroom
{
    public uint ClassroomId { get; set; }

    public uint RoomNumber { get; set; }

    public uint Capacity { get; set; }

    public TimeOnly BackoutHours { get; set; }

    public string? BuildingName { get; set; }

    public virtual Building? BuildingNameNavigation { get; set; }

    public virtual ICollection<Equipment> Equipment { get; set; } = new List<Equipment>();

    public virtual ICollection<Request> Requests { get; set; } = new List<Request>();

    public virtual ICollection<Section> Sections { get; set; } = new List<Section>();
}
