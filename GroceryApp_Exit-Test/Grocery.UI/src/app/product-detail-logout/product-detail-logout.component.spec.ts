import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductDetailLogoutComponent } from './product-detail-logout.component';

describe('ProductDetailLogoutComponent', () => {
  let component: ProductDetailLogoutComponent;
  let fixture: ComponentFixture<ProductDetailLogoutComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ProductDetailLogoutComponent]
    });
    fixture = TestBed.createComponent(ProductDetailLogoutComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
