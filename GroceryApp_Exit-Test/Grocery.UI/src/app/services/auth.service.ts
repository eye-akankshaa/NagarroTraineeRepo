import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs/internal/Observable';
import { Product } from '../admin-add-product/admin-add-product.component';
import { User } from '../Models/User';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  isUserLogin : boolean ;
  authService: any;
  User: User;
  currentUserEmail = "";
  currentUserObj!:User;

  constructor(private http: HttpClient,private router:Router) 
  { 
    this.isUserLogin = false;
    this.User = {} as User; 
  }
  baseServerUrl = "https://localhost:44325/api/" ;

  registerUser(user:Array<string>)
  {
    //we change here from this user/createuser
    return this.http.post(this.baseServerUrl + "Register/CreateRegister",
      {
       Name:user[0],
       Email:user[1],
       Phone:user[2],
       Password:user[3]
      },
      {
      responseType:'text'
    });
  } 
  loginUser(loginInfo:Array<string>)
  {
    //we change here
    return this.http.post(this.baseServerUrl + 'Register/LoginUser',
    {
      Email:loginInfo[0],
      Password:loginInfo[1]
    },
    {
      responseType:'text',
    }
    );

  }
  getCurrentUserDetails(email:string): Observable<User>
  {
    return this.http.get<User>(`${this.baseServerUrl}Register/CurrentUser?email=${email}`);
  }

    logout() {
  
    this.isUserLogin = false;
    // this.User = null;
    this.currentUserEmail = "";

    this.router.navigate(['/login']);
  }

  helpfun()
  {
    window.open('https://www.nagarro.com/en/contact-us', '_blank');
  }
}
