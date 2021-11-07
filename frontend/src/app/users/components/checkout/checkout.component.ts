import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AccountDataService } from '../../services/account-data.service';
import { CartDataService } from '../../services/cart-data.service';
import { CheckoutService } from '../../services/checkout.service';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.scss']
})
export class CheckoutComponent implements OnInit {

  cartItemList: any[] = [];
  addressList: any[] = [];
  chosenAddress:any;
  totalPrice: number = 0;
  couponCode: string = '';

  constructor(private cartService: CartDataService, private checkoutService: CheckoutService,
    private accountService: AccountDataService, private router: Router) { }

  ngOnInit(): void {
    this.cartService.latestCartItemsList.subscribe((cartItems) => {
      this.cartItemList = cartItems;
    });
    this.cartService.totalPrice.subscribe(
      data => this.totalPrice = data
    );
    this.cartService.calculateTotalPrice();
    this.accountService.getAddresses().subscribe((res:any) => {
      this.addressList = res as any[];
    });
  }

  handlePlaceOrder(couponCode: string) {
    //call service to place new order here
    
    this.checkoutService.addOrder(couponCode,this.chosenAddress).subscribe(
      (res) => {

        alert("Order placed");
        this.router.navigate(['login']);
      },
      err => {
        alert("Order Failed due to an error!");
        console.log(err);
      }
    );
    this.router.navigate(['users']);
  }

}
