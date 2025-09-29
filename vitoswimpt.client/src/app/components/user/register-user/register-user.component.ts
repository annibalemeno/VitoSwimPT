import { Component, OnInit } from '@angular/core';
import { ApiserviceService } from '../../../apiservice.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register-user',
  standalone: false,
  templateUrl: './register-user.component.html',
  styleUrl: './register-user.component.css'
})
export class RegisterUserComponent implements OnInit {
  reg_firstname =  "";
  reg_lastname = "";
  reg_email = "";
  reg_password = "";
  req_password_confirm = "";

  //array of validations coming from server
  validationErrors!: { ['firstname']: undefined, ['lastname']: undefined, ['email']: undefined, ['password']: undefined, ['confirmpassword']: undefined };




  submitted = false;
  constructor(private service: ApiserviceService, private router: Router) { }
  ngOnInit(): void {
    this.validationErrors = { ['firstname']: undefined, ['lastname']: undefined, ['email']: undefined, ['password']: undefined, ['confirmpassword']: undefined };
    }


  register() { 
    let credentials = {
      "firstname": this.reg_firstname,
      "lastname": this.reg_lastname,
      "email": this.reg_email,
      "password": this.reg_password,
      "confirmPassword": this.req_password_confirm
    };

    this.submitted = true;

    let token = this.service.register(credentials).subscribe((data: any) => {
      //let checkconsistency = typeof (this.validationErrors) != 'undefined';
      //console.log('Validation Error is different from undefined: ' + checkconsistency);
      let user = data;
      console.log(user.value);
      alert('User registered! Wait for activation email');
      this.router.navigate([''])
      //sessionStorage.setItem('token', token.value);
      //alert('Logged in successfully!');
      //this.loading = false;
      //window.location.reload();   
    }, error => {
      this.validationErrors = error.error.errors;
      console.log(this.validationErrors);
      //alert(error.error.title + ' : ' + error.error.detail);
    });
  }

}
