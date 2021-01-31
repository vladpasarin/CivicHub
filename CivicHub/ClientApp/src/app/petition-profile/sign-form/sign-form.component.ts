import { HttpErrorResponse } from '@angular/common/http';
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

  success: boolean;
  signature= new Signature();
  currentDate=new Date();
  userId = sessionStorage.getItem('userId');
  errorAdd:boolean;
  successAdd="";

  @Input() currentState:IssueState;

  constructor( private petitonProfile:PetitionProfileComponent,private fb?:FormBuilder, private api?:ApiService) { }

  @ViewChild("signForm") signForm: ModalDirective;

  ngOnInit() {
    
  }

  addSign() {
       
        this.signature.dateSigned=this.currentDate;
        this.signature.issueStateId=this.currentState.id;
        this.signature.userId=this.userId;
        this.api.addSignature(this.signature).subscribe(()=>{
          console.log(this.signature);
          this.successAdd="Perfect! You gained 4 points.";
          this.api.getAllSignaturesByStateId(this.currentState.id).subscribe((allSignatures:Signature[])=>{
            this.petitonProfile.allSignatures=allSignatures;
            setTimeout(() => {
              this.successAdd = "";
              this.signForm.hide();
          }, 4000);
          });

        },
          (error: HttpErrorResponse) => {
            console.log('err', error.message);
            this.errorAdd = true;
            setTimeout(() => {
                this.errorAdd = null;
            }, 2000);
          });
    
}

  initialize(): void {
    this.signForm.show();
  }
}
