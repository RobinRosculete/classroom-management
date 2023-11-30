import { Section } from './section.interface';

export interface TimeSlot {
  timeSlotId: number;
  day: string; // Assuming the day is represented as a string, adjust if using a different format
  startTime: string; // Assuming time is represented as a string (HH:mm), adjust if needed
  endTime: string; // Assuming time is represented as a string (HH:mm), adjust if needed
  sections: Section[]; // Assuming Section is another interface/model and represents an array
}
