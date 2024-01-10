import { Component, OnInit, ChangeDetectorRef, } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Book } from 'src/app/models/book.model';
import { BookService } from 'src/app/services/book.service';
import { LoginService } from 'src/app/services/login.service';
import { NgToastService } from 'ng-angular-popup';
import { Router } from '@angular/router';
import { Register } from 'src/app/models/register.model';

@Component({
  selector: 'app-book-description',
  templateUrl: './book-description.component.html',
  styleUrls: ['./book-description.component.css']
})
export class BookDescriptionComponent implements OnInit {
  chosenBook!: Book;
  choseBookId: number = 0;
  Lendername: string = '';
  updatedBook!: Book;
  currentUser!: Register;
  BorrowedByUser!: Register;
  LentByUser!: Register;
  constructor(private toast: NgToastService, private loginService: LoginService, private bookService: BookService, private route: ActivatedRoute, private cdr: ChangeDetectorRef, private router: Router) {
  }
  ngOnInit(): void {


    let strProductId = this.route.snapshot.paramMap.get('id');

    this.choseBookId = Number(strProductId);
    this.loginService.getCurrentUserDetails().subscribe(
      (data: Register) => {
        this.currentUser = data;
       
        this.bookService.getBookById(this.choseBookId).subscribe(
          (bookData: any) => {
            this.chosenBook = bookData;

          }, (bookError) => {

          }
        )

      },
      (error) => {
        console.error(error);
      }
    );




  }



  onBorrowAction() {
    this.loginService.getCurrentUserDetails().subscribe(
      (data: Register) => {
        this.currentUser = data;
        
      },
      (error) => {
        console.error(error);
      }

    );
    this.updatedBook = this.chosenBook;
    this.updatedBook.is_Book_Available = false;
    this.updatedBook.currently_Borrowed_By_User_id = this.currentUser.userId;

    
    this.bookService.updateBook(this.choseBookId, this.updatedBook).subscribe({
      next: (temp) => {

        this.loginService.getCurrentUserDetails(
        ).subscribe({
          next: (temp) => {
            this.BorrowedByUser = temp;
            this.BorrowedByUser.tokens_Available = Number(temp.tokens_Available) - 1;
            console.log("borrowetoken" + this.BorrowedByUser.tokens_Available);
            this.loginService.updateUser(temp.userId, this.BorrowedByUser).subscribe({
              next: (temp) => {
                
              }
            })
          }
        })

        this.loginService.getUserbyId(this.chosenBook.lent_By_User_id
        ).subscribe({
          next: (temp) => {
           
            this.LentByUser = temp;
            this.LentByUser.tokens_Available = Number(temp.tokens_Available) + 1;

            this.loginService.updateUser(this.chosenBook.lent_By_User_id, this.LentByUser).subscribe({
              next: (temp) => {
               
              }
            })
          }
        })


        this.toast.success({
          detail: 'SUCCESS',
          summary: 'Book Borrowed Successfully',
          duration: 5000,
        });

        this.router.navigate(['booklist']);

      },
      error: (res) => {
        console.log(res);
        this.toast.success({
          detail: 'Error',
          summary: res.message,
          duration: 3000,
        });
      }
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
  }

  isButtonDisabled(){
    return (this.currentUser.tokens_Available==0);
  }


}
