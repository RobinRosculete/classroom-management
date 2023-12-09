import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { environment } from 'src/environments/environment';
import { FormGroup, FormControl } from '@angular/forms';
import { NewRequest } from 'src/app/models/newRequest.interface';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-update-requests',
  templateUrl: './update-requests.component.html',
  styleUrls: ['./update-requests.component.css'],
})
export class UpdateRequestsComponent {
  newRequest?: NewRequest;
  // the form model
  form!: FormGroup;
  constructor(
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private http: HttpClient
  ) {}

  ngOnInit() {
    this.form = new FormGroup({
      Id: new FormControl(''),
      Day: new FormControl(''),
      StartTime: new FormControl(''),
      EndTime: new FormControl(''),
    });
  }

  onSubmit() {
    if (this.form.valid) {
      const newRequest: NewRequest = {
        requestId: this.form.get('Id')?.value,
        day: this.form.get('Day')?.value,
        startTime: this.form.get('StartTime')?.value,
        endTime: this.form.get('EndTime')?.value,
      };

      const url = environment.apiUrl + '/Request/' + newRequest.requestId;

      this.http.put<NewRequest>(url, newRequest).subscribe({
        next: (result) => {
          console.log(
            'New request ' + newRequest.requestId + ' has been updated'
          );
        },
        error: (err) => {
          console.log(err);
        },
      });
    } else {
      console.log('Form is invalid');
    }
  }
}
