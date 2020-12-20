import { Component, OnInit, ViewChild } from "@angular/core";
import { AuthService } from "../auth.service";
import { Router } from "@angular/router";
import { ApiService } from "../shared/api.service";
import { Request } from "../shared/request";
import { RequestResponse } from "../shared/requestResponse";

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
      private router: Router,
      private api: ApiService
  ) {}

  selectedOption = "User";
  loginForm: FormGroup;
    success: boolean;
    request = new Request();
    requestResponse = new RequestResponse();
    token: string;
  
  ngOnInit() {
    this.loginForm = this.fb.group({
      mail: [null, Validators.required],
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
      this.request.mail = this.f.mail.value;
      this.request.password = this.f.password.value;
      this.api.getLoginToken(this.request).subscribe((data) => {
          this.requestResponse = data.body as RequestResponse;
          console.log(this.requestResponse.token)
      }, error => {
          console.log("Error while validating token");

      },
          () => {
              console.log(this.requestResponse.token);

              if (!this.requestResponse.token) this.success = false;
              else {

                  sessionStorage.setItem('isLogged', 'true');
                  sessionStorage.setItem('userId', this.requestResponse.id);
                  this.api.getUserById(this.requestResponse.id).subscribe((user: User) => {
                    sessionStorage.setItem('firstName',user.firstName);
              });
                  
                  console.log(this.requestResponse.id);

                  setTimeout(() => {
                      this.router.navigate(["profile", this.requestResponse.id]);
                  }, 1000);

              }
              

          }
);
      
    
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
