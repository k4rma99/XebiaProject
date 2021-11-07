import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, Subject } from 'rxjs';
import { take } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class CartDataService {

  //Any to any component comm.
  //Step 1: create common data holder
  private defaultCartItems: any[] = [
    {
      "id": 27,
      "book": {
        "id": 27,
        "title": "Harry Potter",
        "author": "JK Rowling",
        "image": "http://placeimg.com/640/480/sports",
        "description": "Harry is a magician sdsdsdsdsdds",
        "price": 20
      },
      "qty":1
    },
    {
      "id": 28,
      "book": {
        "id": 28,
        "title": "Crime and Punishment",
        "author": "Dostoyevsky",
        "image": "http://placeimg.com/640/480/sports",
        "description": "Ruskolnikov is the killer!",
        "price": 15
      },
      "qty":2
    }
  ]

  totalPrice: Subject<number> = new Subject<number>();
  totalQuantity: Subject<number> = new Subject<number>();

  //to make above data subscribable we need to create an rxjs observable
  //Step 2: Create behaviour subject with default cart items
  cartItemsList = new BehaviorSubject(this.defaultCartItems);

  //Step 3: Make behaviour subject as Observable so that any other component can subscribe to it
  latestCartItemsList: Observable<any> = this.cartItemsList.asObservable();


  constructor() { }

  updateCart(book: any) {

    this.latestCartItemsList.pipe(take(1)).subscribe((cartItems) => {
      let cartItemsArr = cartItems as any[];
      //check if book already exists in cart..if then update quantity..else add new item
      let itemIndex = cartItemsArr.findIndex( item => item.id ==book.id);
      if (itemIndex!=-1){
        cartItemsArr[itemIndex].qty += 1;
      }
      else{
        let newCartItem = {
          id:book.id,
          book:book,
          qty:1
        }
        cartItemsArr.push(newCartItem);
      }
      const newCartItemsArr = [...cartItemsArr];
      this.cartItemsList.next(newCartItemsArr);
      this.calculateTotalPrice();
    })
  }

  removeItem(itemId:number){
    this.latestCartItemsList.pipe(take(1)).subscribe((cartItems) => {
      let cartItemsArr = cartItems as any[];
      //check if item  exists in cart..if then remove item using splice..else do nothing
      let itemIndex = cartItemsArr.findIndex( item => item.id ==itemId);
      if (itemIndex!=-1){
        cartItemsArr.splice(itemIndex, 1);
        const newCartItemsArr = [...cartItemsArr];
        this.cartItemsList.next(newCartItemsArr);
      }
     
      this.calculateTotalPrice();
    })
  }

  calculateTotalPrice() {
    this.latestCartItemsList.pipe(take(1)).subscribe((cartItems) => {
      let cartItemsArr = cartItems as any[];
      let totalPriceValue: number = 0;
      let totalQuantityValue: number = 0;
  
      for(let currentCartItem of cartItemsArr){
        totalPriceValue += currentCartItem.qty * currentCartItem["book"].price;
        totalQuantityValue += currentCartItem.qty;
      }
  
      //console.log(`Total price: ${totalPriceValue}, Total quantity: ${totalQuantityValue}`);
      
      this.totalPrice.next(totalPriceValue);
      this.totalQuantity.next(totalQuantityValue);    
    })
  }


}
