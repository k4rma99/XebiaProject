//Service deals with shipping address data and wishlist data

import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { map, take } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AccountDataService {
  private ADDRESS_API_URL: string = "https://localhost:44370/api/UserAddressesAPI/";

  private WISHLIST_API_URL: string = "https://localhost:44370/api/UserAddressesAPI/";

  private defaultWishList:any[] = [];

  wishListItems = new BehaviorSubject(this.defaultWishList);

  //Step 3: Make behaviour subject as Observable so that any other component can subscribe to it
  latestWishListItems: Observable<any> = this.wishListItems.asObservable();

  constructor(private Http: HttpClient) { }

  //Wishlist operations

  updateWishlist(book:any):void{
    this.latestWishListItems.pipe(take(1)).subscribe((wishItems) => {
      let wishItemsArr = wishItems as any[];
      //check if book already exists in list..if then do nothing
      let itemIndex = wishItemsArr.findIndex(item => item.id == book.id);
      if (itemIndex!=-1){
        //console.log("Item already in wishlist");
        alert("item already in wishlist!");
      }
      else{
        let newWishListItem = {
          id:book.id,
          book:book,
        }
        wishItemsArr.push(newWishListItem);
        console.log(wishItemsArr);
      }
      const newItemsArr = [...wishItemsArr];
      this.wishListItems.next(newItemsArr);
      alert('Item added to wishlist');
  
    })
  }

  //remove from wishlist
  removeItem(itemId:number){
    this.latestWishListItems.pipe(take(1)).subscribe((items) => {
      let wishItemsArr = items as any[];
      //check if item  exists in cart..if then remove item using splice..else do nothing
      let itemIndex = wishItemsArr.findIndex( item => item.id ==itemId);
      if (itemIndex!=-1){
        wishItemsArr.splice(itemIndex, 1);
        const newItemsArr = [...wishItemsArr];
        this.wishListItems.next(newItemsArr);
      }
     
      
    })
  }

  //Shipping address operations

  getAddresses(): any {
    console.log(this.ADDRESS_API_URL+"GetUserAddress"+"/"+sessionStorage.getItem('userId'));
    return this.Http.get(this.ADDRESS_API_URL+"GetUserAddress"+"/"+sessionStorage.getItem('userId'))
      .pipe(map((res: any) => {
        //console.log(`From API inside getAddresses method:${res}`);
        console.log("User Addresses:")
        console.log(res);
        return res;
      }));
  }



  addAddress(newAddress: any) {
    return this.Http.post(this.ADDRESS_API_URL+'PostUserAddress', newAddress)
    .toPromise()
    .then((res: any) => {
      //console.log(`Res inside promise: ${res}`);
      return res;
    })
    .catch((err: any) => {
      //console.log(`Promise error:${err}`);
      return err;
    })
    .finally(() => {
      //console.log(`Promise is over`);
    })
  }

  // method using promise
  updateAddress(updatedAddress: any): any {
    return this.Http.put(this.ADDRESS_API_URL+"PutUserAddress/" + updatedAddress.id, updatedAddress)
      .toPromise()
      .then((res: any) => {
        //console.log(`Res inside promise: ${res}`);
        return res;
      })
      .catch((err: any) => {
        //console.log(`Promise error:${err}`);
        return err;
      })
      .finally(() => {
        //console.log(`Promise is over`);
      })
  }

  ////method without promise
  // updateAddress(updatedAddress:any){
  //   return this.Http.post(this.ADDRESS_API_URL, updatedAddress,{observe:'response'})
  //   .pipe(map((res: any) => { 

  //     return res;
  //   }));
  // }

  deleteAddress(id: number) {
    return this.Http.delete(this.ADDRESS_API_URL+'DeleteUserAddress/'+id, { observe: 'response' })
      .pipe(map((res: any) => {

        return res;
      }));
  }
}
