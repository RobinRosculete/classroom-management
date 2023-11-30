import { Component } from '@angular/core';
import { Classroom } from 'src/app/models/classroom.interface';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-room-properties',
  templateUrl: './room-properties.component.html',
  styleUrls: ['./room-properties.component.css'],
})
export class RoomPropertiesComponent {
  classromms: Classroom[] = [];

  constructor(http: HttpClient) {
    http.get<Classroom[]>(environment.apiUrl + '/Classroom').subscribe({
      next: (result) => {
        this.classromms = result;
      },
      error: (error) => {
        console.error(error);
      },
    });
  }
}
