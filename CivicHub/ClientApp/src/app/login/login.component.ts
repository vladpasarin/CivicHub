import { Component, OnInit, ViewChild } from "@angular/core";
import { AuthService } from "../auth.service";
import { Router } from "@angular/router";

import {
  FormBuilder,
  FormGroup,
  Validators,
  FormControl,
} from "@angular/forms";
import { User } from '../shared/user.model';
@Component({
  selector: "app-login",
  templateUrl: "./login.component.html",
  styleUrls: ["./login.component.css"],
})
export class LoginComponent implements OnInit {
  constructor(
    public authService: AuthService,
    public fb: FormBuilder,
    private router: Router
  ) {}

  selectedOption = "User";
  loginForm: FormGroup;
  success: boolean;
  users:User[]=[
    {id:1,firstName:"Vlad",lastName:"Pasarin",password:"vlad1998"},
    {id:2,firstName:"Florin",lastName:"Stan",password:"florinel99"},
    {id:3,firstName:"Eusebiu",lastName:"Timofte",password:"eusebi98"}
];

  ngOnInit() {
    this.loginForm = this.fb.group({
      firstName: [null, Validators.required],
      lastName: [null, Validators.required],
      password: [null, Validators.required],
    });
  }

  isFieldValid(field: string) {
    return (
      !this.loginForm.get(field).valid && this.loginForm.get(field).touched
    );
  }

  displayFieldCss(field: string) {
    return {
      "has-error": this.isFieldValid(field),
      "has-feedback": this.isFieldValid(field),
    };
  }
  get f() {
    return this.loginForm.controls;
  }
  onSubmit() {
    if (this.loginForm.valid) {
      this.success = true;
      setTimeout(() => {
        this.success = null;
      }, 3000);
      console.log("loginForm submitted");
    } else {
      this.success = false;
      setTimeout(() => {
        this.success = null;
      }, 3000);
      this.validateAllFormFields(this.loginForm);
    }
    const user = this.users.find(
      (x) =>
        x.firstName === this.f.firstName.value &&
        x.lastName === this.f.lastName.value &&
        x.password === this.f.password.value
    );
    if (!user) this.success = false;
    else {
      localStorage.setItem("isLogged", "true");
      localStorage.setItem("firstName", this.f.firstName.value);
      //localStorage.setItem("userId", this.f.id.value);
      setTimeout(() => {
        this.router.navigate(["/profile"],
        {queryParams:{firstName:this.f.firstName.value,lastName:this.f.lastName.value}});
      }, 2000);
    }
    console.log(user);
  }
  validateAllFormFields(formGroup: FormGroup) {
    Object.keys(formGroup.controls).forEach((field) => {
      console.log(field);
      const control = formGroup.get(field);
      if (control instanceof FormControl) {
        control.markAsTouched({ onlySelf: true });
      } else if (control instanceof FormGroup) {
        this.validateAllFormFields(control);
      }
    });
  }
  reset() {
    this.loginForm.reset();
  }
}
