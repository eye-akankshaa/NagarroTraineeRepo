import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
  username: string = '';

  constructor(private loginAuth: AuthService, private router: Router) {}
  ngOnInit(): void {}

  loginForm = new FormGroup({
    userid: new FormControl('', [Validators.required, Validators.email]),
    pwd: new FormControl('', [
      Validators.required,
      Validators.minLength(6),
      Validators.maxLength(15),
    ]),
  });
  message: string = '';
  isUserValid: boolean = false;
  loginSubmitted() {
    console.log(this.loginForm.value.userid, this.loginForm.value.pwd);
    this.loginAuth
      .loginUser([
        this.loginForm.value.userid ?? '',
        this.loginForm.value.pwd ?? '',
      ])
      .subscribe((res) => {
        if (res == 'Password incorrect!') {
          this.loginAuth.isUserLogin = false;

          this.loginAuth.openSnackBar('Password incorrect', 'Close');
        } else if (res == 'No such user exist in database!') {
          this.loginAuth.isUserLogin = false;

          this.loginAuth.openSnackBar(
            'No such user exist in database!',
            'Close'
          );
        } else {
          this.loginAuth.isUserLogin = true;
          console.log(res);

          this.loginAuth.User = JSON.parse(res);
          console.log(this.loginAuth.User);
          this.loginAuth.currentUserObj == this.loginAuth.User;
          this.router.navigate(['allCars']);
        }
      });
  }

  get Email(): FormControl {
    return this.loginForm.get('userid') as FormControl;
  }
  get PWD(): FormControl {
    return this.loginForm.get('pwd') as FormControl;
  }
}
