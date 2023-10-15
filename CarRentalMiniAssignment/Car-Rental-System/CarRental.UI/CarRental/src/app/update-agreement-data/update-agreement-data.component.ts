import { Component, OnInit } from '@angular/core';
import { AuthService } from '../services/auth.service';
import { CarsService } from '../services/cars.service';
import { Router } from '@angular/router';
import { ActivatedRoute } from '@angular/router';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { ConnectableObservable } from 'rxjs';
import { DatePipe } from '@angular/common';
@Component({
  selector: 'app-update-agreement-data',
  templateUrl: './update-agreement-data.component.html',
  styleUrls: ['./update-agreement-data.component.css'],
})
export class UpdateAgreementDataComponent implements OnInit {
  agreementId: number = 0;
  carData: any;
  currentUser: any;
  currentAgreementData: any;
  chosenProduct!: any;
  choseProductId: number = 0;
  returnRequired: any = false;
  totalPrice: number = 0;
  tDuration: any = 0;
  startdate: any;
  enddate: any;
  currentDate: any = new Date();
  minDate: string;
  constructor(
    private datePipe: DatePipe,
    private carsService: CarsService,
    private route: ActivatedRoute,
    private authService: AuthService,
    private router: Router
  ) {
    const currentdate = new Date();
    const nextDay = new Date();
    nextDay.setDate(currentdate.getDate() + 1);

    this.minDate = this.datePipe.transform(nextDay, 'yyyy-MM-dd')!;
  }

  ngOnInit(): void {
    let strProductId = this.route.snapshot.paramMap.get('id');
    this.agreementId = Number(strProductId);

    this.carsService.getRentalAgreement(this.agreementId).subscribe(
      (data: any) => {
        this.currentAgreementData = data;
        this.tDuration = data.rentalDuration;

        this.startdate = this.datePipe.transform(
          this.currentAgreementData.startDate,
          'yyyy-MM-dd'
        );
        this.enddate = this.datePipe.transform(
          this.currentAgreementData.endDate,
          'yyyy-MM-dd'
        );

        this.carsService
        .findProduct(this.currentAgreementData.vehicleId)
        .subscribe(
          (data: any) => {
            this.carData = data;
            console.log(this.carData);
          },
          (error) => {
            console.error(error);
          }
        );


      },
      (error) => {
        console.error(error);
      }
    );
   
  }

  findTotalDuration(event: any) {
    const temp: any = this.datePipe.transform(event.target.value, 'dd');
    console.log(
      event.target.value,
      this.datePipe.transform(this.currentDate, 'yyyy-MM-dd')
    );

    const d1: Date = new Date(event.target.value); // Date from input
    const d2: Date = new Date(this.currentDate); // Current date

    d1.setHours(0, 0, 0, 0);
    d2.setHours(0, 0, 0, 0);

    const timeDifference = d1.getTime() - d2.getTime();

    this.tDuration = Math.abs(Math.floor(timeDifference / (1000 * 3600 * 24)));
  }

  rentalForm = new FormGroup({
    startDate: new FormControl(''),
    endDate: new FormControl(''),
    totalDuration: new FormControl(''),
  });

  onSubmit() {
    this.tDuration = this.rentalForm.value.totalDuration;

    this.totalPrice = this.tDuration * this.carData.rentalPrice;

    this.carsService
      .updateAgreement([
        this.agreementId ?? '',
        this.currentAgreementData.userId ?? '',
        this.currentAgreementData.vehicleId ?? '',
        this.currentAgreementData.maker ?? '',
        this.currentAgreementData.model ?? '',
        this.rentalForm.value.startDate ?? '',
        this.rentalForm.value.endDate ?? '',
        this.rentalForm.value.totalDuration ?? '',
        this.totalPrice ?? '',
        this.returnRequired ?? '',
      ])
      .subscribe((res) => {
        if (res.message == 'agreement updated successfully') {
          this.authService.openSnackBar(
            'Agreement updated successfully',
            'Close'
          );
          this.router.navigate(['/allRentalAgreement']);
        } else {
          this.authService.openSnackBar(
            'Agreement updated successfully',
            'Close'
          );
        }
      });
  }

  back() {
    this.router.navigate(['/allRentalAgreement']);
  }
}
