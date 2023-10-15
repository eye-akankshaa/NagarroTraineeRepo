import { Component , OnInit, ChangeDetectorRef, } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AuthService } from '../services/auth.service';
import { CarsService } from '../services/cars.service';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-update-car-details',
  templateUrl: './update-car-details.component.html',
  styleUrls: ['./update-car-details.component.css']
})
export class UpdateCarDetailsComponent implements OnInit{
  availabilityStatus:any = true;
  carData:any;
  carId:any;
  constructor(private carsService: CarsService, private route: ActivatedRoute, private cdr: ChangeDetectorRef,private authService: AuthService,private router: Router) {
  }

  ngOnInit(): void {
    let strCarId = this.route.snapshot.paramMap.get('id');
    this.carId = Number(strCarId);
  
    this.carsService.findProduct(this.carId).subscribe(
      res => {
        if (res) {
          this.carData=res;
      }
        else {
           ("Car not updated");
         }
      });
    

  }

  addNewCarForm = new FormGroup({
    
    maker: new FormControl("",[Validators.required,Validators.pattern("[A-Za-z ]+")]),
    model: new FormControl("",[Validators.required,Validators.pattern("[A-Za-z ]+")],),
    rentalPrice: new FormControl("",[Validators.required,Validators.pattern("^[0-9]*$")])
    
    });


    onSubmit(){
    
      this.carsService.updateCarDetails([
        this.carId??"",
        this.addNewCarForm.value.maker ?? "",
        this.addNewCarForm.value.model ?? "",
        this.addNewCarForm.value.rentalPrice ?? "",
        this.availabilityStatus??"",
      ])
      .subscribe(res => {
        if (res.message == "Car updated successfully") {
       
          this.authService.openSnackBar('Car updated successfully','Close');
          this.router.navigate(['/allCars']);
        
      }
        else {
         
          this.authService.openSnackBar('Car not updated','Close');
         }
      
      
      });
    }

 
    get Maker(): FormControl {
      return this.addNewCarForm.get("maker") as FormControl;
    }

    get Model(): FormControl {
      return this.addNewCarForm.get("model") as FormControl;
    }
    get RentalPrice(): FormControl {
      return this.addNewCarForm.get("rentalPrice") as FormControl;
    }



}































