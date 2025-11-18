import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ApiserviceService } from '../../../apiservice.service';
import { AccountService } from '../../../infrastructure/account.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-login-user',
  standalone: false,
  templateUrl: './login-user.component.html',
  styleUrl: './login-user.component.css'
})
export class LoginUserComponent implements OnInit{
  form!: FormGroup;

  loading = false;
  submitted = false;

  constructor(
    private formBuilder: FormBuilder,
    public accountService: AccountService) { }

  ngOnInit(): void {

      this.form = this.formBuilder.group({
        email: ['', Validators.required],
        password: ['', Validators.required]
      });

    }

  get f() { return this.form.controls; }


  onSubmit() {
    this.submitted = true;
    console.log('OnSumbit invoked at: ', new Date().toUTCString());
    debugger;
    this.loading = true;
    let credentials = {
      "email": this.f['email'].value,
      "password": this.f['password'].value
    }

    let token = this.accountService.login(credentials).subscribe((data: any) => {
      debugger;
      let token = data.accessToken;
      let refreshToken = data.refreshToken;
      console.log('data in login user component: ' + data.toString());
      sessionStorage.setItem('token', token);
      sessionStorage.setItem('refreshToken', refreshToken);
      sessionStorage.setItem('email', credentials.email);;
      alert('Logged in successfully!');
      this.loading = false;
      window.location.reload();
    }, error => {
      alert(error.error.title + ' : ' + error.error.detail);
      this.loading = false;
    }
    );

  } 
}
