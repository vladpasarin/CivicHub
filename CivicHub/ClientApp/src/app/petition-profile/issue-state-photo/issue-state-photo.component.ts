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
  photoByte: string;
  urls: any[];

  @Input() currentState: IssueState;

  constructor(private petitionProfile: PetitionProfileComponent,
    private api?: ApiService
  ) { }

  @ViewChild("issueStatePhoto") issueStatePhoto: ModalDirective;

  ngOnInit(): void {
  }

  initialize(): void {
    this.issueStatePhoto.show();
  }

  onSelectFile(event) {
    if (event.target.files && event.target.files[0]) {
        var filesAmount = event.target.files.length;
        for (let i = 0; i < filesAmount; i++) {
                var reader = new FileReader();

                reader.onload = (event:any) => {
                  // this.photoByte = event.target.result.replace('data:image/png;base64,','');
                  this.photoByte=event.target.result;
                   this.urls.push(this.photoByte);
                   
                }

                reader.readAsDataURL(event.target.files[i]);

         }
    }
  }
}
