import { Component, Input, OnInit, Output, ViewChild } from '@angular/core';
import { EventEmitter } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { ApiService } from 'src/app/shared/api.service';
import { IssuePhoto } from 'src/app/shared/issuePhoto.model';
import { IssueState } from 'src/app/shared/issueState.model';
import { ResponseGiven } from 'src/app/shared/responseGiven.model';
import { SignatureSubmitted } from 'src/app/shared/signatureSubmitted.model';
import { PetitionProfileComponent } from '../petition-profile.component';

@Component({
  selector: 'app-issue-state-photo',
  templateUrl: './issue-state-photo.component.html',
  styleUrls: ['./issue-state-photo.component.css']
})

export class IssueStatePhotoComponent implements OnInit {
  userId = sessionStorage.getItem('userId');
  photoByte: string;
  urls = [];
  issuePhoto = new IssuePhoto();
  signatureSubmitted = new SignatureSubmitted();
  responseGiven = new ResponseGiven();
  responseImplemented = new ResponseGiven();
  authorityResponse: string; 
  implementedResponse: string;
  @Input() currentState: IssueState;
  @Output("refreshIssuePhotos") refreshIssuePhotos = new EventEmitter<string>(); 

  constructor(private petitionProfile: PetitionProfileComponent,
    private api?: ApiService
  ) { }

  @ViewChild("issueStatePhoto") issueStatePhoto: ModalDirective;

  ngOnInit(): void {
  }

  initialize(): void {
    this.issueStatePhoto.show();
  }

  exit(): void {
    this.issueStatePhoto.hide();
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

  addIssueSubmition() {
    console.log(this.currentState);
    this.signatureSubmitted.issueId=this.currentState.issueId;
    this.signatureSubmitted.photos=this.urls;
    console.log(this.signatureSubmitted);
    this.api.addSignatureSubmitted(this.signatureSubmitted).subscribe(()=>{
      this.petitionProfile.getStates();
      //this.addIssueStatePhoto();
      this.petitionProfile.getPhotos();
    });
    this.exit();
    this.urls=[];
  }

  addIssueStatePhoto() {
    this.issuePhoto.issueStateId = this.currentState.id;
    this.issuePhoto.dateAdded = new Date();
    this.urls.forEach(url => {
      this.issuePhoto.photo = url;
      this.api.addIssueStatePhoto(this.issuePhoto).subscribe(() => {
        this.petitionProfile.getPhotos();
      });
    });
    this.exit();
    this.urls=[];
    // this.refreshPhotos.emit("Success");
  }

  addIssueResponse() {
    this.responseGiven.issueId = this.currentState.issueId;
    this.responseGiven.photos = this.urls;
    this.responseGiven.messageFromAuthorities = this.authorityResponse;
    console.log(this.responseGiven);
    this.api.addIssueResponse(this.responseGiven).subscribe(() => {
      this.petitionProfile.getStates();
      //this.addIssueStatePhoto();
      this.petitionProfile.getPhotos();
    });
    this.exit();
    this.urls=[];
  }

  addImplementedResponse(){
    this.responseImplemented.issueId = this.currentState.issueId;
    this.responseImplemented.photos = this.urls;
    //this.responseImplemented.messageFromAuthorities = this.implementedResponse;
    console.log(this.responseImplemented);
    this.api.addImplementedResponse(this.responseImplemented).subscribe(() => {
      this.petitionProfile.getStates();
      //this.addIssueStatePhoto();
      this.petitionProfile.getPhotos();
    });
    this.exit();
    this.urls=[];
  }

  addNextState() {
    if (this.currentState.type == 1) {
      this.addIssueSubmition();
    }
    if (this.currentState.type == 2) {
      this.addIssueResponse();
    }
    if (this.currentState.type == 3) {
      this.addImplementedResponse();
    }
  }
}