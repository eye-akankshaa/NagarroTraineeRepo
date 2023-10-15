import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TeacherLoginComponent } from './teacher/teacher-login/teacher-login.component';
import { RecordsComponent } from './teacher/records/records.component';
import { HomeComponent } from './home/home.component';
import { ResultSearchComponent } from './student/result-search/result-search.component';
import { TeacherSignupComponent } from './teacher/teacher-signup/teacher-signup.component';
import { AddRecordComponent } from './teacher/add-record/add-record.component';
import { LogoutComponent } from './logout/logout.component';
import { authGuard } from './auth.guard';


const routes: Routes = [{
  path: '', redirectTo: 'home', pathMatch: 'full'
},
{
  path: 'home', component: HomeComponent
}, {
  path: 'teacher/login', component: TeacherLoginComponent
},
{
  path: 'student', component: ResultSearchComponent
},
{
  path: 'teacher/add/record', canActivate:[authGuard],component: AddRecordComponent
},
{
  path: 'teacher/signup', component: TeacherSignupComponent
},
{
  path: 'teacher/records',canActivate:[authGuard], component: RecordsComponent
}
,
{
  path: 'logout', component: LogoutComponent
}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
