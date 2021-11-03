import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { CartDataService } from '../../services/cart-data.service';
import { BookDataService } from '../../services/book-data.service';

@Component({
  selector: 'app-books-list',
  templateUrl: './books-list.component.html',
  styles: [
  ]
})
export class BooksListComponent implements OnInit {
  term: string = '';
  bookList: any[] = [];
  bookSubscription:Subscription | undefined = undefined;

  constructor(private bookService:BookDataService,private cartService:CartDataService) { }

  ngOnInit(): void {
    this.bookSubscription = this.bookService.getBooks().subscribe( (res:any) => {
      //console.log(`Res inside ts file:${res[0].name}`);
      this.bookList = res as any[];
    });
    console.log(`userList = ${this.bookList}`);
  }

  handleAddToCart(book:any){
    this.cartService.updateCart(book);
  }

}
