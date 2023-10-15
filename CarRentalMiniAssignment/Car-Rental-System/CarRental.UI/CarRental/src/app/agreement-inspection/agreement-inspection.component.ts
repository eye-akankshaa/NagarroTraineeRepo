import { Component, OnInit } from '@angular/core';
import { AuthService } from '../services/auth.service';
import { CarsService } from '../services/cars.service';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-agreement-inspection',
  templateUrl: './agreement-inspection.component.html',
  styleUrls: ['./agreement-inspection.component.css'],
})
export class AgreementInspectionComponent implements OnInit {
  allAgreements: any;
  carData: any;
  availabilityStatus: any = true;
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

  deleteAgreementByAdmin(id: any, vehileId: any) {
    this.carsService.deleteAgreement(id).subscribe(
      (data: any) => {
        if (data.message === 'Agreement Deleted!') {
          this.carsService.findProduct(vehileId).subscribe((res) => {
            if (res) {
              this.carData = res;

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
                    this.authService.openSnackBar('Inspection done', 'Close');

                    this.router.navigate(['/agreementInspection']);

                    this.fetchAgreements();
                  } else {
                    ('Car not updated');
                  }
                });
            } else {
              ('Car not updated');
            }
          });
        } else alert('Cancel agreement Unsuccessful');
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
