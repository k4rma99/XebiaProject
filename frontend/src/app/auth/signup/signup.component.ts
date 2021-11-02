import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.scss']
})
export class SignupComponent implements OnInit {

  signupForm: FormGroup = new FormGroup({
  
    fName: new FormControl('', Validators.required),
    lName: new FormControl('', Validators.required), 
    email: new FormControl('', [Validators.required, Validators.email]), 
    phone: new FormControl('', [Validators.required]), 
    password:new FormControl('',[Validators.required,Validators.minLength(8)])
    
  });

  isFilled: boolean = true;
  
  constructor(private authService:AuthService,private router:Router) { }

  ngOnInit(): void {
  }

  handleSignup(): any {
    //prevent submission and display error if form invalid
    if (!this.signupForm.valid) {
      this.isFilled = false;
      return false;
    }
    this.isFilled = true;
    this.authService.signup(this.signupForm.value).subscribe(
      (res) => {
        
        alert("Signup Success!You can login now!");
        this.router.navigate(['login']);
      },
      err => {
        alert("Signup Failed due to an error!");
      }
    )
  }

}
