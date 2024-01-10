

import { Injectable } from '@angular/core';

import {
  CanActivate,
  ActivatedRouteSnapshot,
  RouterStateSnapshot,
  UrlTree,
  Router,
} from '@angular/router';
import { BehaviorSubject, Observable } from 'rxjs';
import { NgToastService } from 'ng-angular-popup';
import { LoginService } from '../services/login.service';


@Injectable({
  providedIn: 'root',
})
export class AuthGuard implements CanActivate {
  constructor(
    private loginService: LoginService,
    private router: Router,
    private toast: NgToastService
  ) { }

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ):
    | Observable<boolean | UrlTree>
    | Promise<boolean | UrlTree>
    | boolean
    | UrlTree {
    if (this.loginService.isLoggedIn()) {
      return true;
    }
    else {
      this.toast.error({ detail: 'ERROR', summary: 'Please Login First!' });
      this.router.navigate(['login']);
      return false;
    }
  }
}
