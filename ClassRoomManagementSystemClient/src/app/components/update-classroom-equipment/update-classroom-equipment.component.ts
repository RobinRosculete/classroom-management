import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormGroup, FormControl } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { environment } from 'src/environments/environment';
import { Equipment } from 'src/app/models/equipment.interface';

@Component({
  selector: 'app-update-classroom-equipment',
  templateUrl: './update-classroom-equipment.component.html',
  styleUrls: ['./update-classroom-equipment.component.css'],
})
export class UpdateClassroomEquipmentComponent {
  form1!: FormGroup;
  form2!: FormGroup;
  blackOutHour?: blackoutHours;
  equipmentType?: string;

  constructor(
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private http: HttpClient
  ) {}

  ngOnInit() {
    this.form1 = new FormGroup({
      roomId: new FormControl(''),
      blackoutHoursStart: new FormControl(''),
      blackoutHoursEnd: new FormControl(''),
    });

    this.form2 = new FormGroup({
      equipmentId: new FormControl(''),
      equipmentType: new FormControl(''),
    });
  }

  submitBlackoutHours() {
    if (this.form1.valid) {
      const newblackoutHours: blackoutHours = {
        classRoomId: this.form1.get('roomId')?.value,
        blackoutHoursStart: this.form1.get('blackoutHoursStart')?.value,
        blackoutHoursEnd: this.form1.get('blackoutHoursEnd')?.value,
      };
      const url1 =
        environment.apiUrl +
        '/Classroom/update-classroom-blackout-hours/' +
        newblackoutHours.classRoomId;
      this.http.put<blackoutHours>(url1, newblackoutHours).subscribe({
        next: (result) => {
          console.log(
            'New request ' + newblackoutHours.classRoomId + ' has been updated'
          );
        },
        error: (err) => {
          console.log(err);
        },
      });
    } else {
      console.log('BlackOut Hours Form is invalid');
    }
  }
  submitEquipmentType() {
    if (this.form2.valid) {
      const newEquipment: Equipment = {
        equipmentId: this.form2.get('equipmentId')?.value,
        equipmentType: this.form2.get('equipmentType')?.value,
      };
      const url2 =
        environment.apiUrl +
        '/Classroom/update-classroom-equipment/' +
        newEquipment.equipmentId;

      this.http.put<Equipment>(url2, newEquipment).subscribe({
        next: (result) => {
          console.log(
            'New request ' + newEquipment.equipmentId + ' has been updated'
          );
        },
        error: (err) => {
          console.log(err);
        },
      });
    } else {
      console.log('Equipment Form is invalid');
    }
  }
}

interface blackoutHours {
  classRoomId: number;
  blackoutHoursStart: string;
  blackoutHoursEnd: string;
}
