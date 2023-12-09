using System;
namespace ClassRoomManagementSystemServer.DTOs;

public class UpdateBlackoutHours
{

    public TimeOnly BlackoutHoursStart { get; set; }

    public TimeOnly BlackoutHoursEnd { get; set; }
}


