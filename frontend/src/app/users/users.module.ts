import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UsersRoutingModule } from './users-routing.module';
import { HomeComponent } from './components/home/home.component';
import { BooksListComponent } from './components/books-list/books-list.component';
import { CartComponent } from './components/cart/cart.component';
import { Ng2SearchPipeModule } from 'ng2-search-filter';
import { FormsModule } from '@angular/forms';
import { CheckoutComponent } from './components/checkout/checkout.component';
import { HttpClientModule } from '@angular/common/http';
import { AccountDetailsComponent } from './components/account-details/account-details.component';
import { ShippingAddressComponent } from './components/shipping-address/shipping-address.component';


@NgModule({
  declarations: [
    HomeComponent,
    BooksListComponent,
    CartComponent,
    CheckoutComponent,
    AccountDetailsComponent,
    ShippingAddressComponent
  ],
  imports: [
    CommonModule,
    UsersRoutingModule,
    Ng2SearchPipeModule,
    FormsModule,
    HttpClientModule
  ]
})
export class UsersModule { }
