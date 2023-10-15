import { Component, OnInit } from '@angular/core';
import { AuthService } from '../services/auth.service';
import { CarsService } from '../services/cars.service';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Car } from '../Models/car';

@Component({
  selector: 'app-all-cars',
  templateUrl: './all-cars.component.html',
  styleUrls: ['./all-cars.component.css'],
})
export class AllCarsComponent implements OnInit {
//  cars: Car = [];
  cars: any[] = [];
  currentUser: any;
  isAdmin: any;

  currentPage: number = 1;
  pageSize: number = 3;
  totalItems: number = 0;
  totalPages: number = 0;
  pages: number[] = [];
  searchQuery: string = '';
  selectedCategory: string = 'All Products';
  fg!: FormGroup;
  Categories: string[] = [];
  modelFilter: string = '';
  makerFilter: string = '';
  priceFilter: number | null = null;
  filteredCars: any[] = [];
  availableModels: string[] = [];
  availableMakers: string[] = [];

  constructor(
    private carsService: CarsService,
    private authService: AuthService,
    private router: Router,
    private fb: FormBuilder
  ) {}
  currentUserEmail = '';
  currentUserName = '';
  ngOnInit() {
    this.fetchCars();

    console.log('akansha   ', this.authService.User.userId);

    this.isAdmin = this.authService.User.isAdmin;

    this.fg = this.fb.group({
      search: [''],
    });
  }

  fetchCars(): void {
    this.carsService.getProducts().subscribe(
      (data: any) => {
        this.cars = data;
        this.Categories = [
          ...new Set(this.cars.map((product) => product.category)),
        ];
        this.extractAvailableModels();
        this.extractAvailableMakers();
        this.applyFilters();
        console.log(this.cars);
      },
      (error) => {
        console.error(error);
      }
    );
  }

  extractAvailableModels(): void {
    this.availableModels = [...new Set(this.cars.map((car) => car.model))];
  }

  extractAvailableMakers(): void {
    this.availableMakers = [...new Set(this.cars.map((car) => car.maker))];
  }

  applyFilters(): void {
    this.filteredCars = this.cars.filter((car) => {
      const modelMatch =
        !this.modelFilter ||
        car.model.toLowerCase().includes(this.modelFilter.toLowerCase());
      const makerMatch =
        !this.makerFilter ||
        car.maker.toLowerCase().includes(this.makerFilter.toLowerCase());
      const priceMatch =
        this.priceFilter === null || car.rentalPrice <= this.priceFilter;
      return modelMatch && makerMatch && priceMatch;
    });
  }

  onCarDetails(id: number) {
    if (this.authService.isUserLogin)
      this.router.navigate(['addedRentalAgreement', id]);
    else {
      console.log('not fetched');
      this.router.navigate(['addedRentalAgreement', id]);
    }
  }

  logout() {
    this.authService.logout();
  }

  agreementInspection() {
    this.router.navigate(['agreementInspection']);
  }

  onCarDelete(id: number) {
    this.carsService.deleteCar(id).subscribe(
      (data: any) => {
        console.log(data);
        if (data.message === 'Car Deleted!') {
          this.authService.openSnackBar('Car deleted successfully','Close');
          this.fetchCars();
        } else alert('Delete Unsuccessful');
      },
      (error) => {
        console.error(error);
      }
    );
  }

  myAgreement() {
    console.log('hello');
    this.router.navigate(['allRentalAgreementsOfUser']);
  }

  newCar() {
    this.router.navigate(['addNewCar']);
  }

  allRentalAgreements() {
    this.router.navigate(['allRentalAgreement']);
  }

  onUpdateCarDetails(id: number) {
    this.router.navigate(['updateCarDetails', id]);
  }


  get isUserLogin(): Boolean{
    return this.authService.isUserLogin;
  }

  helpfun()
  {
    this.authService.helpfun();
  }

  get username(): string{
    
    if(this.isUserLogin)
    {
      return this.authService.User.name;
    }
    return '';
  }

}
