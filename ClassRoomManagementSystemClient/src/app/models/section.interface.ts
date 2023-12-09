import { Classroom } from './classroom.interface';
import { Course } from './course.interface';
import { TimeSlot } from './newRequest.interface';

export interface Section {
  sectionId: number;
  courseTitle: string;
  year: string;
  semester: string;
  courseCourseTitle: string;
  timeSlotTimeSlotId: number;
  classroomClassroomId: number;
  classroomClassroom: Classroom | null;
  courseCourseTitleNavigation: Course | null;
  timeSlotTimeSlot: TimeSlot | null;
}
