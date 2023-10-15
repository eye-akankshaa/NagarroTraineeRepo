import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AgreementInspectionComponent } from './agreement-inspection.component';

describe('AgreementInspectionComponent', () => {
  let component: AgreementInspectionComponent;
  let fixture: ComponentFixture<AgreementInspectionComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AgreementInspectionComponent]
    });
    fixture = TestBed.createComponent(AgreementInspectionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
