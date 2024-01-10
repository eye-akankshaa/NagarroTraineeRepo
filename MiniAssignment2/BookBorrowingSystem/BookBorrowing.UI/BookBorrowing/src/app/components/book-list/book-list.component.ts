import { Component } from '@angular/core';
import { BookService } from 'src/app/services/book.service';
import { LoginService } from 'src/app/services/login.service';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup } from '@angular/forms';
import { NgToastService } from 'ng-angular-popup';
import { Book } from 'src/app/models/book.model';
import { Register } from 'src/app/models/register.model';
@Component({
  selector: 'app-book-list',
  templateUrl: './book-list.component.html',
  styleUrls: ['./book-list.component.css'],
})
export class BookListComponent {
  isLoggedIn: boolean;
  books: Book[] = [];
  currentUser!: Register;
  fg!: FormGroup;
  filteredBooks: Book[] = [];
  searchQuery: string = '';
  bookNameFilter: string = '';
  authorNameFilter: string = '';
  genreFilter: string = '';
  makerSearchTerm: string = '';

  constructor(
    private bookService: BookService,
    private loginService: LoginService,
    private toast: NgToastService,
    private router: Router,
    private fb: FormBuilder
  ) {
    this.isLoggedIn = this.loginService.isLoggedIn();
  }
  ngOnInit() {
    this.loginService.isLoggedIn$.subscribe((LoggedIn) => {
      this.isLoggedIn = LoggedIn;
    });

    this.fetchBooks();
    this.loginService.getCurrentUserDetails().subscribe(
      (data: Register) => {
        this.currentUser = data;
        this.fetchBooks();
      },
      (error) => {
      
      }
    );

   
  }

  fetchBooks(): void {
    this.bookService.getBooks().subscribe({
      next: (res) => {
        this.books = res;
        this.filteredBooks = this.books;
        this.applyFilters();
       
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

  home() {
    this.router.navigate(['']);
  }

  addBook() {
    this.router.navigate(['addnewbook']);
  }

  myBook() {
    this.router.navigate(['mybook']);
  }

  logout() {
    this.loginService.logout();
    this.toast.success({
      detail: 'SUCCESS',
      summary: 'Logged Out Successfully',
      duration: 3000,
    });
  }

  onBookDetails(id: any) {
    if (this.isLoggedIn) {
      this.router.navigate(['bookdetails', id]);
    } else {
      this.router.navigate(['login']);
    }
  }

 


  applyFilters(): void {
    this.filteredBooks = this.books.filter((book: { name: string; author: string; genre: string; }) => {
      const bookNameMatch = !this.bookNameFilter || book.name.toLowerCase().includes(this.bookNameFilter.toLowerCase());
      const authorNameMatch = !this.authorNameFilter || book.author.toLowerCase().includes(this.authorNameFilter.toLowerCase());
      const genreMatch = !this.genreFilter || book.genre.toLowerCase().includes(this.genreFilter.toLowerCase());
      return bookNameMatch && authorNameMatch && genreMatch;
    });
  }
}
