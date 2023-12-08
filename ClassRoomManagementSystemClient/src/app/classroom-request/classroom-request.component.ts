import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { ClassroomRequest } from '../models/classroomRequest.interface';

@Component({
  selector: 'app-classroom-request',
  templateUrl: './classroom-request.component.html',
  styleUrls: ['./classroom-request.component.css'],
})
export class ClassroomRequestComponent implements OnInit {
  form: FormGroup;
  request?: ClassroomRequest;
  constructor(
    private formBuilder: FormBuilder,
    private http: HttpClient // Inject HttpClient
  ) {
    this.form = this.formBuilder.group({
      day: ['', Validators.required],
      startTime: ['', Validators.required],
      endTime: ['', Validators.required],
      courseTitle: ['', Validators.required],
      year: ['', Validators.required],
      semester: ['', Validators.required],
      departmentName: ['', Validators.required],
    });
  }

  ngOnInit() {}

  onSubmit() {
    if (this.form.valid) {
      const request: ClassroomRequest = {
        day: this.form.controls['day'].value,
        startTime: this.form.controls['startTime'].value,
        endTime: this.form.controls['endTime'].value,
        courseTitle: this.form.controls['courseTitle'].value,
        year: this.form.controls['year'].value,
        semester: this.form.controls['semester'].value,
        departmentName: this.form.controls['departmentName'].value,
      };

      this.http
        .post(environment.apiUrl + '/Request/section-request', request)
        .subscribe(
          (response) => {
            console.log('Post request successful:', response);
          },
          (error) => {
            console.error('Error occurred:', error);
          }
        );
    } else {
      console.log('Form is invalid');
    }
  }
}
