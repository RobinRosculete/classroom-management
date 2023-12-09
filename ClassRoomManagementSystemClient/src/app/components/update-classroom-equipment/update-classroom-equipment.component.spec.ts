import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateClassroomEquipmentComponent } from './update-classroom-equipment.component';

describe('UpdateClassroomEquipmentComponent', () => {
  let component: UpdateClassroomEquipmentComponent;
  let fixture: ComponentFixture<UpdateClassroomEquipmentComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [UpdateClassroomEquipmentComponent]
    });
    fixture = TestBed.createComponent(UpdateClassroomEquipmentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
