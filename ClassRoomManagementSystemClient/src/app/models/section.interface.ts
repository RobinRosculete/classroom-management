import { Classroom } from './classroom.interface';
import { Course } from './course.interface';
import { TimeSlot } from './timeslot.interface';

export interface Section {
  sectionId: number;
  courseTitle: string;
  year: string;
  semester: string;
  courseCourseTitle: string;
  timeSlotTimeSlotId: number;
  classroomClassroomId: number;
  classroomClassroom: Classroom | null; // Assuming Classroom is another interface/model
  courseCourseTitleNavigation: Course | null; // Assuming Course is another interface/model
  timeSlotTimeSlot: TimeSlot | null; // Assuming TimeSlot is another interface/model
}
