import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { LoginService } from 'src/app/services/login.service';
import { NgToastService } from 'ng-angular-popup';
import { Location } from '@angular/common';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})

export class LoginComponent implements OnInit {
  loginForm: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    private loginService: LoginService,
    private router: Router,
    private toast:NgToastService,
    private location: Location
  ) {
    this.loginForm = this.formBuilder.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', Validators.required],
    });
  }

  ngOnInit(): void {}

  login() {
    if (this.loginForm.invalid) {
      this.loginForm.markAllAsTouched();
      return;
    }

    const Username = this.loginForm.get('email')?.value;
    const Password = this.loginForm.get('password')?.value;
   
    this.loginService.login({Username,Password}).subscribe(
      (res: any) => {
        
        this.loginService.storeToken(res.token);
        this.toast.success({
          detail: 'SUCCESS',
          summary: 'LogIn Success',
          duration: 3000,
        });
      
        this.router.navigate(['booklist']);

        


      },
      (error) => {
        this.toast.error({
          detail: 'ERROR',
          summary: error.error.message,
          duration: 5000,
        });
        console.log("error");
      }
    );








  }
 }




















































// import { Component, OnInit } from '@angular/core';
// import{ FormGroup, Validators,FormControl } from '@angular/forms';
// import { Router } from '@angular/router';
// import { LoginService } from 'src/app/services/login.service';
// import { NgToastService } from 'ng-angular-popup';

// @Component({
//   selector: 'app-login',
//   templateUrl: './login.component.html',
//   styleUrls: ['./login.component.css']
// })

// export class LoginComponent implements OnInit  {
//   constructor( private toast:NgToastService,private loginAuth: LoginService, private router: Router) {}
//   ngOnInit(): void {}

//   loginForm = new FormGroup({
//     userid: new FormControl('', [Validators.required, Validators.email]),
//     pwd: new FormControl('', [
//       Validators.required,
//       Validators.minLength(6),
//       Validators.maxLength(15),
//     ]),
//   });
//   message: string = '';
//   isUserValid: boolean = false;

//   loginSubmitted() {
//     console.log(this.loginForm.value.userid, this.loginForm.value.pwd);
//     this.loginAuth
//       .loginUser([
//         this.loginForm.value.userid ?? '',
//         this.loginForm.value.pwd ?? '',
//       ])
//       .subscribe((res) => {
//         if (res == 'Password incorrect!') {
//           this.loginAuth.isUserLogin = false;
//           alert("go back");
//           ;
//         } else if (res == 'No such user exist in database!') {
//           this.loginAuth.isUserLogin = false;
        
//           alert("go back");
//         } else {
//           this.loginAuth.isUserLogin = true;
//           console.log(res);
//           this.toast.success({
//                       detail: 'SUCCESS',
//                       summary: 'LogIn Success',
//                       duration: 3000,
//                     });
                   
                   
//           this.loginAuth.User = JSON.parse(res);
//           console.log(this.loginAuth.User);
//           this.loginAuth.currentUserObj == this.loginAuth.User;
//           this.router.navigate(['booklist']);
          
//         }
//       });
//   }


//   get Email(): FormControl {
//     return this.loginForm.get('userid') as FormControl;
//   }
//   get PWD(): FormControl {
//     return this.loginForm.get('pwd') as FormControl;
//   }
// }