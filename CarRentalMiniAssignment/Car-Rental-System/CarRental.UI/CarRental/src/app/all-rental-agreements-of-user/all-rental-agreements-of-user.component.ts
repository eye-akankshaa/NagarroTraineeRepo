import { Component, OnInit } from '@angular/core';
import { AuthService } from '../services/auth.service';
import { CarsService } from '../services/cars.service';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-all-rental-agreements-of-user',
  templateUrl: './all-rental-agreements-of-user.component.html',
  styleUrls: ['./all-rental-agreements-of-user.component.css'],
})
export class AllRentalAgreementsOfUserComponent {
  currentUser: any;
  allAgreement: any;
  isAdmin: any;
  currentAgreementData: any;
  carData: any;
  returnRequired: any = true;
  constructor(
    private carsService: CarsService,
    private authService: AuthService,
    private router: Router,
    private fb: FormBuilder
  ) {}

  ngOnInit() {
    this.fetchAgreements();

    this.isAdmin = this.authService.User.isAdmin;
  }

  fetchAgreements(): void {
    this.authService.getCurrentUserDetails().subscribe(
      (data: any) => {
        this.currentUser = data;
        console.log(this.currentUser);

        this.carsService.GetAgreementOfUser(this.currentUser.userId).subscribe(
          (data: any) => {
            this.allAgreement = data;
            console.log('akansha', this.allAgreement);
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

  backPage() {
    this.router.navigate(['allCars']);
  }

  requestForReturn(id: any) {
    this.carsService.getRentalAgreement(id).subscribe(
      (data: any) => {
        this.currentAgreementData = data;

        this.carsService
          .updateAgreement([
            id ?? '',
            this.currentAgreementData.userId ?? '',
            this.currentAgreementData.vehicleId ?? '',
            this.currentAgreementData.maker ?? '',
            this.currentAgreementData.model ?? '',
            this.currentAgreementData.startDate ?? '',
            this.currentAgreementData.endDate ?? '',
            this.currentAgreementData.rentalDuration ?? '',
            this.currentAgreementData.totalPrice ?? '',
            this.returnRequired ?? '',
           
          ])
          .subscribe((res) => {
            if (res.message == 'agreement updated successfully') {
              this.fetchAgreements();
            } else {
            }
          });
      },
      (error) => {
        console.error(error);
      }
    );
  }
}
