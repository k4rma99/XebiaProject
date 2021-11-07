import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, take } from 'rxjs/operators';
import { CartDataService } from './cart-data.service';

@Injectable({
  providedIn: 'root'
})
export class CheckoutService {

  private ORDERS_API_URL:string = "http://localhost:3000/orders";
 
  totalPrice:number = 0;
  totalQuantity:number = 0;

  constructor(private http:HttpClient,private cartService:CartDataService) { }

  getOrders():any{
    return this.http.get(this.ORDERS_API_URL)
    .pipe(map( (res:any) => {
     
      return res;
    } ));
  }

  addOrder(couponCode:string,chosenAddress:any){
    let newOrder:any = {};
   
  
    this.cartService.latestCartItemsList.pipe(take(1)).subscribe((cartItems) => {
      let cartItemsArr = cartItems as any[];
      let items:any[] = [];//contain each book order details 
      let totalPriceValue:number = 0;
      let totalQuantityValue:number = 0;

      cartItemsArr.forEach( (cartItem) =>{
        let newItem = {
          "book":cartItem.book,
          "qty":cartItem.qty
        }

         //temp fix - calc tot price and qty again since getting from service does not seem to work
        totalPriceValue += cartItem.qty * cartItem["book"].price;
        totalQuantityValue += cartItem.qty;
        items.push(newItem);
        
      });
      this.totalPrice = totalPriceValue;
      this.totalQuantity = totalQuantityValue;
         
      newOrder = {
        "items":items,
        "couponCode":couponCode,
        "totalPrice":this.totalPrice,
        "totalQuantity":this.totalQuantity,
        "address":chosenAddress
      }
      console.log(newOrder);

      
    });


    //below code is not fetching updated value of totalPrice and quantity from cart service due to some issue
    //So we use temporary fix in code above
    // this.cartService.totalPrice.subscribe(
    //   data => {
    //     console.log(`Inside checkoutservice: TotalPrice:${this.totalPrice}`);
    //     this.totalPrice = data
    //   }
    // );
    // this.cartService.totalQuantity.subscribe(
    //   data => this.totalQuantity = data
    // );

   
    // newOrder["totalPrice"] = this.totalPrice;
    // newOrder["totalQuantity"] = this.totalQuantity;
    // console.log(newOrder);

    
  
    return this.http.post(this.ORDERS_API_URL, newOrder,{observe:'response'})
    .pipe(map((res: any) => { 
     
      return res;
    }));
  
  }

  
}
