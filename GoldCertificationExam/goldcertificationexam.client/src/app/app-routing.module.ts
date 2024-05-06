import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SignupComponent } from './signup/signup.component';
import { LoginComponent } from './login/login.component';
import { AdminPageComponent } from './admin-page/admin-page.component';
import { AuthService } from './auth.service';
import { BookOrderComponent } from './book-order/book-order.component';


const routes: Routes = [

  { path: 'Signup-form', component: SignupComponent },
  { path: 'Login-form', component: LoginComponent },
  { path: 'show-form', component: AdminPageComponent, canActivate: [AuthService] },
  { path: 'order/book', component: BookOrderComponent },
  { path: 'nav/admin', component: AdminPageComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
