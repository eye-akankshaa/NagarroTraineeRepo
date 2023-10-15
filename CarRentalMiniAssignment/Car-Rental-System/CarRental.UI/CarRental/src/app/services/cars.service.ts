import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { Observable } from 'rxjs/internal/Observable';

@Injectable({
  providedIn: 'root'
})

export class CarsService {
   product:any;
   agreementObj:any;
  constructor(private http: HttpClient,private router:Router) { }

  baseServerUrl = "https://localhost:44326/api/" ;


  
  getProducts(): Observable<any[]> {
    return this.http.get<any[]>('https://localhost:44326/api/Car/GetCars');
  }

  findProduct(id:number)
  {
    return this.http.get<any>(`${this.baseServerUrl}Car/FindCar/`+id);
  } 
  
  
  deleteCar(id:number)
  {
    return this.http.delete<any>(`${this.baseServerUrl}Car/DeleteCar/`+id);
  }


  deleteAgreement(id:number)
  {
    return this.http.delete<any>(`${this.baseServerUrl}RentalAgreement/DeleteAgreement/`+id);
  }

  getRentalAgreement(id:number): Observable<any>{
    return this.http.get<any>(`${this.baseServerUrl}RentalAgreement/GetAgreements?agreementId=${id}`);
    //  return this.http.get<any>(`${this.baseServerUrl}RentalAgreement/GetAgreementById?agreementId=${id}`);
  }

  

  GetAgreementOfUser(id:number): Observable<any[]> {
    return this.http.get<any[]>(`${this.baseServerUrl}RentalAgreement/GetAgreementOfUser?id=${id}`);
  }
  
  GetAllAgreement(): Observable<any[]> {
    return this.http.get<any[]>(`${this.baseServerUrl}RentalAgreement/GetAllAgreement`);
  }
  

  addAgreementDetails(product:Array<string>)
  {
    
    return this.http.post(this.baseServerUrl + "RentalAgreement/AddAgreement",
      {
        UserId:product[0],
        VehicleId:product[1],
        Maker:product[2],
        Model:product[3],
        StartDate:product[4],
        EndDate:product[5],
        RentalDuration:product[6],
        TotalPrice:product[7],
        isReturnRequired:product[8]
       // CarVehicleId: product[9],
        // Car:product[8],
        // User:product[9]
      },
      {
      responseType:'text',
    });
  }

  updateAgreement(productObj:any)
  {
    console.log(productObj);
    this.agreementObj = {
    agreementID: productObj[0],
    userId: productObj[1],
    vehicleId: productObj[2],
    Maker:productObj[3],
    Model:productObj[4],
    startDate: productObj[5],
    endDate: productObj[6],
    rentalDuration: productObj[7],
    totalPrice: productObj[8],
    isReturnRequired: productObj[9],
    
    }

    console.log(this.agreementObj);

    return this.http.put<any>(`${this.baseServerUrl}RentalAgreement/UpdateAgreementDetails`,this.agreementObj);
  }

  updateCarDetails(productObj:any)
  {
    this.product = {
      vehicleId: productObj[0],
      maker: productObj[1],
      model: productObj[2],
      rentalPrice: productObj[3],
      availabilityStatus: productObj[4]
    }
    console.log(this.product);
    return this.http.put<any>(`${this.baseServerUrl}Car/UpdateCarDetails`,this.product);
  }
  

  addNewCar(product:Array<string>)
  {
    
    return this.http.post(this.baseServerUrl + "Car/AddCar",
      {
        Maker:product[0],
        Model:product[1],
        RentalPrice:product[2],
        AvailabilityStatus:product[3]
      },
      {
      responseType:'text',
    });
  }



}
