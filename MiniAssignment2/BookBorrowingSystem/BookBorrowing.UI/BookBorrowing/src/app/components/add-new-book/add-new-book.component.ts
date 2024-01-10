import { Component,OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Book } from 'src/app/models/book.model';
import { NgToastService } from 'ng-angular-popup';
import { BookService } from 'src/app/services/book.service';
import { LoginService } from 'src/app/services/login.service';
import { Register } from 'src/app/models/register.model';


@Component({
  selector: 'app-add-new-book',
  templateUrl: './add-new-book.component.html',
  styleUrls: ['./add-new-book.component.css']
})

export class AddNewBookComponent  implements OnInit{
  addBookForm: FormGroup;
  model: Book;
  currentUser!: Register;


  constructor(
    private bookService: BookService,
    private router: Router,
    private loginService: LoginService,
    private formBuilder: FormBuilder,
    private toast: NgToastService
  ) {
    this.model = {
      bookId:0,
      name: '',
      rating:0,
      author:'',
      genre: '',
      is_Book_Available:true,
      description:'',
      lent_By_User_id:0,
      currently_Borrowed_By_User_id:0,

    
    };

    
    this.addBookForm = this.formBuilder.group({
      bookname: ['', Validators.required,Validators.pattern(/^[A-Za-z]+$/)],
      bookrating: [
        
        [Validators.required, Validators.min(1), Validators.max(5)],
      ],
      bookauthor: ['', Validators.required,Validators.pattern(/^[A-Za-z]+$/)],
      bookgenre: ['', Validators.required,Validators.pattern(/^[A-Za-z]+$/)],
      bookdescription: ['', Validators.required],
     
    });
  }

  ngOnInit(): void {


    this.loginService.getCurrentUserDetails().subscribe(
      (data: Register) => {
        this.currentUser = data;
        this.model.lent_By_User_id=this.currentUser.userId;
        
      },
      (error) => {
        console.error(error);
      }
    );

    
  }


  onFormSubmit() {
  
    if (this.addBookForm.invalid) {
      this.addBookForm.markAllAsTouched();
      return;
    }
   

    this.bookService.addNewBook(this.model).subscribe({
      next: (response) => {
        this.toast.success({
          detail: 'SUCCESS',
          summary: 'Book Added Successfully',
          duration: 3000,
        });
        this.router.navigate(['booklist']);
      },
      error: (error) => {
        this.toast.success({
          detail: 'Error',
          summary: error.error.message,
          duration: 3000,
        });
      },
    });
  }



  
  
  home(){
    this.router.navigate(['']);
  }

  Back(){
    this.router.navigate(['booklist']);
  }

  
  logout() {
    this.loginService.logout();
  
  }


}
