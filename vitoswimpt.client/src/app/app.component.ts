import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  standalone: false,
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  loggedIn: boolean = false;
  constructor(private http: HttpClient) {}

  ngOnInit() {
    if (sessionStorage.getItem('token') != null) {
      this.loggedIn = true;
    }
  }
  title = 'vitoswimpt.client';

  logout() {
    sessionStorage.clear();
    window.location.reload();
  }

}
