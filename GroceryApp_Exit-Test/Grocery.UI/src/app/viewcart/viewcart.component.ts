import { ChangeDetectorRef, Component, OnInit } from '@angular/core';

import { Location } from '@angular/common';
import { ProductService } from 'src/app/services/product.service';
import { Product } from '../admin-add-product/admin-add-product.component';
import { AuthService } from '../services/auth.service';
import { Order } from '../Models/User';
import { Router } from '@angular/router';


@Component({
  selector: 'app-viewcart',
  templateUrl: './viewcart.component.html',
  styleUrls: ['./viewcart.component.css']
})

export class ViewcartComponent implements OnInit {




  // cartItems: any[] = [];

  // orderObj!: Order



  defaultQuantity: number = 1;

  totalPrice = 0;

  totalQuantity = 0;



  Products: Product[] = [];

  Quantity: number[] = [];



  constructor(private productService: ProductService, private cdr: ChangeDetectorRef, private location: Location, private authervice: AuthService,private router:Router) { }




  ngOnInit(): void {

    this.getCartItems(this.authervice.User.registerId);

  }




  ngAfterViewInit(): void {




    this.cdr.detectChanges();

  }




  increaseQuantity(index: number) {

    if (this.Quantity[index] + 1 <= this.Products[index].quantity)

      this.Quantity[index]++;

    else

      alert(`Currently we only have ${this.Products[index].quantity} of this item in stock!`);

  }




  decreaseQuantity(index: number) {

    if (this.Quantity[index] - 1 >= 1)

      this.Quantity[index]--;

  }




  deleteItemFromCart(productId: number) {

    if (confirm("Do you really want to remove this item from cart?")) {

      this.productService.removeItemFromCart(productId,this.authervice.User.registerId).subscribe({

        next: (res) => {

          alert(res.message);
          this.getCartItems(this.authervice.User.registerId);

          // this.location.go(this.location.path());

          // location.reload();

        },

        error: (err) => { alert(err?.error.message) },
         complete: ()=>
         {
          this.reloadComponent();
         }
      });

    }

  }




  getCartItems(id: number) {
    this.productService.getCartItems(id).subscribe(
      (response: any[]) => {
        const products = response.map(item => item.product);
        const quantities = response.map(item => item.quantity);

        console.log(response)
        this.Products = products;

        this.Quantity = quantities;
        
        console.log("Here is the products array:");

        console.log(this.Products);

        console.log("Here is the quantity array:");

        console.log(this.Quantity);

      },

      (error: any) => {

        console.log(error);

      }

    );

  }




  calculteTotalPrice() {

    for (let i = 0; i < this.Products.length; i++) {

      this.totalPrice += (this.Products[i].price - (this.Products[i].price) * (this.Products[i].discount / 100)) * this.Quantity[i];

    }

  }




  placeOrder() {

    this.calculteTotalPrice();

    for (let i = 0; i < this.Quantity.length; i++) {

      this.totalQuantity += this.Quantity[i];

    }

    console.log(this.totalPrice);

    console.log(this.totalQuantity);

    
    console.log(this.authervice.User.registerId);




    const orderObj: Order = { registerId: 0, totalPrice: 0, quantityOfItems: 0, updatedQuantities: this.Quantity };

    orderObj.totalPrice = this.totalPrice;

    orderObj.quantityOfItems = this.totalQuantity;

    orderObj.registerId = this.authervice.User.registerId;



    console.log(orderObj);




    this.productService.placeOrder(orderObj).subscribe((res) => {

      alert(res.message);

    });

  }


  reloadComponent(): void {

    this.router.navigateByUrl('/dummy', { skipLocationChange: true }).then(() => {

      this.router.navigate([this.router.url]);

    });

  }
}