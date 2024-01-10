import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { LoginComponent } from './components/login/login.component';
import { BookListComponent } from './components/book-list/book-list.component';
import { BookDescriptionComponent } from './components/book-description/book-description.component';
import { AddNewBookComponent } from './components/add-new-book/add-new-book.component';
import { MybooksComponent } from './components/mybooks/mybooks.component';
import { AuthGuard } from './guards/auth.guard';
import { PageNotFoundComponent } from './components/page-not-found/page-not-found.component';

const routes: Routes = [

  {
    path:'',
    component:HomeComponent,
  }
  ,
  {
    path:'booklist',
    component:BookListComponent,
    canActivate:[AuthGuard]
  },
  {
    path:'login',
    component:LoginComponent
  },
  {
    path:'bookdetails/:id',
    component:BookDescriptionComponent,
    canActivate:[AuthGuard]
  },
  {
    path:'addnewbook',
    component:AddNewBookComponent,
    canActivate:[AuthGuard]
  },

  {
    path:'mybook',
    component:MybooksComponent,
    canActivate:[AuthGuard]
  },
  {
    path:'**', pathMatch: 'full' ,
    component:PageNotFoundComponent
  }


];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
