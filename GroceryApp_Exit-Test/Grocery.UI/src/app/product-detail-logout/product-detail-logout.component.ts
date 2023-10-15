
import { Component, OnInit, ChangeDetectorRef, } from '@angular/core';

import { ActivatedRoute } from '@angular/router';

import { ProductService } from 'src/app/services/product.service';

import { Cart } from '../Models/User';

import { AuthService } from '../services/auth.service';


interface Product {

  productId:number;

  productName: string;

  description: string;

  category: string;

  quantity: number;

  price: number;

  discount: number;

  specification: string;

  data: string;

}
@Component({
  selector: 'app-product-detail-logout',
  templateUrl: './product-detail-logout.component.html',
  styleUrls: ['./product-detail-logout.component.css']
})

export class ProductDetailLogoutComponent implements OnInit{

  chosenProduct!: Product;
  choseProductId: number = 0;
  discountedPrice!: number;
  defaultQuantity: number = 1;

  totalProducts: Product[]; 
  displayedProducts: Product[] = [];
  itemsPerPage = 4;

  cartObj: Cart = { cartId:0,RegisterId: 0, productId: 0, quantity: 0 };
 // reviewObj:Review={reviewId:0,registerId:0,productId:0,comment:''};

  constructor(private productService: ProductService, private route: ActivatedRoute, private cdr: ChangeDetectorRef,private authService:AuthService) {
  }
  ngOnInit(): void {

    
    let strProductId = this.route.snapshot.paramMap.get('id');

    this.choseProductId = Number(strProductId);

    this.getProduct(this.choseProductId);

  }

  ngAfterViewInit(): void {

    // Call your function here

    this.calculateDiscountedPrice();

    this.cdr.detectChanges();
  }
  calculateDiscountedPrice() {

    this.discountedPrice = this.chosenProduct.price - ((this.chosenProduct.discount / 100) * this.chosenProduct.price);

  }

  getProduct(id: number) {
    this.productService.findProduct(id).subscribe({
      next: (temp) => {
        this.chosenProduct = temp;
      },
     error: (res) => {
        console.log(res);
      }
    });
  }


  increaseQuantity() {
    if (this.defaultQuantity + 1 > this.chosenProduct.quantity)
      alert(`Currently we only have ${this.chosenProduct.quantity} of this item in stock!`);
    else
      this.defaultQuantity++;
  }
  decreaseQuantity() {
    if (this.defaultQuantity > 1)
      this.defaultQuantity--;
  }

  addToCart()
  {
   this.cartObj.RegisterId = this.authService.User.registerId;

    this.cartObj.productId = this.chosenProduct.productId;

    this.cartObj.quantity = this.defaultQuantity;
    this.cartObj.RegisterId = this.authService.User.registerId;
    
    this.productService.addToCart(this.cartObj).subscribe((res)=>{
        alert(res.message);
    });
  }


}
