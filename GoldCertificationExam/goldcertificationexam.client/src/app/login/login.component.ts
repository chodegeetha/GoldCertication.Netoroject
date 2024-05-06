import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

interface Login {
  Email: String;
  Password: String;
}

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {

  Login = {
    Email: '',
    Password: '',
  };
  constructor(private http: HttpClient, private route: ActivatedRoute, private router: Router) { }
  ngOnInit(): void {

  }

  isValidPassword(password: string): boolean {
    const passwordPattern = /^(?=.*[!@#$%^&*])(?=.*[a-zA-Z0-9]).{6,}$/;
    return passwordPattern.test(password);
  }
  isValidEmail(email: string): boolean {
    const emailPattern = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;
    return emailPattern.test(email);
  }

  LoginUser() {
    if (!this.Login.Email || !this.Login.Password ) {
      alert("All fields are required");
      return;
    }
    if (!this.isValidEmail(this.Login.Email)) {
      alert("Invalid email format");
      return;
    }
    if (!this.isValidPassword(this.Login.Password)) {
      alert("Invalid Password format");
      return;
    }

    this.http.post<any>('http://localhost:5035/api/Auth/Login', this.Login).subscribe(
      (data) => {
        console.log(data);
        if (data.success) {
          alert("Successfully logged in");
          localStorage.setItem("jwtToken", data.body.token);
          console.log(data.body.token);
          this.router.navigate(["order/book"]);
          
        } else {
          alert("failed to log in");
        }
      }
    );
  }

}
