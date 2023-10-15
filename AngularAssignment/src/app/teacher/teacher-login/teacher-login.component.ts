import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http'
import { CoreService } from 'src/app/service/core.service';

@Component({
  selector: 'app-teacher-login',
  templateUrl: './teacher-login.component.html',
  styleUrls: ['./teacher-login.component.css']
})
export class TeacherLoginComponent implements OnInit {
  loginForm!: FormGroup
  constructor(private formBuilder: FormBuilder, 
    private _http: HttpClient, 
    private router: Router, 
    private _coreService: CoreService) { }

  ngOnInit(): void {
    //
    this.loginForm = this.formBuilder.group({
      userid: [''],
      pwd: ['']
    })
    // if(this._coreService.getUser()!==null){
    //   this.router.navigate(["teacher/records"])
    //}
  }

  logIn() {
    this._http.get<any>("http://localhost:3000/teachers").subscribe(  {
      next:(res:any)=>{
        const user = res.find((a: any) => {
          return a.userId === this.loginForm.value.userid && a.password === this.loginForm.value.pwd
        })
        if (user) {
          this.loginForm.reset();
          this._coreService.openSnackBar('Login Successfully','Close');
          this._coreService.setUser(user);
          this.router.navigate(['teacher/records']);
          
        }
        else {
          this._coreService.openSnackBar('Username and Password does not match','Close');
        }
      },error:(err:any) => {
        this._coreService.openSnackBar('Something went wrong with connection','Close');
      }
  });
      
  
  }
}

