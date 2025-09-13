import { Component } from '@angular/core';
import { ApiserviceService } from '../../../apiservice.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register-user',
  standalone: false,
  templateUrl: './register-user.component.html',
  styleUrl: './register-user.component.css'
})
export class RegisterUserComponent {
  reg_firstname =  "";
  reg_lastname = "";
  reg_email = "";
  reg_password = "";
  constructor(private service: ApiserviceService, private router: Router) { }


  register() { 
    let credentials = {
      "firstname": this.reg_firstname,
      "lastname": this.reg_lastname,
      "email": this.reg_email,
      "password": this.reg_password,
  };
    let token = this.service.register(credentials).subscribe((data: any) => {
      let user = data;
      console.log(user.value);
      alert('User registered! Wait for activation email');
      this.router.navigate([''])
      //sessionStorage.setItem('token', token.value);
      //alert('Logged in successfully!');
      //this.loading = false;
      //window.location.reload();   
    });

  }

}
