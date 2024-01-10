import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './components/home/home.component';
import { HeaderComponent } from './components/header/header.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { LoginComponent } from './components/login/login.component';
import { FooterComponent } from './components/footer/footer.component';
import { BookListComponent } from './components/book-list/book-list.component';
import { BookDescriptionComponent } from './components/book-description/book-description.component';
import { AddNewBookComponent } from './components/add-new-book/add-new-book.component';
import {HTTP_INTERCEPTORS, HttpClientModule} from '@angular/common/http';
import { NgToastModule } from 'ng-angular-popup';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { TokenInterceptor } from './interceptors/token.interceptor';
import { MybooksComponent } from './components/mybooks/mybooks.component';
import { PageNotFoundComponent } from './components/page-not-found/page-not-found.component';
@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    HeaderComponent,
    LoginComponent,
    FooterComponent,
    BookListComponent,
    BookDescriptionComponent,
    AddNewBookComponent,
    MybooksComponent,
    PageNotFoundComponent,
  
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgbModule,
    FormsModule,
    HttpClientModule,
    NgToastModule,
    ReactiveFormsModule
  
  ],
  providers: [{
    provide:HTTP_INTERCEPTORS,
    useClass:TokenInterceptor,
    multi:true
  }],
  bootstrap: [AppComponent]
})
export class AppModule { }
