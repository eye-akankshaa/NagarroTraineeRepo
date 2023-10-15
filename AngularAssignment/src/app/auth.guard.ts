import {ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { take, map } from 'rxjs/operators';
import { CoreService } from 'src/app/service/core.service'; // Replace with the correct path to your CoreService

@Injectable()
export class authGuard  {
  constructor(private router: Router, private _coreService: CoreService) {}

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean | any {
    var data = this._coreService.user;
    if(data)
    {
      return true;

    }
    return this.router.createUrlTree(['']); 
  
  }
}
