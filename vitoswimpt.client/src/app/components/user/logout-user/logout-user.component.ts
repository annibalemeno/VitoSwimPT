import { Component } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { AuthService } from '../../../infrastructure/auth.service';

@Component({
  selector: 'app-logout-user',
  standalone: false,
  templateUrl: './logout-user.component.html',
  styleUrl: './logout-user.component.css'
})
export class LogoutUserComponent {

  constructor(private router: Router, private route: ActivatedRoute, private authService: AuthService) {
  }

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
