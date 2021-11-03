import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UsersRoutingModule } from './users-routing.module';
import { UserDashboardComponent } from './components/user-dashboard/user-dashboard.component';


@NgModule({
  declarations: [
    UserDashboardComponent
  ],
  imports: [
    CommonModule,
    UsersRoutingModule
  ]
})
export class UsersModule { }
