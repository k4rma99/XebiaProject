import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { CartDataService } from 'src/app/users/services/cart-data.service';


@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styles: [
  ]
})
export class HeaderComponent implements OnInit {
 
  
  cartItemsCount:number = 0;
  
  constructor(private cartService:CartDataService) { }

  ngOnInit(): void {
 
    
    this.cartService.latestCartItemsList.subscribe( (cartItems) => {
      console.log(`Cart Items: ${cartItems}`);
      this.cartItemsCount = cartItems.length;
    } )
 
  }

}
