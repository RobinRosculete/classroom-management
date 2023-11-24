import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateRequestsComponent } from './update-requests.component';

describe('UpdateRequestsComponent', () => {
  let component: UpdateRequestsComponent;
  let fixture: ComponentFixture<UpdateRequestsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [UpdateRequestsComponent]
    });
    fixture = TestBed.createComponent(UpdateRequestsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
