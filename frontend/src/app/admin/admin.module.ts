import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminRoutingModule } from './admin-routing.module';
import { HeaderComponent } from './components/shared/header/header.component';
import { FooterComponent } from './components/shared/footer/footer.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { UserListComponent } from './components/user-list/user-list.component';
import { BooksListComponent } from './components/books-list/books-list.component';
import { ActivityComponent } from './components/activity/activity.component';
import { CouponsComponent } from './components/coupons/coupons.component';
import { OrdersComponent } from './components/orders/orders.component';

 @NgModule({
  declarations: [ 
    HeaderComponent, FooterComponent, DashboardComponent, UserListComponent, BooksListComponent, ActivityComponent, CouponsComponent, OrdersComponent
  ],
  imports: [
    CommonModule,
    AdminRoutingModule
  ]
})
export class AdminModule { }
