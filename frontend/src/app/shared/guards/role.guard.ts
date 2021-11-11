import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RoleGuard implements CanActivate {
  canActivate(){
    let role = sessionStorage.getItem('userRole');
    if(role == 'admin')
      return true;
    alert("You don't have rights to access this resource!");
    return false;
  }
  
}
