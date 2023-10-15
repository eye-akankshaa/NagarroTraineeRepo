
import { Component, OnInit } from '@angular/core';
import { ProductService } from 'src/app/services/product.service';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-myorders',
  templateUrl: './myorders.component.html',
  styleUrls: ['./myorders.component.css']
})

export class MyordersComponent implements OnInit{
  orderDetails!: any [];

  constructor(private productService:ProductService,private authService:AuthService) {

  
  }

  ngOnInit(): void {

    this.productService.getOrders(this.authService.User.registerId)

      .subscribe(

        (response) => {

          console.log(response);
          console.log("The userId is : "+this.authService.User.registerId);

          this.orderDetails = response;

          this.orderDetails.forEach(element => {

            var temp:string = element.orderDate;

            var dateOnly = temp.substring(0,10);

            element.orderDate = dateOnly;

          });

          console.log(this.orderDetails);

        },

        (error) => {

          console.error(error);

        }

      );

  }




}
