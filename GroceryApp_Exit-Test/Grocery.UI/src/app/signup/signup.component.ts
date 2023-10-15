import { Component ,OnInit} from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit{
  displayMsg: string='';
  isAccountCreated: boolean=false;

     repeatPass : string ='none';
     constructor(private authservice:AuthService){}
    ngOnInit(): void {
      
    }
    registerForm = new FormGroup({
      fullName: new FormControl("",[Validators.required,Validators.minLength(2),Validators.pattern("[a-zA-Z].*")]),
      userId: new FormControl("",[
        Validators.required,
        Validators.email,

      ]),
      phone:new FormControl("",[
        Validators.required,
        Validators.pattern("[0-9]*"),
        Validators.minLength(10),
        Validators.maxLength(10),
      ]),
      password:new FormControl("",[
        Validators.required,
        Validators.minLength(6),
        Validators.maxLength(15),
      ]),
       rpwd:new FormControl("")
    });

    registerSubmitted()
    {
      if(this.Password.value == this.RPWD.value)
      {
        console.log(this.registerForm.valid);
        this.repeatPass='none'
       
       

        this.authservice.registerUser([
          this.registerForm.value.fullName??"",
          this.registerForm.value.userId??"",
          this.registerForm.value.phone??"",
          this.registerForm.value.password??""
        ])
        .subscribe(res => {
          if(res="Success")
          {
            this.displayMsg='Account Created Successfully';
            this.isAccountCreated=true;
          }
          else if(res = 'Already Exist')
          {
            this.displayMsg='Account Already exist! try another email';
            this.isAccountCreated=false;
          }
          else{
            this.displayMsg='Something went wrong';
            this.isAccountCreated=false;
          }
        });
      }else{
        this.repeatPass = 'inline'
      }
    }

    get FullName():FormControl
    {
      return this.registerForm.get("fullName") as FormControl;
    }
    get UserId():FormControl
    {
      return this.registerForm.get("userId") as FormControl;
    }
    get Phone():FormControl
    {
      return this.registerForm.get("phone") as FormControl;
    }
    get Password():FormControl
    {
      return this.registerForm.get("password") as FormControl;
    }

    get RPWD():FormControl
    {
      return this.registerForm.get("rpwd") as FormControl;
    }
}
