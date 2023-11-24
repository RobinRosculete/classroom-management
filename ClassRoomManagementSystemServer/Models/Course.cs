﻿using System;
using System.Collections.Generic;

namespace ClassRoomManagementSystemServer.Models;

public partial class Course
{
    public uint CourseId { get; set; }

    public string Title { get; set; } = null!;

    public uint Credits { get; set; }

    public string? DepartmentName { get; set; }

    public virtual Department? DepartmentNameNavigation { get; set; }

    public virtual ICollection<Equipment> Equipment { get; set; } = new List<Equipment>();

    public virtual ICollection<Section> Sections { get; set; } = new List<Section>();
}