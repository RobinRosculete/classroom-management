export interface Classroom {
  roomNum: number;
  capacity: number;
  blackoutHoursStart: string; // Assuming time will be stored as a string (HH:mm)
  blackoutHoursEnd: string; // Assuming time will be stored as a string (HH:mm)
  equipmentType: string;
  departmentName: string;
}
