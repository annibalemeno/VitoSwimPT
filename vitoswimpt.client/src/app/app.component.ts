import { Component, OnInit } from '@angular/core';
import { AuthService } from './infrastructure/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  standalone: false,
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  loggedIn: boolean = false;

  constructor(private authService:AuthService) { }

  ngOnInit() {
    debugger;
    if (this.authService.token != null) {
      this.loggedIn = true;
    }
  }
  title = 'vitoswimpt.client';
}
