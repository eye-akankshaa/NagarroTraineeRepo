import { Component, OnInit } from '@angular/core';
import { AuthService } from '../services/auth.service';
import { CarsService } from '../services/cars.service';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-all-rental-agreement',
  templateUrl: './all-rental-agreement.component.html',
  styleUrls: ['./all-rental-agreement.component.css'],
})
export class AllRentalAgreementComponent implements OnInit {
  allAgreements: any;
  carData: any;
  availabilityStatus: any = true;

  agreementId: number = 0;

  currentUser: any;
  currentAgreementData: any;

  chosenProduct!: any;
  choseProductId: number = 0;

  returnRequired: any = false;
  totalPrice: number = 0;
  tDuration: any = 0;

  constructor(
    private carsService: CarsService,
    private authService: AuthService,
    private router: Router,
    private fb: FormBuilder
  ) {}
  ngOnInit() {
    this.fetchAgreements();
  }

  fetchAgreements() {
    this.carsService.GetAllAgreement().subscribe(
      (data: any) => {
        console.log(data);
        this.allAgreements = data;
      },
      (error) => {
        console.error(error);
      }
    );
  }

  deleteAgreementByAdmin(id: any) {
    this.carsService.getRentalAgreement(id).subscribe(
      (data: any) => {
        this.currentAgreementData = data;

        this.carsService.deleteAgreement(id).subscribe(
          (data: any) => {
            if (data.message === 'Agreement Deleted!') {
              this.carsService
                .findProduct(this.currentAgreementData.vehicleId)
                .subscribe(
                  (d: any) => {
                    this.carData = d;

                    console.log(this.carData);

                    this.carsService
                      .updateCarDetails([
                        this.carData.vehicleId ?? '',

                        this.carData.maker ?? '',

                        this.carData.model ?? '',

                        this.carData.rentalPrice ?? '',

                        this.availabilityStatus ?? '',
                      ])

                      .subscribe((res) => {
                        if (res.message == 'Car updated successfully') {
                          this.authService.openSnackBar(
                            'Agreement deleted successfully',
                            'Close'
                          );
                          this.router.navigate(['/allRentalAgreement']);

                          this.fetchAgreements();
                        } else {
                        }
                      });
                  },

                  (error) => {
                    console.error(error);
                  }
                );

              //
            } else {
              //alert('Delete Unsuccessful')
              this.authService.openSnackBar(' delete unsuccessfull', 'Close');
            }
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

  UpdateAgreement(id: any) {
    this.router.navigate(['updateAgreementData', id]);
  }

  logout() {
    this.authService.logout();
  }

  back() {
    this.router.navigate(['allCars']);
  }
}
