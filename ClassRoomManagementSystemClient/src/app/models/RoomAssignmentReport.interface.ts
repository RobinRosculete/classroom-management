export interface RoomAssignmentReport {
  requestId: number;
  classroomDepartmentName: string;
  requestDepartmentName: string;
  buildingName: string;
  courseTitle: string;
  sectionId: number;
  year: number;
  semester: string;
  roomNum: number;
  capacity: number;
  day: string;
  startTime: string;
  endTime: string;
}
