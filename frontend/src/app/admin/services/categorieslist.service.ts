import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Genre } from '../models/genre';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class CategorieslistService {

  private CAT_API_URL: string = "http://localhost:3000/genres/"
  headers = new HttpHeaders().set('Content-Type', 'application/json');

  constructor(private http: HttpClient) {  }
  
  listGenres(){
    return this.http.get(this.CAT_API_URL);
  }

  createGenre(cat: Genre): Observable<any> {
    let API_URL = `${this.CAT_API_URL}`;
    return this.http.post(API_URL, cat)
      .pipe(
        catchError(this.handleError)
      )
  }

  // Update
  updateGenre(id: any, cat: Genre): Observable<any> {
    let API_URL = `${this.CAT_API_URL}/${id}`;
    return this.http.put(API_URL, cat, { headers: this.headers }).pipe(
      catchError(this.handleError)
    )
  }

  // Delete
  deleteGenre(id: any): Observable<any> {
    var API_URL = `${this.CAT_API_URL}/${id}`;
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
    const url = `${this.CAT_API_URL}/${id}`;
    return this.http.get<Genre>(url);
  }

}
