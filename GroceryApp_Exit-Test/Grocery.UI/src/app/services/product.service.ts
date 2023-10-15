import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs/internal/Observable';
import { Product } from '../admin-add-product/admin-add-product.component';
import { Order } from '../Models/User';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(private http: HttpClient,private router:Router) 
  { 
    
  }
  baseServerUrl = "https://localhost:44325/api/" ;

  
  addProduct(product:Array<string>)
  {
    
    return this.http.post(this.baseServerUrl + "GroceryStore/AddProduct",
      {
        ProductName:product[0],
        Description:product[1],
        Category:product[2],
        Quantity:product[3],
        Price:product[4],
        Discount:product[5],
        Specification:product[6],
        Data: product[7]
      },
      {
      responseType:'text',
    });
  }
 
  fetchProduct(productId: string): Observable<Product> {
    const url = this.baseServerUrl + 'GroceryStore/GetProducts/' + productId;
    return this.http.get<Product>(url);
  }
  
  getProducts(): Observable<Product[]> {
    return this.http.get<Product[]>('https://localhost:44325/api/GroceryStore/GetProducts/');
  }
  


deleteProduct(id:number)
  {
    return this.http.delete<any>(`${this.baseServerUrl}GroceryStore/DeleteProduct/`+id);
  }

  findProduct(id:number)
  {
    return this.http.get<Product>(`${this.baseServerUrl}GroceryStore/FindProduct/`+id);
  } 
 updateProduct(productObj:any)
  {
    return this.http.put<any>(`${this.baseServerUrl}GroceryStore/UpdateProduct`,productObj);
  }

  addToCart(cartObj:any)
  {
    console.log('here');
    return this.http.post<any>(`${this.baseServerUrl}GroceryStore/AddToCart`,cartObj);
  }

  // https://localhost:44325/api/GroceryStore/GetCartItems?registerId=10
  getCartItems(registerId:number) {

    return this.http.get<any>(`${this.baseServerUrl}GroceryStore/GetCartItems?registerId=${registerId}`);

  }
  removeItemFromCart(productId:number,registerId:number)
  {
    debugger
    return this.http.delete<any>(`${this.baseServerUrl}GroceryStore/RemoveItemFromCart/`+productId+ `/` + registerId);
  }

  // placeOrder(orderObj:Order)
  // {
  //   return this.http.post<any>(`${this.baseServerUrl}GroceryStore/PlaceOrder`,orderObj);
  // }

  placeOrder(orderObj:Order)
  {
    console.log("in service");
    console.log(orderObj);
    return this.http.post<any>(`${this.baseServerUrl}GroceryStore/PlaceOrder`,orderObj);
  }

  getOrders(id:number)
  {
    return this.http.get<any>(`${this.baseServerUrl}GroceryStore/GetOrders?registerId=${id}`);
  }
}
