import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { CheckoutService } from '../../services/checkout.service';

@Component({
  selector: 'app-account-details',
  templateUrl: './account-details.component.html',
  styleUrls: ['./account-details.component.scss']
})
export class AccountDetailsComponent implements OnInit {
  orderList: any[] = [];
  orderSubscription:Subscription | undefined = undefined;

  constructor(private checkoutService:CheckoutService) { }

  ngOnInit(): void {
    this.orderSubscription = this.checkoutService.getOrders().subscribe( (res:any) => {
      //console.log(`Res inside ts file:${res[0].name}`);
      this.orderList = res as any[];
      console.log(this.orderList);
    });
  }

}
