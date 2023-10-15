import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { AllCarsComponent } from './all-cars/all-cars.component';
import { AddedRentalAgreementComponent } from './added-rental-agreement/added-rental-agreement.component';
import { NoLoginAuthGuard } from './AuthGuards/NoLogin.auth';
import { UserLoginAuthGuard } from './AuthGuards/userLogin.auth';
import { AdminLoginAuthGuard } from './AuthGuards/adminLogin.auth';
import { ConfirmRentalAgreementComponent } from './confirm-rental-agreement/confirm-rental-agreement.component';
import { AllRentalAgreementsOfUserComponent } from './all-rental-agreements-of-user/all-rental-agreements-of-user.component';
import { LoginAuthGuard } from './AuthGuards/Login.auth';
import { AddNewCarComponent } from './add-new-car/add-new-car.component';
import { AllRentalAgreementComponent } from './all-rental-agreement/all-rental-agreement.component';
import { UpdateCarDetailsComponent } from './update-car-details/update-car-details.component';
import { UpdateAgreementDataComponent } from './update-agreement-data/update-agreement-data.component';
import { AgreementInspectionComponent } from './agreement-inspection/agreement-inspection.component';
const routes: Routes = [
  {
    path:'',
    component:HomeComponent,
    canActivate : [NoLoginAuthGuard]

  },
  {
    path:'login',
    component:LoginComponent ,
    canActivate : [NoLoginAuthGuard],
   
  },
  {
    path:'allCars',
    component:AllCarsComponent,
    canActivate:[LoginAuthGuard]
   
     
  },
  {
    path:'addedRentalAgreement/:id',
    component:AddedRentalAgreementComponent,
    canActivate:[LoginAuthGuard]
  
  },
  {
    path:'confirmRentalAgreement/:id',
    component:ConfirmRentalAgreementComponent,
    canActivate:[LoginAuthGuard]
  },
  {
    path:'allRentalAgreementsOfUser',
    component:AllRentalAgreementsOfUserComponent,
    canActivate:[LoginAuthGuard]
  },
  {
    path:'addNewCar',
    component:AddNewCarComponent,
    canActivate:[LoginAuthGuard]
  },
  {
    path:'allRentalAgreement',
    component:AllRentalAgreementComponent,
    canActivate:[AdminLoginAuthGuard]
  }
  ,
  {
   path:'updateCarDetails/:id',
   component:UpdateCarDetailsComponent,
   canActivate:[AdminLoginAuthGuard]
  },
  {
    path:'updateAgreementData/:id',
    component:UpdateAgreementDataComponent,
   canActivate:[AdminLoginAuthGuard]
  },
  {
    path:'agreementInspection',
    component:AgreementInspectionComponent,
   canActivate:[AdminLoginAuthGuard]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
