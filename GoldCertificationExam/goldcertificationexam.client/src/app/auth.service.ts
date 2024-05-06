import { Injectable } from '@angular/core';
import { ActivatedRoute, ActivatedRouteSnapshot, Router, RouterStateSnapshot } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private router: Router) { }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    const jwtToken = localStorage.getItem('jwtToken');

    if (jwtToken) {
      const tokenParts = jwtToken.split('.');
      if (tokenParts.length === 3) {
        const encodedPayload = tokenParts[1];
        const decodedPayload = atob(encodedPayload);
        const payload = JSON.parse(decodedPayload);
        const userRoles: string[] = String(payload['Roles']).split(',');
        console.log(userRoles);

        if (userRoles.includes('ADMIN'))
          return true;
        else {
          this.router.navigate([""]);
          return false;
        }
      } else {
        console.error('Invalid JWT token format:', jwtToken);
        return false;
      }
    } else {
      console.error('JWT token not found in localStorage');
      return false;
    }

  }

  getUserId(): string {
    const jwtToken = localStorage.getItem('jwtToken');
    if (jwtToken) {
      const tokenParts = jwtToken.split('.');
      if (tokenParts.length === 3) {
        const encodedPayload = tokenParts[1];
        const decodedPayload = atob(encodedPayload);
        const payload = JSON.parse(decodedPayload);
        return payload['userId'] || '';
      } else {
        console.error('Invalid JWT token format:', jwtToken);
      }
    } else {
      console.error('JWT token not found in localStorage');
    }
    return '';
  }

}

