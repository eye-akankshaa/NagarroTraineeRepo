import { Component , OnInit, ChangeDetectorRef, } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AuthService } from '../services/auth.service';
import { CarsService } from '../services/cars.service';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-new-car',
  templateUrl: './add-new-car.component.html',
  styleUrls: ['./add-new-car.component.css']
})
export class AddNewCarComponent implements OnInit{
  availabilityStatus:any = true;
  constructor(private carsService: CarsService, private route: ActivatedRoute, private cdr: ChangeDetectorRef,private authService: AuthService,private router: Router) {
  }

  ngOnInit(): void {

  }

  addNewCarForm = new FormGroup({
    
    maker: new FormControl("",[Validators.required,Validators.minLength(2),Validators.maxLength(100)]),
    model: new FormControl("",[Validators.required,Validators.minLength(2),Validators.maxLength(100)]),
    rentalPrice: new FormControl("",[Validators.required,Validators.pattern("^[0-9]*$")])
    });


    onSubmit(){
      console.log("works");
      this.carsService.addNewCar([
        this.addNewCarForm.value.maker ?? "",
        this.addNewCarForm.value.model ?? "",
        this.addNewCarForm.value.rentalPrice ?? "",
        this.availabilityStatus,
      ])
      .subscribe(res => {
        if (res) {
        console.log(res);
        this.authService.openSnackBar('Car added successfully','Close');
        this.router.navigate(['/allCars']);
       }
        else {
         //  alert("Car not added");
         this.authService.openSnackBar('Car added successfully','Close');
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
