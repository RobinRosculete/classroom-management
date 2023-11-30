import { Classroom } from './classroom.interface';
import { Department } from './department.interface';

export interface Request {
  requestId: number;
  description: string;
  departmentName: string;
  classroomId: number;
  classroomClassroom: Classroom | null; // Assuming Classroom is another interface/model
  departmentDepartmentNameNavigation: Department | null; // Assuming Department is another interface/model
}
