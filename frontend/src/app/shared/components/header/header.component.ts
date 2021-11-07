import { Component, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { Subscription } from 'rxjs';
import { AuthService } from 'src/app/auth/services/auth.service';
import { CartDataService } from 'src/app/users/services/cart-data.service';


@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styles: [
  ]
})
export class HeaderComponent implements OnInit {
 
  
  cartItemsCount:number = 0;
  loggedIn:boolean = false; //this should dynamically change to true..fix needed
  
  constructor(private cartService:CartDataService,private authService:AuthService) { }
  

  ngOnInit(): void {
 
    
    this.cartService.latestCartItemsList.subscribe( (cartItems) => {
      //console.log(`Cart Items: ${cartItems}`);
      this.cartItemsCount = cartItems.length;
    } );
    if(sessionStorage.getItem('authToken')){
      this.loggedIn = true;
    }
    this.authService.loggedIn.subscribe(
      data => this.loggedIn = data
    );
    
  }

  handleLogout(){
    this.authService.logout();
  }

}
