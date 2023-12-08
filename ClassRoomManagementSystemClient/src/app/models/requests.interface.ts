import { Classroom } from './classroom.interface';
import { Department } from './department.interface';

export interface Request {
  requestId: number;
  description: string;
  departmentName: string;
  classroomId: number;
  classroomClassroom: Classroom | null;
  departmentDepartmentNameNavigation: Department | null;
}
