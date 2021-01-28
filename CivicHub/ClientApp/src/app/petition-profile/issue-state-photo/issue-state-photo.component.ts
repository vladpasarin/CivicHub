import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { ApiService } from 'src/app/shared/api.service';
import { IssueState } from 'src/app/shared/issueState.model';
import { PetitionProfileComponent } from '../petition-profile.component';

@Component({
  selector: 'app-issue-state-photo',
  templateUrl: './issue-state-photo.component.html',
  styleUrls: ['./issue-state-photo.component.css']
})

export class IssueStatePhotoComponent implements OnInit {
  userId = sessionStorage.getItem('userId');

  @Input() currentState: IssueState;

  constructor(private petitionProfile: PetitionProfileComponent,
    private api?: ApiService
  ) { }

  @ViewChild("statePhoto") statePhoto: ModalDirective;

  ngOnInit(): void {
  }

  initialize(): void {
    this.statePhoto.show();
  }

}
