import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AccountDataService {
  private ADDRESS_API_URL: string = "http://localhost:3000/address/";

  constructor(private Http: HttpClient) { }

  //Shipping address operations

  getAddresses(): any {
    return this.Http.get(this.ADDRESS_API_URL)
      .pipe(map((res: any) => {
        //console.log(`From API inside getAddresses method:${res}`);
        return res;
      }));
  }



  addAddress(newAddress: any) {
    return this.Http.post(this.ADDRESS_API_URL, newAddress)
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
    return this.Http.put(this.ADDRESS_API_URL + updatedAddress.id, updatedAddress)
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
    return this.Http.delete(this.ADDRESS_API_URL+id, { observe: 'response' })
      .pipe(map((res: any) => {

        return res;
      }));
  }
}
