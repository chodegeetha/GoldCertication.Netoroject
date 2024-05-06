import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

interface SignUp {
  userName: string;
  email: String;
  password: String;
}

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrl: './signup.component.css'
})
export class SignupComponent {

  SignUp = {
    userName: "",
    email: "",
    password: ""

  }
  confirmpassword = "";

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

  SignUpUser() {
    if (!this.SignUp.email || !this.SignUp.password || !this.SignUp.password || !this.confirmpassword) {
      alert("All fields are required");
      return;
    }

    if (!this.isValidEmail(this.SignUp.email)) {
      alert("Invalid email format");
      return;
    }
    if (!this.isValidPassword(this.SignUp.password)) {
      alert("Invalid Password format");
      return;
    }
    this.http.post('http://localhost:5035/api/Auth/SignUp', this.SignUp).subscribe({
      next: (data) => {
        console.log(data);
        alert("User details posted successfully");
        this.router.navigate(["Login-form"]);
      },
      error: (error) => {
        alert("Failed to send the data");
      }
    });
  }
}





