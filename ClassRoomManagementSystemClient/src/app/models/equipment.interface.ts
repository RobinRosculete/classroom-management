import { Classroom } from './classroom.interface';
import { Course } from './course.interface';

export interface Equipment {
  equipmentId: number;
  equipmentType: string;
  classroomClassroomId: number;
  courseCourseTitle: string;
  classroomClassroom?: Classroom | null; // Assuming Classroom is another interface/model
  courseCourseTitleNavigation?: Course | null; // Assuming Course is another interface/model
}
