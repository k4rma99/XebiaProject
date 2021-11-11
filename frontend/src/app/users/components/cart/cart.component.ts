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
  totalPrice:number = 0;
  imageRoot = "https://localhost:44370"

  constructor(private cartService:CartDataService) { }

  ngOnInit(): void {
    this.cartService.latestCartItemsList.subscribe( (cartItems) => {
      this.cartItemList = cartItems;
    } );
    this.cartService.totalPrice.subscribe(
      data => this.totalPrice = data
    );
    this.cartService.calculateTotalPrice();
  }

  handleRemoveItem(itemId:number){
    //console.log(`inside handleRemove()`)
    this.cartService.removeItem(itemId);
  }

  handleQtyChange(){
    this.cartService.calculateTotalPrice();
  }

}
