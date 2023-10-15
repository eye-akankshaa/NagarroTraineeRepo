import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddNewCarComponent } from './add-new-car.component';

describe('AddNewCarComponent', () => {
  let component: AddNewCarComponent;
  let fixture: ComponentFixture<AddNewCarComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AddNewCarComponent]
    });
    fixture = TestBed.createComponent(AddNewCarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
