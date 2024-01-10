import { Injectable } from '@angular/core';
import { Observable, BehaviorSubject } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { loginRequest } from '../models/login.model';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Location } from '@angular/common';
import { Register } from '../models/register.model';


@Injectable({
  providedIn: 'root'
})
export class LoginService {
 private isLoggedInSubject = new BehaviorSubject<any>(this.isLoggedIn());
 isLoggedIn$: Observable<boolean> = this.isLoggedInSubject.asObservable();
 email: string;
 private userPayload: any;

  constructor(private http: HttpClient, private router: Router,private location: Location) {
  this.userPayload = this.decodeToken();
  this.email =this.getEmailFromToken();
  }

  baseServerUrl = "https://localhost:44347/api/" ;



  login(model:loginRequest):Observable<void>{
    return this.http.post<void>(
      this.baseServerUrl + 'User/Authenticate',model
    )
  }

  

  storeToken(tokenValue: string) {
  
    localStorage.setItem('token', tokenValue);
    this.isLoggedInSubject.next(true);
    this.userPayload = this.decodeToken();
    this.decodeToken();
  }

  getToken(): string | null {
    return localStorage.getItem('token');
  }

  logout() {
    localStorage.removeItem('token');
    localStorage.clear();
    sessionStorage.clear();
    this.isLoggedInSubject.next(false);
    this.userPayload = null;
    this.router.navigate(['']);
   
   
  }

  isLoggedIn(): boolean {
    return !!localStorage.getItem('token');
  }

  decodeToken() {
    const jwtHelper = new JwtHelperService();
    const token = this.getToken()!;
    return jwtHelper.decodeToken(token);
  }

  getNameFromToken() {
    if (this.userPayload) return this.userPayload.unique_name;
  }
 

  getEmailFromToken() {
    if (this.userPayload) return this.userPayload.email;
  }

  getCurrentUserDetails(): Observable<Register>
  {
    const userEmail = this.getEmailFromToken();
    return this.http.get<any>(`${this.baseServerUrl}User/GetCurrentUser?email=${userEmail}`);
  }

  getUserbyId( id:any): Observable<Register>
  {
    return this.http.get<any>(`${this.baseServerUrl}User/GetUserbyId?id=${id}`);
  }

  updateUser(id:number,updateUser:any):Observable<Register>{
    return this.http.put<any>(`https://localhost:44347/api/User/UpdateUser/${id}`,updateUser);
  }

}
























// import { Injectable } from '@angular/core';
// import { Observable, BehaviorSubject } from 'rxjs';
// import { HttpClient } from '@angular/common/http';
// import { loginRequest } from '../models/login.model';
// import { Router } from '@angular/router';
// import { JwtHelperService } from '@auth0/angular-jwt';


// @Injectable({
//   providedIn: 'root'
// })
// export class LoginService {
 
//   private userPayload: any;

//   isUserLogin : boolean ;
//   authService: any;
//   User: any;
//   currentUserEmail = "";
//   currentUserObj!:any;

//   constructor(private http: HttpClient,private router:Router) 
//   { 
//     this.isUserLogin = false;
//     this.User = {} as any; 
//   }

//   baseServerUrl = "https://localhost:44347/api/" ;


//   loginUser(loginInfo:Array<string>)
//   {
//     //we change here
//     //this.User = loginInfo;
    
//     return this.http.post(this.baseServerUrl + 'User/Authenticate',
//     {
//       Email:loginInfo[0],
//       Password:loginInfo[1]
//     },
//     {
//       responseType:'text',
//     }
    
//     );
   
//   }    
    





  
// }
