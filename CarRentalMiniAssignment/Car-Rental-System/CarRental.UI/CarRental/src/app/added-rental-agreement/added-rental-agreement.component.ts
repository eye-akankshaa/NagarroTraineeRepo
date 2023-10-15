import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AuthService } from '../services/auth.service';
import { CarsService } from '../services/cars.service';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-added-rental-agreement',
  templateUrl: './added-rental-agreement.component.html',
  styleUrls: ['./added-rental-agreement.component.css'],
})
export class AddedRentalAgreementComponent implements OnInit {
  title = 'setDefaultdate';

  selectedDate: any = this.datePipe.transform(new Date(), 'yyyy-MM-dd');

  chosenProduct!: any;
  choseProductId: number = 0;
  totalPrice: number = 0;
  tDuration: any = 0;
  currentUser: any;
  returnRequired: any = false;
  currentDate: any = new Date();
  minDate: string;

  constructor(
    private datePipe: DatePipe,
    private carsService: CarsService,
    private route: ActivatedRoute,
    private cdr: ChangeDetectorRef,
    private authService: AuthService,
    private router: Router
  ) {
    const currentdate = new Date();
    const nextDay = new Date();
    nextDay.setDate(currentdate.getDate() + 1);

    this.minDate = this.datePipe.transform(nextDay, 'yyyy-MM-dd')!;
  }

  ngOnInit(): void {
    //fetching vehicle id
    let strProductId = this.route.snapshot.paramMap.get('id');
    this.choseProductId = Number(strProductId);

    this.getProduct(this.choseProductId);

    this.authService.getCurrentUserDetails().subscribe(
      (data: any) => {
        this.currentUser = data;
        console.log(this.currentUser);
      },
      (error) => {
        console.error(error);
      }
    );
  }

  rentalForm = new FormGroup({
    startDate: new FormControl(''),
    endDate: new FormControl(''),
    totalDuration: new FormControl(''),
  });

  findTotalDuration(event: any) {
    const temp: any = this.datePipe.transform(event.target.value, 'dd');

    console.log();

    this.tDuration = Math.abs(this.currentDate.getDate() - parseInt(temp, 10));
  }

  getProduct(id: number) {
    this.carsService.findProduct(id).subscribe({
      next: (temp) => {
        this.chosenProduct = temp;
      },
      error: (res) => {
        console.log(res);
      },
    });
  }

 
  onSubmit() {
    this.tDuration = this.rentalForm.value.totalDuration;
    this.totalPrice = this.tDuration * this.chosenProduct.rentalPrice;
    console.log(this.totalPrice);
    console.log(this.currentUser.userId);
    console.log(this.chosenProduct.vehicleId);
    this.carsService
      .addAgreementDetails([
        this.currentUser.userId,
        this.chosenProduct.vehicleId,
        this.chosenProduct.maker,
        this.chosenProduct.model,
        this.rentalForm.value.startDate ?? '',
        this.rentalForm.value.endDate ?? '',
        this.rentalForm.value.totalDuration ?? '',
        this.totalPrice,
        this.returnRequired,
        this.chosenProduct.vehicleId,
      ])
      .subscribe((res) => {
        if (res) {
         
          this.router.navigate(['confirmRentalAgreement', res]);
        } else {
          alert('Product not added');
        }
      });
  }

  get startDate(): FormControl {
    return this.rentalForm.get('startDate') as FormControl;
  }

  get endDate(): FormControl {
    return this.rentalForm.get('endDate') as FormControl;
  }

  get totalDuration(): FormControl {
    return this.rentalForm.get('totalDuration') as FormControl;
  }
}
