import { BookItem } from './../models/book-item';
import { Observable, throwError } from 'rxjs';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, first, map, mergeMap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class BooklistService {

  private BOOK_API_URL: string = "http://localhost:3000/books/";
  headers = new HttpHeaders().set('Content-Type', 'application/json');

  constructor(private http: HttpClient) {  }

  listBooks(){
    return this.http.get(this.BOOK_API_URL);
  }

  createBook(book: BookItem): Observable<any> {
    let API_URL = `${this.BOOK_API_URL}`;
    return this.http.post(API_URL, book)
      .pipe(
        catchError(this.handleError)
      )
  }

  // Update
  updateBook(id: any, book: BookItem): Observable<any> {
    let API_URL = `${this.BOOK_API_URL}/${id}`;
    return this.http.put(API_URL, book, { headers: this.headers }).pipe(
      catchError(this.handleError)
    )
  }

  // Delete
  deleteBook(id: any): Observable<any> {
    var API_URL = `${this.BOOK_API_URL}/${id}`;
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
    const url = `${this.BOOK_API_URL}/${id}`;
    return this.http.get<BookItem>(url);
  }

}
