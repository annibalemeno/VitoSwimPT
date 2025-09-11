import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  standalone: false,
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  loggedIn: boolean = false;
  constructor(private http: HttpClient, private router: Router, private route: ActivatedRoute) { }

  ngOnInit() {
    if (sessionStorage.getItem('token') != null) {
      this.loggedIn = true;
    }
  }
  title = 'vitoswimpt.client';

  logout() {
    sessionStorage.clear();
    /*window.location.reload();*/
    /*this.router.navigate(['']);*/
    /* this.router.onSameUrlNavigation = 'reload';*/
    if (window.location.href.indexOf('login') !== -1) {
      window.location.reload();
    } else {

    } this.router.navigate(['']);
  }
}
