import { Department } from './department.interface';
import { Equipment } from './equipment.interface';
import { Section } from './section.interface';

export interface Course {
  courseTitle: string;
  credits?: number;
  departmentDepartmentName: string;
  departmentDepartmentNameNavigation: Department; // Assuming Department is another interface/model
  equipment: Equipment[]; // Assuming Equipment is another interface/model and represents an array
  sections: Section[]; // Assuming Section is another interface/model and represents an array
}
