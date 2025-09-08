import { Component } from '@angular/core';
import { ApiserviceService } from '../../../apiservice.service';

@Component({
  selector: 'app-login-user',
  standalone: false,
  templateUrl: './login-user.component.html',
  styleUrl: './login-user.component.css'
})
export class LoginUserComponent {

  constructor(private service: ApiserviceService) { }

  login_mail = "";
  login_password = "";

  login() {
    let credentials = {
      "email": this.login_mail,
      "password": this.login_password
    }
    let token = this.service.login(credentials).subscribe((data: any) => {
      let token = data;
      console.log(data.value);
      sessionStorage.setItem('token', token.value);
    });

  }

}
