import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class BookDataService {

  private REST_API_URL:string = "http://localhost:3000/books";

  constructor(private Http:HttpClient) { }

  getBooks():any{
    return this.Http.get(this.REST_API_URL)
    .pipe(map( (res:any) => {
      console.log(`From API inside getUsers method:${res}`);
      return res;
    } ));
  }
    
}
  

