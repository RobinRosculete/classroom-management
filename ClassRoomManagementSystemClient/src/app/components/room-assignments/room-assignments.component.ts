import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { environment } from 'src/environments/environment';
import { RoomAssignmentReport } from 'src/app/models/RoomAssignmentReport.interface';

@Component({
  selector: 'app-room-assignments',
  templateUrl: './room-assignments.component.html',
  styleUrls: ['./room-assignments.component.css'],
})
export class RoomAssignmentsComponent {
  roomAssignmentReport: RoomAssignmentReport[] = [];
  constructor(http: HttpClient) {
    http
      .get<RoomAssignmentReport[]>(
        environment.apiUrl + '/Request/request-report'
      )
      .subscribe({
        next: (result) => {
          this.roomAssignmentReport = result;
        },
        error: (error) => {
          console.error(error);
        },
      });
  }
}
