import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {HttpClientModule} from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SignupComponent } from './signup/signup.component';
import { LoginComponent } from './login/login.component';
import { HeaderComponent } from './header/header.component';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { AuthService } from './services/auth.service';
import { ProductComponent } from './product/product.component';
import { ViewcartComponent } from './viewcart/viewcart.component';
import { MyordersComponent } from './myorders/myorders.component';
import { HelpComponent } from './help/help.component';
import { AdminAddProductComponent } from './admin-add-product/admin-add-product.component';
import { AdminModificationComponent } from './admin-modification/admin-modification.component';
import { AdminEditComponent } from './admin-edit/admin-edit.component';
import { AdminDeleteComponent } from './admin-delete/admin-delete.component';
import { ProductDetailsComponent } from './product-details/product-details.component';
import { LoginAuthGuard } from './AuthGuards/Login.auth';
import { AdminLoginAuthGuard } from './AuthGuards/adminLogin.auth';
import { UserLoginAuthGuard } from './AuthGuards/userLogin.auth';
import { NoLoginAuthGuard } from './AuthGuards/NoLogin.auth';
import { ProductDetailLogoutComponent } from './product-detail-logout/product-detail-logout.component';




@NgModule({
  declarations: [
    AppComponent,
    SignupComponent,
    LoginComponent,
    HeaderComponent,
    ProductComponent,
    ViewcartComponent,
    MyordersComponent,
    HelpComponent,
    AdminAddProductComponent,
    AdminModificationComponent,
    AdminEditComponent,
    AdminDeleteComponent,
    ProductDetailsComponent,
    ProductDetailLogoutComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule 
  ],
  providers: [
    AuthService,
    LoginAuthGuard,
    AdminLoginAuthGuard,
    UserLoginAuthGuard,
    NoLoginAuthGuard
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
