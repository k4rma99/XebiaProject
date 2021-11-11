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
  shippingAddress:any;
  billingAddress:any;
  totalPrice: number = 0;
  couponCode: string = '';
  couponMessage:string = '';
  paymentMode:any;

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
      let tempAddressList = res as any[];
      tempAddressList.forEach(addr=>{
        let newAddrr=addr.fName + ' ' + addr.lName + ', ';
        newAddrr+=addr.uAddressLineOne + ', ';
        if(addr.uAddressLineTwo != null) { newAddrr+=addr.uAddressLineTwo + ', '}
        if(addr.uLandMark != null) { newAddrr+=addr.uLandMark + ', '}
        newAddrr+=addr.uCity + ', ';
        newAddrr+=addr.uState + ', ';
        newAddrr+=addr.uCountry + ', ';
        newAddrr+=addr.uPincode + ', ';
        newAddrr+=addr.uPhone;

        this.addressList.push(newAddrr);
      })
    });

    this.checkoutService.couponMessage.subscribe(
      data => this.couponMessage = data
    );
  }

  handleApplyCoupon(couponCode:string){
    this.checkoutService.applyCoupon(couponCode,this.totalPrice).subscribe( res =>{
      console.log(res);
    });
    //alert('Inside handleapply');
  }

  handlePlaceOrder(couponCode: string) {
    //call service to place new order here
    
    let orderData = {
      "couponCode": couponCode,
      "shippingAddress": this.shippingAddress,
      "billingAddress": this.billingAddress,
      "paymentMode": this.paymentMode
    }
    
    this.checkoutService.addOrder(orderData).subscribe(
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
