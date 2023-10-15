import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import {StudentModule} from './student/student.module';
import {TeacherModule} from './teacher/teacher.module';
import { ReactiveFormsModule } from '@angular/forms';
import { LogoutComponent } from './logout/logout.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { authGuard } from './auth.guard';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    LogoutComponent,
  ],
  imports: [
    ReactiveFormsModule,
    BrowserModule,
    AppRoutingModule,
    StudentModule,
    TeacherModule,
    HttpClientModule,
    BrowserAnimationsModule,
    
  ],
  providers: [authGuard],
  bootstrap: [AppComponent]
})
export class AppModule { }
