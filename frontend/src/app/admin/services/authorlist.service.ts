import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Authors } from '../models/authors';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthorlistService {

  private AUTHOR_API_URL: string = "http://localhost:3000/authors/";
  // private AUTHOR_API_URL: string = "http://localhost:44370/api/AuthorsAPI/GetAuthors";
  headers = new HttpHeaders().set('Content-Type', 'application/json');

  constructor(private http: HttpClient) { }

  
  listAuthors(){
    return this.http.get(this.AUTHOR_API_URL);
  }

  createAuthor(author: Authors): Observable<any> {
    let API_URL = `${this.AUTHOR_API_URL}`;
    return this.http.post(API_URL, author)
      .pipe(
        catchError(this.handleError)
      )
  }

  // Update
  updateAuthor(id: any, author: Authors): Observable<any> {
    let API_URL = `${this.AUTHOR_API_URL}/${id}`;
    return this.http.put(API_URL, author, { headers: this.headers }).pipe(
      catchError(this.handleError)
    )
  }

  // Delete
  deleteAuthor(id: any): Observable<any> {
    var API_URL = `${this.AUTHOR_API_URL}/${id}`;
    return this.http.delete(API_URL).pipe(
      catchError(this.handleError)
    )
  }

  handleError(error: HttpErrorResponse) {
    if (error.error instanceof ErrorEvent) {
      console.error('An error occurred:', error.error.message);
    } else {
      console.error(
        `Backend returned code ${error.status}, ` +
        `body was: ${error.error}`);
    }
    return throwError(
      'Something bad happened; please try again later.');
  };

  listByID(id: number): Observable<any>{
    // console.log(id);
    const url = `${this.AUTHOR_API_URL}/${id}`;
    return this.http.get<Authors>(url);
  }

}
