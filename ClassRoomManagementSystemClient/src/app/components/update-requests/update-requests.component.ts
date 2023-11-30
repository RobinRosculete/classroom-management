import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Request } from 'src/app/models/requests.interface';

@Component({
  selector: 'app-update-requests',
  templateUrl: './update-requests.component.html',
  styleUrls: ['./update-requests.component.css'],
})
export class UpdateRequestsComponent {
  requests: Request[] = [];
  constructor(http: HttpClient) {
    http.get<Request[]>(environment.apiUrl + '/Request').subscribe({
      next: (result) => {
        this.requests = result;
      },
      error: (error) => {
        console.error(error);
      },
    });
  }
}
