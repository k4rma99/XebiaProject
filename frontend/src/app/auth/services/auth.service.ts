import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Subject } from 'rxjs';
import {  map} from 'rxjs/operators';


@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private REST_API_URL = 'https://reqres.in/api';
  private TEST_JSON_SERVER_URL = 'http://localhost:3000/users'
  public loggedIn:Subject<boolean> = new Subject<boolean>();
  

  constructor(private http: HttpClient,private router:Router) { 
    if(sessionStorage.getItem('authToken')){
      this.loggedIn.next(true);
    }
    //console.log(`Inside authservice`);
  }

  login(userData: any) {
    //console.log("Inside Authservice")
    //console.log(userData);
    return this.http.post(this.REST_API_URL+'/login', userData,{observe:'response'})
      .pipe(map((res: any) => { //  get the resp from the REST API
        
        //  send the resp to the comp ts
        return res;
      }));
  }

  signup(userData:any){
    return this.http.post(this.TEST_JSON_SERVER_URL, userData,{observe:'response'})
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
