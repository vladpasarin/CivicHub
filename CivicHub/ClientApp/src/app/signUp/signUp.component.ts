import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { ApiService } from "../shared/api.service";
import {
  FormBuilder,
  FormGroup,
  Validators,
  FormControl,
} from "@angular/forms";

@Component({
  selector: "sign-up",
  templateUrl: "./signUp.component.html",
  styleUrls: ["./signUp.component.css"],
})
export class SignUpComponent implements OnInit {
  addUserForm: FormGroup;
  success: boolean;
  birthDate: string;

  constructor(
    public fb: FormBuilder,
      private router: Router,
      private api: ApiService
  ) {}

  ngOnInit() {
    this.addUserForm = this.fb.group({
      firstName: [null, Validators.required],
      lastName: [null, Validators.required],
      mail: [null, Validators.required],
      password: [null, Validators.required]
    });
  }

  get f() {
    return this.addUserForm.controls;
  }

  isFieldValid(field: string) {
    return (
      !this.addUserForm.get(field).valid && this.addUserForm.get(field).touched
    );
  }

  displayFieldCss(field: string) {
    return {
      "has-error": this.isFieldValid(field),
      "has-feedback": this.isFieldValid(field),
    };
  }
  onSubmit() {
    if (this.addUserForm.valid) {
      this.success = true;
      setTimeout(() => {
        this.success = null;
      }, 3000);
        console.log("addUserForm submitted");
        this.api.addUser(this.addUserForm.value).subscribe();
        console.log(this.addUserForm.value);
        sessionStorage.setItem('isLoggedIn', 'true');
        sessionStorage.setItem('firstName', this.f.firstName.value);

        this.router.navigate(["/home"]);
    } else {
      this.success = false;
      setTimeout(() => {
        this.success = null;
      }, 3000);
      this.validateAllFormFields(this.addUserForm);
    }
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
    this.addUserForm.reset();
  }
}
