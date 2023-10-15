import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ConfirmRentalAgreementComponent } from './confirm-rental-agreement.component';

describe('ConfirmRentalAgreementComponent', () => {
  let component: ConfirmRentalAgreementComponent;
  let fixture: ComponentFixture<ConfirmRentalAgreementComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ConfirmRentalAgreementComponent]
    });
    fixture = TestBed.createComponent(ConfirmRentalAgreementComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
