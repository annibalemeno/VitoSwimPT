import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ApiserviceService } from '../../../apiservice.service';

@Component({
  selector: 'app-login-user',
  standalone: false,
  templateUrl: './login-user.component.html',
  styleUrl: './login-user.component.css'
})
export class LoginUserComponent implements OnInit{

  constructor(private service: ApiserviceService) { }
  loggedIn: boolean = false;
  loading = false;
  login_mail = "";
  login_password = "";
/*  loggedIn: boolean = false;*/

    ngOnInit(): void {
      if (sessionStorage.getItem('token') != null) {
        this.loggedIn = true;
      }
    }


  login() {
    this.loading = true;
    let credentials = {
      "email": this.login_mail,
      "password": this.login_password
    }
    let token = this.service.login(credentials).subscribe((data: any) => {
      let token = data;
      console.log(data.value);
      sessionStorage.setItem('token', token.value);
      alert('Logged in successfully!');
      this.loading = false;
      window.location.reload();
       /*this.router.navigate(['/home'])*/
    });

  }

}
