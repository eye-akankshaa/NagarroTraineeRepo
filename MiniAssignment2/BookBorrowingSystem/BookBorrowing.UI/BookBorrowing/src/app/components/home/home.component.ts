import { Component } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { NgToastService } from 'ng-angular-popup';
import { Register } from 'src/app/models/register.model';
import { Book } from 'src/app/models/book.model';
import { BookService } from 'src/app/services/book.service';
import { LoginService } from 'src/app/services/login.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  currentUser?: Register;
  books: Book[] = [];
  isLogin:boolean=true;
  
  constructor(
    private formBuilder: FormBuilder,
    private loginService: LoginService,
    private router: Router,
    private bookService: BookService,
    private toast: NgToastService,

  ) {

  }

  ngOnInit(): void {

    this.isLogin=this.loginService.isLoggedIn()

    this.loginService.getCurrentUserDetails().subscribe(
      (data: Register) => {
        this.currentUser = data;
        console.log(this.currentUser);
      },
      (error) => {
    
      }
    );

    this.bookService.getBooks().subscribe({
      next: (res) => {
        this.books = res;

      },
      error: (error) => {
        this.toast.error({
          detail: 'ERROR',
          summary: error.error.message,
          duration: 1000,
        });
      },
    });


  }

  borrowBook() {
    if (this.loginService.isLoggedIn())
      this.router.navigate(['booklist']);
    else
      this.router.navigate(['login']);
  }



  home() {
    this.router.navigate(['']);
  }

  allBook() {
    this.router.navigate(['booklist']);
  }

  myBook() {
    this.router.navigate(['mybook']);
    
  }
  logout() {
    this.loginService.logout();

  }

 
}
