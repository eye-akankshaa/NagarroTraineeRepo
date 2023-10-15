import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';


@Injectable({
  providedIn: 'root'
})
export class CoreService {
  user:any
  constructor(private _snackBar: MatSnackBar) { }

  openSnackBar(message: string,action: string) {
    this._snackBar.open(message,action, {
      duration: 3000,
      verticalPosition: 'top',
    });
  }

  setUser(data:any){
    localStorage.setItem('user',JSON.stringify(data));
    var temp=JSON.parse(localStorage.getItem('user')||'[]');
    this.user=temp;
   // debugger
  }

  getUser(){
    this.user=JSON.parse(localStorage.getItem('user')||'[]');
    return this.user;
  }
}