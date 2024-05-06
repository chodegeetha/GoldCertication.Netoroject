import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';


interface OrderBooking
{
 
  name: string;
  email: string;
  location: string;
  mobileNumber: string;
  guests: number;
  packageId: number;
  message: string;
  eatingMode: string;
  created: Date;
}
interface Package {



  packageId: number;
  packageName: String;
  description: String;
  price:number;


}


@Component({
  selector: 'app-book-order',
  templateUrl: './book-order.component.html',
  styleUrl: './book-order.component.css'
})
export class BookOrderComponent {

  OrderBooking = {

    name: "",
    email: "",
    location: "",
    mobileNumber: "",
    guests: 0,
    packageId: 0,
    message: "",
    eatingMode: "",
    created: Date,
  }

  packages: Package[] = [];

  constructor(private http: HttpClient) { }
  ngOnInit(): void {
    this.getPackages()
  }

  getPackages() {
    this.http.get<{ success: boolean, data: Package[] }>('http://localhost:5035/api/OrderBooking/getallpackages').subscribe(
      (response) => {
        console.log('Response from API:', response);
        this.packages = response.data;
        console.log('Packages:', this.packages);
      },
      (error) => {
        console.error('Failed to retrieve the details:', error);
        alert("Failed to retrieve the details");
      }
    );
  }


  OrderSubmission() {
    const emailPattern = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;
    const phonePattern = /^[0-9]{10}$/;

    if (!this.OrderBooking.name || !this.OrderBooking.mobileNumber || !this.OrderBooking.email ||
      !this.OrderBooking.guests || !this.OrderBooking.created || !this.OrderBooking.packageId ||
      !this.OrderBooking.location || !this.OrderBooking.eatingMode || !this.OrderBooking.message) {
      alert('Please fill in all fields.');
      return;
    }

    if (!emailPattern.test(this.OrderBooking.email)) {
      alert('Please enter a valid email address.');
      return;
    }

    if (!phonePattern.test(this.OrderBooking.mobileNumber)) {
      alert('Please enter a valid phone number (10 digits only).');
      return;
    }

    this.http.post('http://localhost:5035/api/OrderBooking/Orderdetails', this.OrderBooking).subscribe({
      next: (data) => {
        console.log(data);
        alert("Orders details posted successfully");
      },
      error: (error) => {
        console.error('Failed to send the data:', error);
        alert("Failed to send the data");
      }
    });
  }
}


      
  
