import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { take } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class CartDataService {
  
   //Any to any component comm.
  //Step 1: create common data holder
  private defaultCartItems:any[] = [
    {
      "id": 1,
      "title": "Harry Potter",
      "author": "JK Rowling",
      "image":"http://placeimg.com/640/480/sports",
      "description": "Harry is a magician sdsdsdsdsdds",
      "price": 20
    },
    {
      "id": 2,
      "title": "Van Helsing",
      "author": "Hugh Jackman",
      "image":"http://placeimg.com/640/480/sports",
      "description": "Van helsing is a vampire hunter sdsdsdsdsdds",
      "price": 30
    }
  ]

  //to make above data subscribable we need to create an rxjs observable
  //Step 2: Create behaviour subject with default cart items
  cartItemsList = new BehaviorSubject(this.defaultCartItems);

  //Step 3: Make behaviour subject as Observable so that any other component can subscribe to it
  latestCartItemsList: Observable<any> = this.cartItemsList.asObservable();


  constructor() { }

  updateCart(pdt:any) {
    console.log(pdt);

    this.latestCartItemsList.pipe( take(1) ).subscribe( (cartItems) => {
      console.log(cartItems);
      const newCartItemsArr = [ ...cartItems , pdt];
      this.cartItemsList.next(newCartItemsArr);
    } )
  }

}
