import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { AccountDataService } from '../../services/account-data.service';

@Component({
  selector: 'app-shipping-address',
  templateUrl: './shipping-address.component.html',
  styleUrls: ['./shipping-address.component.scss']
})
export class ShippingAddressComponent implements OnInit {

  addressList: any[] = [];
  address: any;
  duplicateAddress: any;
  isUpdated: boolean = false;
  isAdded: boolean = false;
  addressSubscription: Subscription | undefined = undefined;

  constructor(private accountService: AccountDataService, private router: Router) { }

  ngOnInit(): void {
    this.addressSubscription = this.accountService.getAddresses().subscribe((res: any) => {
      //console.log(`Res inside ts file:${res[0].name}`);
      this.addressList = res as any[];
    });
    //console.log(`addressList = ${this.addressList}`);
  }

  handleAddModalOpen(): void {
    // this.duplicateAddress = {
    //   "name": "",
    //   "phone": "",
    //   "city": "",
    //   "pincode": ""
    // };
    this.duplicateAddress = {};
  }

  async handleAddAddress() {
    this.duplicateAddress.uId = sessionStorage.getItem('userId');
    console.log(this.duplicateAddress);
    let status = await this.accountService.addAddress(this.duplicateAddress);
    console.log(`Status:${status}`);
    if (status && status.id) {
      this.isAdded = true;

    }
  }

  handleEditModalOpen(id: number): void {
    console.log("Address id:" + id);
    this.address = this.addressList.find(addr => addr.id == id);
    this.duplicateAddress = { ...this.address };
    
  }

  handleEditModalClose() {
    this.ngOnInit();
  }

  async handleUpdate() {
    if(this.duplicateAddress.uAddressLineTwo=="") {this.duplicateAddress.uAddressLineTwo=null;}
    if(this.duplicateAddress.uLandMark=="") {this.duplicateAddress.uLandMark=null;}

    let status = await this.accountService.updateAddress(this.duplicateAddress);
    console.log(`Status:${status}`);
    if (status && status.id) {
      this.isUpdated = true;

    }

  }

  handleDelete(id: number) {
    this.accountService.deleteAddress(id).subscribe(
      (res) => {
        console.log(res);
        this.ngOnInit();
        //alert("Address deleted");

      },
      err => {
        alert("Delete Failed due to an error!");
        console.log(err);
      }
    );
  }

}
