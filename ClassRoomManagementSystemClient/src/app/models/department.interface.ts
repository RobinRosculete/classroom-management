import { Classroom } from './classroom.interface';
import { Course } from './course.interface';

export interface Department {
  departmentName: string;
  buildingName: string;
  numClassroom?: number;
  classrooms: Classroom[]; // Assuming Classroom is another interface/model and represents an array
  courses: Course[]; // Assuming Course is another interface/model and represents an array
  requests: Request[]; // Assuming Request is another interface/model and represents an array
}
