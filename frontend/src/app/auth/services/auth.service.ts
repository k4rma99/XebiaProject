import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import {  map} from 'rxjs/operators';


@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private REST_API_URL = 'https://reqres.in/api';
  private TEST_JSON_SERVER_URL = 'http://localhost:3000/users'


  constructor(private http: HttpClient) { }

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

  isAuth(): boolean {
    if(sessionStorage.getItem('authToken')) {
      return true;
    }else{
      return false;
    }
  }
  
}
