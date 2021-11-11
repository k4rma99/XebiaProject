import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { AccountDataService } from '../../services/account-data.service';
import { BookDataService } from '../../services/book-data.service';
import { CartDataService } from '../../services/cart-data.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styles: [
  ]
})
export class HomeComponent implements OnInit {

  bookList: any[] = [];
  bookSubscription: Subscription | undefined = undefined;
  imageRoot = "https://localhost:44370"

  constructor(private bookService: BookDataService, private cartService: CartDataService,
    private accountDataService: AccountDataService) { }

  ngOnInit(): void {
    this.bookSubscription = this.bookService.getFeaturedBooks().subscribe((res: any) => {
      //console.log(`Res inside ts file:${res[0].name}`);
      this.bookList = res as any[];
    });
    console.log(`bookList = ${this.bookList}`);
  }

  handleAddToCart(book: any) {
    this.cartService.updateCart(book);
  }

  handleAddToWishlist(book: any) {
    this.accountDataService.updateWishlist(book);
  }

}



