import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AllRentalAgreementsOfUserComponent } from './all-rental-agreements-of-user.component';

describe('AllRentalAgreementsOfUserComponent', () => {
  let component: AllRentalAgreementsOfUserComponent;
  let fixture: ComponentFixture<AllRentalAgreementsOfUserComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AllRentalAgreementsOfUserComponent]
    });
    fixture = TestBed.createComponent(AllRentalAgreementsOfUserComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
