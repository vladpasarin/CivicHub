import { Component, OnInit, ViewChild } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';

@Component({
  selector: 'sign-form',
  templateUrl: './sign-form.component.html',
  styleUrls: ['./sign-form.component.css']
})
export class SignFormComponent implements OnInit {

  constructor() { }

  @ViewChild("signForm") signForm: ModalDirective;
  
  ngOnInit() {}

  initialize(): void {
    this.signForm.show();
  }
}
