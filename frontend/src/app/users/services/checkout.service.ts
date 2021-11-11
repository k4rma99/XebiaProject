import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { map, take } from 'rxjs/operators';
import { CartDataService } from './cart-data.service';

@Injectable({
  providedIn: 'root'
})
export class CheckoutService {

  private ORDERS_API_URL: string = "https://localhost:44370/api/OrdersAPI/";
  private COUPON_API_URL: string = "https://localhost:44370/api/CouponsAPI/";

  totalPrice: number = 0;
  totalQuantity: number = 0;
  totalPriceCopy: number = 0;
  couponMessage:BehaviorSubject<string> = new BehaviorSubject<string>('');

  constructor(private http: HttpClient, private cartService: CartDataService) { }

  applyCoupon(couponCode: string,totalPrice:number) {
    //alert("inside apply service")
    return this.http.get(this.COUPON_API_URL+'GetCoupons')
      .pipe(map((res: any) => {
        //alert('inside post');
        let couponList = res as any[];
        let discountCoupon = couponList.find(coupon => coupon.coCode == couponCode);
        if (discountCoupon) {
          sessionStorage.setItem('couponId', discountCoupon.coId)
          console.log(discountCoupon);
          this.cartService.totalPrice.next(totalPrice- (totalPrice*discountCoupon.coDiscount/100));
          this.couponMessage.next(`Coupon applied! Discount of ${discountCoupon.coDiscount}% availed!`);
        }
        else {
          this.couponMessage.next(`Invalid Coupon!`);
        }
      }));
  }

  getOrders(): any {
    return this.http.get(this.ORDERS_API_URL+'GetOrders')
      .pipe(map((res: any) => {
        console.log(res)
        return res;
      }));
  }
  getOrderByUserId(id:number): any{
    return this.http.get(this.ORDERS_API_URL+'GetOrdersByUserID/'+id)
      .pipe(map((res: any) => {
        console.log("Inside get order by Id:")
        console.log(res)
        return res;
      }));
  }

  addOrder(orderData:any) {
    let newOrder: any = {};


    this.cartService.latestCartItemsList.pipe(take(1)).subscribe((cartItems) => {
      let cartItemsArr = cartItems as any[];
      let items: any[] = [];//contain each book order details 
      cartItemsArr.forEach((cartItem) => {
        let newItem = {
          "bookId": cartItem.book.bId,
          "qty": cartItem.qty
        }
        console.log(newItem);

        items.push(newItem);

      });
      // this.totalPrice = totalPriceValue;
      this.cartService.totalPrice.subscribe( data => this.totalPrice = data);
      this.cartService.totalQuantity.subscribe(data => this.totalQuantity = data);

      newOrder = {
        "uId":sessionStorage.getItem('userId'),
        "items": items,
        "orCouponId": sessionStorage.getItem('couponId'),
        "totalPrice": this.totalPrice,
        "totalQuantity": this.totalQuantity,
        "shippingAddress": orderData.shippingAddress,
        "billingAddress": orderData.billingAddress,
        "paymentMode": orderData.paymentMode
      }
      console.log(newOrder);


    });

    return this.http.post(this.ORDERS_API_URL+'PostOrder', newOrder, { observe: 'response' })
      .pipe(map((res: any) => {

        return res;
      }));

  }


}
