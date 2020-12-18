import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { ApiService } from 'src/app/shared/api.service';

@Component({
  selector: 'sign-form',
  templateUrl: './sign-form.component.html',
  styleUrls: ['./sign-form.component.css']
})
export class SignFormComponent implements OnInit {

  addSignForm: FormGroup;
  success: boolean;

  constructor(private fb:FormBuilder, private api:ApiService) { }

  @ViewChild("signForm") signForm: ModalDirective;
  
  validateAllFormFields(formGroup: FormGroup) {
    Object.keys(formGroup.controls).forEach((field) => {
        const control = formGroup.get(field);
        if (control instanceof FormControl) {
            control.markAsTouched({ onlySelf: true });
        } else if (control instanceof FormGroup) {
            this.validateAllFormFields(control);
        }
    });
}

  get f() {
    return this.addSignForm.controls;
}

  ngOnInit() {
    this.addSignForm = this.fb.group({
      firstName: [null, Validators.required],
      lastName: [null, Validators.required],
      cnp: [null, Validators.required],
      address: [null, Validators.required],
      idSeries: [null, Validators.required],
      idNumber: [null, Validators.required],
  });
  }

  addSign() {
    if (this.addSignForm.valid) {
        this.success = true;
        setTimeout(() => {
            this.success = null;
        }, 3000);
        console.log("loginForm submitted");
        console.log(this.f);
        //api add
    } else {
        this.success = false;
        setTimeout(() => {
            this.success = null;
        }, 3000);
        this.validateAllFormFields(this.addSignForm);
    }
    
}
isFieldValid(field: string) {
  return (
    !this.addSignForm.get(field).valid && this.addSignForm.get(field).touched
  );
}

displayFieldCss(field: string) {
  return {
    "has-error": this.isFieldValid(field),
    "has-feedback": this.isFieldValid(field),
  };
}

  initialize(): void {
    this.signForm.show();
  }
}
