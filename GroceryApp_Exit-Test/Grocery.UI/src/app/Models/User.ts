 export interface User{
    registerId:number;
    name:string;
    email:string;
    isAdmin:boolean;
}

export interface Cart {
    cartId:number
    productId:number
    quantity:number
    RegisterId:number
}



export interface Order {
    totalPrice:number
    quantityOfItems:number
    registerId:number
}

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

  export interface Order {
    totalPrice:number
    quantityOfItems:number
    registerId:number
    updatedQuantities:number[]
}

  export interface Review{
    reviewId:number
    productId:number
    registerId:number
    comment:string
  }