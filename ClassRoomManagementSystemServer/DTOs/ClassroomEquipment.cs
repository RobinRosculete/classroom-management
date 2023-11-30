using System;
namespace ClassRoomManagementSystemServer.DTO;
	public class ClassroomEquipment
	{
        public int RoomNum { get; set; }

        public int Capacity { get; set; }

        public string DepartmentName { get; set; } = null!;

        public string EquipmentType { get; set; } = null!;



}


