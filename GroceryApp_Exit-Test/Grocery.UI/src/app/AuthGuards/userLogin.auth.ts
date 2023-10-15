import {ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { take, map } from 'rxjs/operators';// Replace with the correct path to your CoreService
import { AuthService } from '../services/auth.service';
import { User } from '../Models/User';

@Injectable()
export class UserLoginAuthGuard  {
  constructor(private router: Router, private authService: AuthService) {}

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean | any {
    var data: User = this.authService.User;
    if(this.authService.isUserLogin )
    {
        if(!this.authService.User.isAdmin)
        {
            return true;
        }
        //go to user product -- logged in user
     

    }
    return  this.router.createUrlTree(['']); 
  }
}
