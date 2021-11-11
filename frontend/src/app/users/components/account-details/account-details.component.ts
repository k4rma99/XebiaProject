import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { AccountDataService } from '../../services/account-data.service';
import { BookDataService } from '../../services/book-data.service';
import { CartDataService } from '../../services/cart-data.service';
import { CheckoutService } from '../../services/checkout.service';

@Component({
  selector: 'app-account-details',
  templateUrl: './account-details.component.html',
  styleUrls: ['./account-details.component.scss']
})
export class AccountDetailsComponent implements OnInit {
  orderList: any[] = [];
  wishList: any[] = [];
  orderSubscription:Subscription | undefined = undefined;

  constructor(private checkoutService:CheckoutService,private accountDataService:AccountDataService,
    private cartService:CartDataService, private bookDataService:BookDataService) { }

  ngOnInit(): void {
    this.orderSubscription = this.checkoutService.getOrderByUserId(Number(sessionStorage.getItem('userId'))).subscribe( (res:any) => {
      //console.log(`Res inside ts file:${res[0].name}`);
      this.orderList = res as any[];
      console.log(this.orderList);
    });

    this.accountDataService.latestWishListItems.subscribe( (wishItems) => {
      this.wishList = wishItems;
    } );
  }

  handleAddToCart(book:any){
    this.cartService.updateCart(book);
  }

  handleRemoveFromWishlist(book:any){
    this.accountDataService.removeItem(book.id);
  }

  handleGetBook(id:number){
    return this.bookDataService.getBookById(id);
  }

}
