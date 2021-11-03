import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UsersRoutingModule } from './users-routing.module';
import { HomeComponent } from './components/home/home.component';
import { BooksListComponent } from './components/books-list/books-list.component';
import { CartComponent } from './components/cart/cart.component';
import { Ng2SearchPipeModule } from 'ng2-search-filter';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    HomeComponent,
    BooksListComponent,
    CartComponent
  ],
  imports: [
    CommonModule,
    UsersRoutingModule,
    Ng2SearchPipeModule,
    FormsModule
  ]
})
export class UsersModule { }
