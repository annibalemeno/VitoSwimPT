import { Component, OnInit } from '@angular/core';
import { AuthService } from './infrastructure/auth.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  standalone: false,
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  loggedIn: boolean = false;

  constructor(private router: Router, private route: ActivatedRoute, private authService:AuthService) { }

  ngOnInit() {
    debugger;
    if (this.authService.token != null) {
      this.loggedIn = true;
    }
  }
  title = 'vitoswimpt.client';

  logout() {
    debugger;
    this.authService.logout().subscribe((data: any) => {
      console.log('logout' + data);
      sessionStorage.clear();
      if (window.location.href.indexOf('login') !== -1) {
        window.location.reload();
      } else {
        /* this.router.navigate(['']);*/
        window.location.href = '';
      }
    },
      error => {
        console.log('errore in logout');
      });;
  }
}
