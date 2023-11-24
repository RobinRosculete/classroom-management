import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RoomAssignmentsComponent } from './room-assignments.component';

describe('RoomAssignmentsComponent', () => {
  let component: RoomAssignmentsComponent;
  let fixture: ComponentFixture<RoomAssignmentsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [RoomAssignmentsComponent]
    });
    fixture = TestBed.createComponent(RoomAssignmentsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
