import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { CoreService } from 'src/app/service/core.service';

@Component({
  selector: 'app-teacher-signup',
  templateUrl: './teacher-signup.component.html',
  styleUrls: ['./teacher-signup.component.css']
})
export class TeacherSignupComponent implements OnInit {

  signupForm!:FormGroup
  
  constructor(private formBuilder:FormBuilder, 
    private _http:HttpClient, 
    private router:Router,
    private _coreService: CoreService) { }

  ngOnInit(): void {
    this.signupForm=this.formBuilder.group({
      userId:[''],
      password:['']
      
    })
  }
  signUp(){
    this._http.post<any>("http://localhost:3000/teachers",this.signupForm.value).subscribe(res=>{
      this._coreService.openSnackBar('Registration Successfull','Close');
      this.signupForm.reset();
      this.router.navigate(['teacher/login'])
    }
    )
  }
}

