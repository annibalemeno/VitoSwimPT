import { Component, OnInit } from '@angular/core';
import { AccountService } from './infrastructure/account.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  standalone: false,
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  loggedIn: boolean = false;

  constructor(private router: Router, private route: ActivatedRoute, private authService: AccountService) { }

  ngOnInit() {
    debugger;
    if (this.authService.token != null) {
      this.loggedIn = true;
    }
  }
  title = 'vitoswimpt.client';

  logout() {
    this.authService.logout();
  }
}
