import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {HttpClientModule} from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { AuthService } from './services/auth.service';
import { AppRoutingModule } from './app-routing.module';
import {MatSnackBarModule} from '@angular/material/snack-bar';

import { DatePipe } from '@angular/common';

import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { LoginComponent } from './login/login.component';
import { HomeComponent } from './home/home.component';
import { AllCarsComponent } from './all-cars/all-cars.component';
import { AddedRentalAgreementComponent } from './added-rental-agreement/added-rental-agreement.component';
import { LoginAuthGuard } from './AuthGuards/Login.auth';
import { AdminLoginAuthGuard } from './AuthGuards/adminLogin.auth';
import { UserLoginAuthGuard } from './AuthGuards/userLogin.auth';
import { NoLoginAuthGuard } from './AuthGuards/NoLogin.auth';
import { ConfirmRentalAgreementComponent } from './confirm-rental-agreement/confirm-rental-agreement.component';
import { AllRentalAgreementsOfUserComponent } from './all-rental-agreements-of-user/all-rental-agreements-of-user.component';
import { AddNewCarComponent } from './add-new-car/add-new-car.component';
import { AllRentalAgreementComponent } from './all-rental-agreement/all-rental-agreement.component';
import { UpdateCarDetailsComponent } from './update-car-details/update-car-details.component';
import { UpdateAgreementDataComponent } from './update-agreement-data/update-agreement-data.component';
import { AgreementInspectionComponent } from './agreement-inspection/agreement-inspection.component';
import { Ng2SearchPipeModule } from 'ng2-search-filter';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    LoginComponent,
    HomeComponent,
    AllCarsComponent,
    AddedRentalAgreementComponent,
    ConfirmRentalAgreementComponent,
    AllRentalAgreementsOfUserComponent,
    AddNewCarComponent,
    AllRentalAgreementComponent,
    UpdateCarDetailsComponent,
    UpdateAgreementDataComponent,
    AgreementInspectionComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgbModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    MatSnackBarModule
  

  ],
  providers: [
    AuthService,
    LoginAuthGuard,
    AdminLoginAuthGuard,
    UserLoginAuthGuard,
    NoLoginAuthGuard,
    DatePipe
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
