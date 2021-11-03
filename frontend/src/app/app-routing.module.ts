import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './auth/components/login/login.component';
import { SignupComponent } from './auth/components/signup/signup.component';
import { AuthGuard } from './shared/guards/auth.guard';
import { RoleGuard } from './shared/guards/role.guard';

const routes: Routes = [
  {path:'',redirectTo:'login', pathMatch:'full'},
  {path:'login',component:LoginComponent},
  {path:'signup',component:SignupComponent},
  { path: 'users', loadChildren: () => import('./users/users.module').then(m => m.UsersModule) ,canActivate:[AuthGuard]}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
