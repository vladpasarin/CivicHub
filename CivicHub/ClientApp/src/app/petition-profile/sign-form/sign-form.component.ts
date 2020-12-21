import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { ApiService } from 'src/app/shared/api.service';
import { IssueState } from 'src/app/shared/issueState.model';
import { Signature } from 'src/app/shared/signature.model';
import { PetitionProfileComponent } from '../petition-profile.component';

@Component({
  selector: 'sign-form',
  templateUrl: './sign-form.component.html',
  styleUrls: ['./sign-form.component.css']
})
export class SignFormComponent implements OnInit {

  addSignForm: FormGroup;
  success: boolean;
  signature= new Signature();
  currentDate=new Date();
  userId = sessionStorage.getItem('userId');
  userIdInvalid:boolean;

  @Input() currentState:IssueState;

  constructor( private petitonProfile:PetitionProfileComponent,private fb?:FormBuilder, private api?:ApiService) { }

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
    setTimeout(() => {
      console.log(this.currentState);
  }, 1000);
    this.addSignForm = this.fb.group({
      name: [null, Validators.required],
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
        console.log(this.userId);
       
        this.signature.name=this.f.name.value;
        this.signature.cnp=this.f.cnp.value;
        this.signature.adresa=this.f.address.value;
        this.signature.serieBuletin=this.f.idSeries.value;
        this.signature.numarBuletin=this.f.idNumber.value;
        this.signature.dateSigned=this.currentDate;
        this.signature.issueStateId=this.currentState.id;
        this.signature.userId=this.userId;
        this.api.addSignature(this.signature).subscribe(()=>{
          console.log(this.signature);
          this.api.getAllSignaturesByStateId(this.currentState.id).subscribe((allSignatures:Signature[])=>{
            this.petitonProfile.allSignatures=allSignatures;
        });
        });

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
