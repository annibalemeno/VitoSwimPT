import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ApiserviceService } from '../../../apiservice.service';
import { AuthService } from '../../../infrastructure/auth.service';

@Component({
  selector: 'app-login-user',
  standalone: false,
  templateUrl: './login-user.component.html',
  styleUrl: './login-user.component.css'
})
export class LoginUserComponent implements OnInit{

  constructor(private authService: AuthService) { }
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
    debugger;

    this.loading = true;
    let credentials = {
      "email": this.login_mail,
      "password": this.login_password
    }
    let token = this.authService.login(credentials).subscribe((data: any) => {
      debugger;
      let token = data.accessToken;
      let refreshToken = data.refreshToken;
      console.log(data);
      sessionStorage.setItem('token', token);
      sessionStorage.setItem('refreshToken', refreshToken);
      sessionStorage.setItem('email', this.login_mail);;
      alert('Logged in successfully!');
      this.loading = false;
      window.location.reload();
    }, error => {
      alert(error.error.title + ' : ' + error.error.detail);
      this.loading = false;
    }
    );
  }

  loginWithUserToken() {
    this.authService.loginWithRefreshToken().subscribe((data: any) => {
    }, error => { });
  }

}
