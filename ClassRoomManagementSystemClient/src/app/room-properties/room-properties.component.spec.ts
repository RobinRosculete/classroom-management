import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RoomPropertiesComponent } from './room-properties.component';

describe('RoomPropertiesComponent', () => {
  let component: RoomPropertiesComponent;
  let fixture: ComponentFixture<RoomPropertiesComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [RoomPropertiesComponent]
    });
    fixture = TestBed.createComponent(RoomPropertiesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
