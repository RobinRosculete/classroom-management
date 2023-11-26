import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Buildings } from '../../models/buildings.interface';

@Component({
  selector: 'app-room-assignments',
  templateUrl: './room-assignments.component.html',
  styleUrls: ['./room-assignments.component.css'],
})
export class RoomAssignmentsComponent {
  buildings: Buildings[] = [];
  constructor(http: HttpClient) {
    http.get<Buildings[]>(environment.apiUrl + '/Building').subscribe({
      next: (result) => {
        this.buildings = result;
      },
      error: (error) => {
        console.error(error);
      },
    });
  }
}
