import { Department } from './department.interface';
import { Equipment } from './equipment.interface';
import { Section } from './section.interface';
import { Request } from './requests.interface';

export interface Classroom {
  classroomId: number;
  roomNum: number;
  capacity: number;
  blackoutHoursStart: string; // Assuming time will be stored as a string (HH:mm)
  blackoutHoursEnd: string; // Assuming time will be stored as a string (HH:mm)
  departmentDepartmentName: string;
  departmentDepartmentNameNavigation: Department;
  equipment: Equipment[];
  requests: Request[];
  sections: Section[];
}
