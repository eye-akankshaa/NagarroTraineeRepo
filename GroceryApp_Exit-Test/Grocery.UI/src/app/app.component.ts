import { Component, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { AuthService } from './services/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnChanges, OnInit {
  title = 'Grocery.UI';

  authService: any;

  constructor(private loginAuth:AuthService){}
  ngOnInit(): void {
   
  }
  ngOnChanges(changes: SimpleChanges): void {
    
   
  }

  get isUserLogin(): Boolean{
    return this.loginAuth.isUserLogin;
  }

  get isAdmin():Boolean{
    if(this.isUserLogin)
    {
      return this.loginAuth.User.isAdmin;
    }
    return false
  }

  get username(): string{
    
    if(this.isUserLogin)
    {
      return this.loginAuth.User.name;
    }
    return '';
  }


  logout(){
     this.loginAuth.logout();
  }
  helpfun()
  {
    this.loginAuth.helpfun();
  }
}
