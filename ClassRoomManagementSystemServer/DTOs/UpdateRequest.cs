using System;
namespace ClassRoomManagementSystemServer.DTOs;
public class UpdateRequest
{
    public int RequestId { get; set; }
    public string Day { get; set; } = null!;

    public TimeOnly StartTime { get; set; }

    public TimeOnly EndTime { get; set; }
}


