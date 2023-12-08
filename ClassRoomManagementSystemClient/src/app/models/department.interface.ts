import { Classroom } from './classroom.interface';
import { Course } from './course.interface';

export interface Department {
  departmentName: string;
  buildingName: string;
  numClassroom?: number;
  classrooms: Classroom[];
  courses: Course[];
  requests: Request[];
}
