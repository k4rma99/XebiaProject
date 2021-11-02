import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  loginForm: FormGroup = new FormGroup({
    email: new FormControl('', [Validators.required, Validators.email]),
    password: new FormControl('', [Validators.required])
  })

  isFilled: boolean = true;

  constructor(private authService: AuthService) { }

  ngOnInit(): void {
  }

  handleLogin(): any {
    //prevent submission and display error if form invalid
    if (!this.loginForm.valid) {
      this.isFilled = false;
      return false;
    }
    this.isFilled = true;
    this.authService.login(this.loginForm.value).subscribe(
      res => {
        sessionStorage.setItem('authToken', res.token);
        sessionStorage.setItem('userRole', res.role);
        alert("Login Success");

      },
      err => {
        alert("Login Failed");
      }
    )
  }

}
