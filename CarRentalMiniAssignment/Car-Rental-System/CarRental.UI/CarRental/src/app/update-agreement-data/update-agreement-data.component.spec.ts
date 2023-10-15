import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateAgreementDataComponent } from './update-agreement-data.component';

describe('UpdateAgreementDataComponent', () => {
  let component: UpdateAgreementDataComponent;
  let fixture: ComponentFixture<UpdateAgreementDataComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [UpdateAgreementDataComponent]
    });
    fixture = TestBed.createComponent(UpdateAgreementDataComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
