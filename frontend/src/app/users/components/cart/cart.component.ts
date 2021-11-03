import { Component, OnInit } from '@angular/core';
import { CartDataService } from '../../services/cart-data.service';
import { BookDataService } from '../../services/book-data.service';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styles: [
  ]
})
export class CartComponent implements OnInit {
  cartItemList: any[] = [];

  constructor(private cartService:CartDataService) { }

  ngOnInit(): void {
    this.cartService.latestCartItemsList.subscribe( (cartItems) => {
      this.cartItemList = cartItems;
    } )
  }

}
