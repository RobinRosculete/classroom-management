import { Section } from './section.interface';

export interface TimeSlot {
  timeSlotId: number;
  day: string;
  startTime: string;
  endTime: string;
  sections: Section[];
}
