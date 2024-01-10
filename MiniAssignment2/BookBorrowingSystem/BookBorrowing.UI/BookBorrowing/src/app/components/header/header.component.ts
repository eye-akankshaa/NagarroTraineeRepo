import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { LoginService } from 'src/app/services/login.service';
import { NgToastService } from 'ng-angular-popup';
import { Register } from 'src/app/models/register.model';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  isLoggedIn: boolean;
  Name: string;
  currentUser!:Register;
  Token: number;

  constructor(
    private route: ActivatedRoute,
    private loginService: LoginService,
    private toast: NgToastService
  ) {
    this.isLoggedIn = this.loginService.isLoggedIn();

    this.Name = this.loginService.getNameFromToken();
    this.Token = 1;
  }

  ngOnInit(): void {
    this.loginService.isLoggedIn$.subscribe((LoggedIn) => {
      this.isLoggedIn = LoggedIn;

     // let namefromtoken = this.loginService.getNameFromToken();

     // this.Name = namefromtoken;
        
    });

    let namefromtoken = this.loginService.getNameFromToken();
    this.Name = namefromtoken;
    console.log(this.Name);

    if(this.isLoggedIn){
      this.loginService.getCurrentUserDetails().subscribe(
        (data: Register) => {
          this.currentUser = data;
          
          this.Token = this.currentUser.tokens_Available;
          
          let namefromtoken = this.loginService.getNameFromToken();
          this.Name = namefromtoken;
          this.Token = this.currentUser?.tokens_Available;

        },
        (error) => {
          console.error(error);
        }
      );
    }

    

  
    
    this.Token = this.currentUser?.tokens_Available;


  }

  logout() {
    this.loginService.logout();
    this.toast.success({
      detail: 'SUCCESS',
      summary: 'Logged Out Successfully',
      duration: 3000,
    });
  }
}
