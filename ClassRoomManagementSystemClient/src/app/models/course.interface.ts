import { Department } from './department.interface';
import { Equipment } from './equipment.interface';
import { Section } from './section.interface';

export interface Course {
  courseTitle: string;
  credits?: number;
  departmentDepartmentName: string;
  departmentDepartmentNameNavigation: Department;
  equipment: Equipment[];
  sections: Section[];
}
