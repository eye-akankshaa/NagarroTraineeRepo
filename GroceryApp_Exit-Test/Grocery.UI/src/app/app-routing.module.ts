import { NonNullAssert } from '@angular/compiler';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminAddProductComponent } from './admin-add-product/admin-add-product.component';
import { AdminDeleteComponent } from './admin-delete/admin-delete.component';
import { AdminEditComponent } from './admin-edit/admin-edit.component';
import { AdminModificationComponent } from './admin-modification/admin-modification.component';
import { AdminLoginAuthGuard } from './AuthGuards/adminLogin.auth';
import { LoginAuthGuard } from './AuthGuards/Login.auth';
import { NoLoginAuthGuard } from './AuthGuards/NoLogin.auth';
import { UserLoginAuthGuard } from './AuthGuards/userLogin.auth';
import { HelpComponent } from './help/help.component';
import { LoginComponent } from './login/login.component';
import { MyordersComponent } from './myorders/myorders.component';
import { ProductDetailsComponent } from './product-details/product-details.component';
import { ProductComponent } from './product/product.component';
import { SignupComponent } from './signup/signup.component';
import { ViewcartComponent } from './viewcart/viewcart.component';
import { ProductDetailLogoutComponent } from './product-detail-logout/product-detail-logout.component';

const routes: Routes = [
  {
    path:'',
    component:ProductComponent,
    canActivate : [LoginAuthGuard]
  },
  {
    path:'login',
    component:LoginComponent ,
    canActivate : [NoLoginAuthGuard]
  },
  {
    path:'signup',
    component:SignupComponent ,
    canActivate : [NoLoginAuthGuard]
  },
  {
    path:'myorders',
    component:MyordersComponent,
    canActivate : [UserLoginAuthGuard]
  },
  // {
  //   path:'product',
  //   component:ProductComponent
  // },
  {
    path:'viewcart',
    component:ViewcartComponent,
    canActivate : [UserLoginAuthGuard]
  },
  {
    path:'help',
    component:HelpComponent,
    canActivate : [UserLoginAuthGuard]
  },

  // {
  //   path:'admin',
  //   component:AdminLoginComponent,
  //   canActivate : [AdminLoginAuthGuard]
  // },

  {
    path:'admin-addProduct',
    component:AdminAddProductComponent,
    canActivate : [AdminLoginAuthGuard]
    
  },
  {
    path:'admin/admin-modification',
    component:AdminModificationComponent,
    canActivate : [AdminLoginAuthGuard]
  },
  {
    path:'admin/edit/:id',
    component:AdminEditComponent,
    canActivate : [AdminLoginAuthGuard]
  },
  {
    path:'admin-delete',
    component:AdminDeleteComponent,
    canActivate : [AdminLoginAuthGuard]
  },
  {
    path:'product-details/:id',
    component:ProductDetailsComponent,
    canActivate : [UserLoginAuthGuard]
  },

  {

    path:'product-details-logout/:id',

    component:ProductDetailLogoutComponent

  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { } 
