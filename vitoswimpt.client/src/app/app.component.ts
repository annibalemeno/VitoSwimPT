import { Component, OnInit } from '@angular/core';
import { AccountService } from './infrastructure/account.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  standalone: false,
  styleUrl: './app.component.css'
})
export class AppComponent {

  constructor(private router: Router, private route: ActivatedRoute, public accountService: AccountService) { }

  title = 'vitoswimpt.client';

  logout() {
    this.accountService.logout();
  }
}
