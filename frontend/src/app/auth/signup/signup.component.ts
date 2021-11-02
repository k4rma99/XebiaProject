import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.scss']
})
export class SignupComponent implements OnInit {

  signupForm: FormGroup = new FormGroup({
  
    fName: new FormControl('', Validators.required),
    LName: new FormControl('', Validators.required), 
    email: new FormControl('', [Validators.required, Validators.email]), 
    phone: new FormControl('', [Validators.required,Validators.maxLength(13),Validators.minLength(10)]), 
    password:new FormControl('',[Validators.required,Validators.minLength(8)])
    
  });
  
  constructor() { }

  ngOnInit(): void {
  }

}
