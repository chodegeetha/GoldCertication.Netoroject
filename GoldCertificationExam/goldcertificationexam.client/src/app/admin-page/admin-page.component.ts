import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';

@Component({
  selector: 'app-admin-page',
  templateUrl: './admin-page.component.html',
  styleUrl: './admin-page.component.css'
})
export class AdminPageComponent {

  dropdownValues: any[] = [];

  constructor(private http: HttpClient) { }

  ngOnInit(): void {

    
  }

  getMenusList(id: number) {
    this.http.get<any[]>(`http://localhost:5035/api/OrderBooking/MenuslistByPackageId?Id=${id}`)
      .subscribe(data => {
        this.dropdownValues = data;
      });
  }
}
