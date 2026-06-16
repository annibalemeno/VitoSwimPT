import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AccountService } from '../../../infrastructure/account.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-register-user',
  standalone: false,
  templateUrl: './register-user.component.html',
  styleUrl: './register-user.component.css'
})
export class RegisterUserComponent implements OnInit {
  form!: FormGroup;

  reg_firstname =  "";
  reg_lastname = "";
  reg_email = "";
  reg_password = "";
  req_password_confirm = "";

  //array of validations coming from server
  validationErrors!: { ['firstname']: undefined, ['lastname']: undefined, ['email']: undefined, ['password']: undefined, ['confirmpassword']: undefined };




  submitted = false;
  constructor(private authService: AccountService, private formBuilder: FormBuilder, private router: Router) { }
  ngOnInit(): void {
    this.form = this.formBuilder.group({
      firstname: ['', Validators.required],
      lastname: ['', Validators.required],
      email: ['', Validators.required],
      password: ['', Validators.required],
      password_confirm: ['', Validators.required]
    });

    this.validationErrors = { ['firstname']: undefined, ['lastname']: undefined, ['email']: undefined, ['password']: undefined, ['confirmpassword']: undefined };
  }

  get f() { return this.form.controls; }

  onSubmit() {
    console.log('Register OnSumbit invoked at: ', new Date().toUTCString());

    let credentials = {
      "firstname": this.f['firstname'].value,
      "lastname": this.f['lastname'].value,
      "email": this.f['email'].value,
      "password": this.f['password'].value,
      "confirmPassword": this.f['password_confirm'].value
    };

    console.log('Credentials:', JSON.stringify(credentials));

    this.submitted = true;

    let token = this.authService.register(credentials).subscribe((data: any) => {
      //let checkconsistency = typeof (this.validationErrors) != 'undefined';
      //console.log('Validation Error is different from undefined: ' + checkconsistency);
      let user = data;
      console.log(user.value);
      alert('User registered! Wait for activation email');
      this.router.navigate([''])  
    }, error => {
      this.validationErrors = error.error.errors;
      console.log(this.validationErrors);
      //alert(error.error.title + ' : ' + error.error.detail);
    });
  }

}
