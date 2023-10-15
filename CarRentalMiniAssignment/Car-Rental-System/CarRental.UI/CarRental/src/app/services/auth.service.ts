import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { Observable } from 'rxjs/internal/Observable';
import { MatSnackBar } from '@angular/material/snack-bar';


@Injectable({
  providedIn: 'root'
})
export class AuthService {
  isUserLogin : boolean ;
  authService: any;
  User: any;
  currentUserEmail = "";
  currentUserObj!:any;

    constructor(private snackBar: MatSnackBar,private http: HttpClient,private router:Router) 
  { 
    this.isUserLogin = false;
    this.User = {} as any; 
  }
  
  baseServerUrl = "https://localhost:44326/api/" ;

  openSnackBar(message: string,action: string) {
    this.snackBar.open(message,action, {
      duration: 3000,
      verticalPosition: 'top',
    });
  }

  loginUser(loginInfo:Array<string>)
  {
    //we change here
    this.User = loginInfo;
    
    return this.http.post(this.baseServerUrl + 'User/LoginUser',
    {
      Email:loginInfo[0],
      Password:loginInfo[1]
    },
    {
      responseType:'text',
    }
    
    );
   
    
    

  }

  logout() {
  
    this.isUserLogin = false;
   
    this.currentUserEmail = "";

    this.router.navigate(['/login']);
  }
  

  getCurrentUserDetails(): Observable<any>
  {
    return this.http.get<any>(`${this.baseServerUrl}User/CurrentUser?email=${this.User.email}`);
  }



  helpfun()
  {
    window.open('https://www.nagarro.com/en/contact-us', '_blank');
  }  


  



}
