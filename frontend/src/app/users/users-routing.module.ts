import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from '../shared/guards/auth.guard';
import { AccountDetailsComponent } from './components/account-details/account-details.component';
import { BooksListComponent } from './components/books-list/books-list.component';
import { CartComponent } from './components/cart/cart.component';
import { CheckoutComponent } from './components/checkout/checkout.component';
import { HomeComponent } from './components/home/home.component';

const routes: Routes = [
  { path: '', redirectTo:'home' },
  { path:'home', component: HomeComponent},
  { path:'books', component: BooksListComponent},
  { path:'cart', component:CartComponent},
  { path:'checkout',component:CheckoutComponent},
  { path:'account', component:AccountDetailsComponent, canActivate:[AuthGuard]}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UsersRoutingModule { }
