import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { ApiService } from '../shared/api.service';
import { Issue } from '../shared/issue.model';
import { User } from '../shared/user.model';
import { PhotoModalComponent } from './photo-modal/photo-modal.component';
import { faUser, faArrowAltCircleUp, faArrowAltCircleDown, faArrowUp, faArrowDown } from '@fortawesome/free-solid-svg-icons';
import { SignFormComponent } from './sign-form/sign-form.component';
import { IssueState } from '../shared/issueState.model';
@Component({
    selector: 'petition-profile',
    templateUrl: './petition-profile.component.html',
    styleUrls: ['./petition-profile.component.css']
})
export class PetitionProfileComponent implements OnInit {

    constructor(private route: ActivatedRoute, private router: Router,private api:ApiService) { }

    @ViewChild("photoModal") photoModal: PhotoModalComponent;
    @ViewChild("signForm") signForm: SignFormComponent;

    issueId:string;
    selectedIssue: Issue;
    commentText;
    currentStateId;

    faUser = faUser;
    upvote = faArrowAltCircleUp;
    downvote = faArrowAltCircleDown;
    arrowUp = faArrowUp;
    arrowDown = faArrowDown;

    organizer=new User();
    issueStates:IssueState[]=[];
    issueTypes=["Petiton pending","Petition waiting"];

    ngOnInit(): void {
        this.route.params.subscribe((params: Params) => this.issueId = params['id']);

        this.api.getIssueById(this.issueId).subscribe((issue: Issue) => {
            this.selectedIssue=issue;
            this.api.getUserById(issue.userId).subscribe((user: User) => {
                this.organizer = user;
          });
          });
          setTimeout(() => {
            console.log(this.selectedIssue);
        }, 1000);
        this.api.getAllStatesByIssueId(this.issueId).subscribe((issueStates: IssueState[]) => {
            this.issueStates=issueStates;
            console.log(this.issueStates);
      });
        
    }

    openProfile() {
        this.router.navigate(["profile", this.selectedIssue.userId]);
    }

    showDM(photoPath): void {
        this.photoModal.initialize(photoPath);
    }
    showSignForm() :void{
        this.signForm.initialize();
    }
   
}
