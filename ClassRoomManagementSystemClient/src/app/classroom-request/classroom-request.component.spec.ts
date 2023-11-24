import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ClassroomRequestComponent } from './classroom-request.component';

describe('ClassroomRequestComponent', () => {
  let component: ClassroomRequestComponent;
  let fixture: ComponentFixture<ClassroomRequestComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ClassroomRequestComponent]
    });
    fixture = TestBed.createComponent(ClassroomRequestComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
