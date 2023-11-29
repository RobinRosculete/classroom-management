import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Department } from '../../models/department.interface';

@Component({
  selector: 'app-room-assignments',
  templateUrl: './room-assignments.component.html',
  styleUrls: ['./room-assignments.component.css'],
})
export class RoomAssignmentsComponent {
  department: Department[] = [];
  constructor(http: HttpClient) {
    http.get<Department[]>(environment.apiUrl + '/Department').subscribe({
      next: (result) => {
        this.department = result;
      },
      error: (error) => {
        console.error(error);
      },
    });
  }
}
