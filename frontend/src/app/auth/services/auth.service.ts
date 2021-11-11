import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Subject } from 'rxjs';
import {  map} from 'rxjs/operators';


@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private API_URL = 'https://localhost:44370/api/usersapi/';
  private LOGIN_API_URL = 'https://localhost:44370/api/logincredentialsapi/verifylogincredential'
  // private TEST_JSON_SERVER_URL = 'http://localhost:3000/users'
  public loggedIn:Subject<boolean> = new Subject<boolean>();
  

  constructor(private http: HttpClient,private router:Router) { 
    if(sessionStorage.getItem('authToken')){
      this.loggedIn.next(true);
    }
    //console.log(`Inside authservice`);
  }

  login(userData: any) {
    let newData = {
      "uMailId": userData.email,
    "uPassword": userData.password
    }
    console.log("Inside Authservice")
    console.log(newData);
    return this.http.post(this.LOGIN_API_URL, newData,{observe:'response'})
      .pipe(map((res: any) => { //  get the resp from the REST API
        console.log(res);
        //  send the resp to the comp ts
        return res;
      }));
  }

  signup(userData:any){
    let newData = {
      "uFName": userData.fName,
    "uLName": userData.lName,
    "uPhone": userData.phone,
    "uMailId": userData.email,
    "uPassword":userData.password
    }
    return this.http.post(this.API_URL+"postuser", newData,{observe:'response'})
    .pipe(map((res: any) => { 
     
      return res;
    }));
  }

  logout(){
    sessionStorage.removeItem('authToken');
    sessionStorage.removeItem('userRole');
    this.loggedIn.next(false);
    this.router.navigate(['login']);
    alert('You are now logged out!');
  }

  isAuth(): boolean {
    if(sessionStorage.getItem('authToken')) {
      return true;
    }else{
      return false;
    }
  }
  
}
