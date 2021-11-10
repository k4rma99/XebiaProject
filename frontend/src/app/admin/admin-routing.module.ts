import { UserProfileComponent } from './components/user-profile/user-profile.component';
import { BookProfileComponent } from './components/book-profile/book-profile.component';
import { OrderDetailsComponent } from './components/order-details/order-details.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from '../auth/components/login/login.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { ActivityComponent } from './components/activity/activity.component';
import { CouponsComponent } from './components/coupons/coupons.component';
import { BooksListComponent } from './components/books-list/books-list.component';
import { UserListComponent } from './components/user-list/user-list.component';
import { OrdersComponent } from './components/orders/orders.component';

//change admin default route to required component after creating necessary admin components
//LoginComponent is now only set as a placeholder
const routes: Routes = [
  { path: 'dashboard', component: DashboardComponent },
  { path: 'activity', component: ActivityComponent },
  { path: 'coupons', component: CouponsComponent },
  { path: 'booksdb', component: BooksListComponent },
  { path: 'usersdb', component: UserListComponent },
  { path: 'orders', component: OrdersComponent },
  { path: 'orders/:orderId', component: OrderDetailsComponent },
  { path: 'booksdb/:booksId', component: BookProfileComponent },
  { path: 'usersdb/:userId', component: UserProfileComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
