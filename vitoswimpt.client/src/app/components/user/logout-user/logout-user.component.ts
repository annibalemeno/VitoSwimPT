import { Component } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { DataService } from '../../../data.service';

@Component({
  selector: 'app-logout-user',
  standalone: false,
  templateUrl: './logout-user.component.html',
  styleUrl: './logout-user.component.css'
})
export class LogoutUserComponent {

  constructor(private router: Router, private route: ActivatedRoute, private dataService: DataService) {
  }

  logout() {
    sessionStorage.clear();
    this.dataService.updateData(false);
    /*  this.router.navigate(['']);*/
    /*    window.location.reload();*/
    /* this.router.onSameUrlNavigation = 'reload';*/
    if (window.location.href.indexOf('login') !== -1) {
      window.location.reload();
    } else {
      /* this.router.navigate(['']);*/
      window.location.href = '';
    } 
  }

}
