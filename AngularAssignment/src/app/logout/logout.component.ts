import { Component, OnInit } from '@angular/core';
import { CoreService } from '../service/core.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-logout',
  templateUrl: './logout.component.html',
  styleUrls: ['./logout.component.css']
})
export class LogoutComponent implements OnInit{
  constructor(private _coreService: CoreService,private router: Router){}
  ngOnInit(): void {
    this._coreService.setUser(null);
    this.router.navigate(['']);
  }

}
