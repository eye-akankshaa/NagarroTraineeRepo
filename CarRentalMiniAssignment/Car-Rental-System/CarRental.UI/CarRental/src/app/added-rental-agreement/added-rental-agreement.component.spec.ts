import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddedRentalAgreementComponent } from './added-rental-agreement.component';

describe('AddedRentalAgreementComponent', () => {
  let component: AddedRentalAgreementComponent;
  let fixture: ComponentFixture<AddedRentalAgreementComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AddedRentalAgreementComponent]
    });
    fixture = TestBed.createComponent(AddedRentalAgreementComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
