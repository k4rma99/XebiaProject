import { CouponsComponent } from './components/coupons/coupons.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminRoutingModule } from './admin-routing.module';
import { HeaderComponent } from './components/header/header.component';
import { FooterComponent } from './components/footer/footer.component';
import { UserListComponent } from './components/user-list/user-list.component';
import { BooksListComponent } from './components/books-list/books-list.component';
import { ActivityComponent } from './components/activity/activity.component';
import { OrdersComponent } from './components/orders/orders.component';
import { OrderDetailsComponent } from './components/order-details/order-details.component';
import { UserProfileComponent } from './components/user-profile/user-profile.component';
import { BookProfileComponent } from './components/book-profile/book-profile.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    HeaderComponent,
    FooterComponent,
    DashboardComponent,
    UserListComponent,
    BooksListComponent,
    ActivityComponent,
    CouponsComponent,
    OrdersComponent,
    OrderDetailsComponent,
    UserProfileComponent,
    BookProfileComponent,
  ],
  imports: [
    CommonModule,
    AdminRoutingModule,
    HttpClientModule,
    NgbModule,
    FormsModule,
    ReactiveFormsModule
  ],
})
export class AdminModule {}
