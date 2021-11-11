import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class BookDataService {

  private BOOK_API_URL:string = "https://localhost:44370/api/BooksAPI/";
  private AUTHOR_API_URL:string = "https://localhost:44370/api/AuthorsAPI/";
  private CATEGORY_API_URL:string = "https://localhost:44370/api/CategoriesAPI/";

  // private TEST_JSON_SERVER:string = "http://localhost:3000/books";

  constructor(private Http:HttpClient) { }

  getBooks():any{
    return this.Http.get(this.BOOK_API_URL+"GetBooks")
    .pipe(map( (res:any) => {
      console.log("Inside Get Books");
      console.log(res);
      return res;
    } ));
  }

  getBookById(id:number):any{
    return this.Http.get(this.BOOK_API_URL+"GetBook/"+id)
    .pipe(map( (res:any) => {
      console.log("Inside Get Book By Id");
      console.log(res);
      return res;
    } ));
  }

  getFeaturedBooks():any{
    return this.Http.get(this.BOOK_API_URL+"GetFeaturedBooks")
    .pipe(map((res:any)=> {
      console.log(res);
      return res;
    }));
  }

  getAuthor(id:number):any{
    return this.Http.get(this.AUTHOR_API_URL+"GetAuthor"+"/"+id)
    .pipe(map( (res:any) => {
      console.log(`From API inside getUsers method:${res}`);
      console.log(res);
      return res;
    } ));
  }

  getCategory(id:number):any{
    return this.Http.get(this.CATEGORY_API_URL+"GetCategory"+"/"+id)
    .pipe(map( (res:any) => {
      console.log(`From API inside getUsers method:${res}`);
      console.log(res);
      return res;
    } ));
  }
    
}
  

