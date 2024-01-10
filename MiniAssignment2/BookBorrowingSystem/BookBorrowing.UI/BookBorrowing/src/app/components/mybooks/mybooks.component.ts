import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Book } from 'src/app/models/book.model';
import { BookService } from 'src/app/services/book.service';
import { LoginService } from 'src/app/services/login.service';
import { NgToastService } from 'ng-angular-popup';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Register } from 'src/app/models/register.model';

@Component({
  selector: 'app-mybooks',
  templateUrl: './mybooks.component.html',
  styleUrls: ['./mybooks.component.css'],
})
export class MybooksComponent implements OnInit {
  isLoggedIn: boolean;
  books: Book[] = [];
  currentUser!: Register;
  fg!: FormGroup;
  filteredBooks: Book[] = [];
  searchQuery: string = '';
  chosenBook!: Book;
  choseBookId: number = 0;
  Lendername: string = '';
  updatedBook!: Book;
  BorrowedByUser!: Register;
  LentByUser!: Register;
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
    this.fetchBooks();
    this.loginService.getCurrentUserDetails().subscribe(
      (data: Register) => {
        this.currentUser = data;
       
        this.fetchBooks();
      },
      (error) => {
      
      }
    );

    this.loginService.isLoggedIn$.subscribe((LoggedIn) => {
      this.isLoggedIn = LoggedIn;
    });
  }

  fetchBooks(): void {
    this.bookService.getBooks().subscribe({
      next: (res) => {
        this.books = res;
        this.filteredBooks = this.books;

        
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

  back() {
    this.router.navigate(['booklist']);
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

  getBook(id: number) {
    this.bookService.getBookById(id).subscribe({
      next: (temp) => {
        this.chosenBook = temp;
        this.loginService
          .getUserbyId(this.chosenBook.lent_By_User_id)
          .subscribe({
            next: (temp) => {
              console.log(temp);
              this.Lendername = temp.name;
            },
          });
      },
      error: (res) => {
        
      },
    });
  }

  returnBook(bookId: number, lent: number, currentlyBorrowed: any) {
    this.getBook(bookId);

    this.updatedBook = this.chosenBook;
    this.updatedBook.is_Book_Available = true;
    this.updatedBook.currently_Borrowed_By_User_id = 0;

    this.bookService.updateBook(bookId, this.updatedBook).subscribe({
      next: (temp) => {
        this.loginService.getCurrentUserDetails().subscribe({
          next: (temp) => {
            
            this.BorrowedByUser = temp;
            this.BorrowedByUser.tokens_Available =
              Number(temp.tokens_Available) + 1;
            
            this.loginService
              .updateUser(currentlyBorrowed, this.BorrowedByUser)
              .subscribe({
                next: (temp) => {
                  
                },
              });
          },
        });

        this.loginService.getUserbyId(lent).subscribe({
          next: (temp) => {
         
            this.LentByUser = temp;
            this.LentByUser.tokens_Available =
              Number(temp.tokens_Available) - 1;
            
            this.loginService.updateUser(lent, this.LentByUser).subscribe({
              next: (temp) => {
                
                this.router.navigate(['booklist']);
              },
            });
          },
        });

        this.toast.success({
          detail: 'SUCCESS',
          summary: 'Return Book Successfully',
          duration: 5000,
        });
      },
      error: (res) => {
        console.log(res);
        this.toast.success({
          detail: 'Error',
          summary: res.message,
          duration: 3000,
        });
      },
    });
  }
}
