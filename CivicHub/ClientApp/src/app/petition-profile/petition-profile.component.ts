import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { ApiService } from '../shared/api.service';
import { Issue } from '../shared/issue.model';
import { User } from '../shared/user.model';
import { PhotoModalComponent } from './photo-modal/photo-modal.component';
import { faUser, faArrowAltCircleUp, faArrowAltCircleDown, faThumbsUp } from '@fortawesome/free-solid-svg-icons';
import { SignFormComponent } from './sign-form/sign-form.component';
import { IssueState } from '../shared/issueState.model';
import { IssueComment } from '../shared/issueComment.model';
import { Signature } from '../shared/signature.model';
import { IssueCommentLike } from '../shared/issueCommentLike.model';
import { IssueReaction } from '../shared/issueReaction.model';
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
    commentText: string;
    stateComment = new IssueComment();
    currentState = new IssueState();
    userId = sessionStorage.getItem('userId');
    allComments: IssueComment[] = [];
    allSignatures:Signature[]=[];
    allCommentLikes: IssueCommentLike[] = [];
    commentLike = new IssueCommentLike();
    issueStateReactions: IssueReaction[] = [];
    issueReact = new IssueReaction();
    upvoteReacts: number;
    downvoteReacts: number;

    faUser = faUser;
    upvote = faArrowAltCircleUp;
    downvote = faArrowAltCircleDown;
    thumbsUp = faThumbsUp;

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
          
        this.api.getAllStatesByIssueId(this.issueId).subscribe((issueStates: IssueState[]) => {
            this.issueStates=issueStates;
            this.currentState=issueStates[0];
            console.log(this.currentState);

            this.api.getAllCommentsByStateId(this.currentState.id).subscribe((allcomm: IssueComment[]) => {
                this.allComments = allcomm;
                this.allComments.forEach(comment => {
                    console.log("Comment: " + comment.text);
                    this.api.getAllIssueStateCommentLikes(comment.Id).subscribe((allLikes: IssueCommentLike[]) => {
                        this.allCommentLikes = allLikes;
                        console.log(this.allCommentLikes);
                    });
                });
            });

            this.api.getNumberOfUpvotesByState(this.currentState.id).subscribe((nrOfUpvotes: number) => {
                this.upvoteReacts = nrOfUpvotes;
            });

            this.api.getNumberOfDownvotesByState(this.currentState.id).subscribe((nrOfDownvotes: number) => {
                this.downvoteReacts = nrOfDownvotes;
            });

            this.api.getAllSignaturesByStateId(this.currentState.id).subscribe((allSignatures:Signature[])=>{
                this.allSignatures= allSignatures;
                console.log(this.allSignatures);
            });
        });
    }

    selectState(issueState: IssueState) {
        this.currentState = issueState;
    }

    addUpvoteReaction() {
        this.issueReact.IssueStateId = this.currentState.id;
        this.issueReact.UserId = this.userId;
        this.issueReact.Vote = "upvote";
        this.issueReact.dateGiven = new Date();
        console.log(this.issueReact);
        this.api.addIssueReaction(this.issueReact).subscribe(() => {
        });
    }

    addDownvoteReaction() {
        this.issueReact.IssueStateId = this.currentState.id;
        this.issueReact.UserId = this.userId;
        this.issueReact.Vote = "downvote";
        this.issueReact.dateGiven = new Date();
        console.log(this.issueReact);
        this.api.addIssueReaction(this.issueReact).subscribe(() => {
        });
    }

    addComment() {
        this.stateComment.IssueStateId = this.currentState.id;
        this.stateComment.UserId = this.userId;
        this.stateComment.text = this.commentText;
        this.stateComment.dateCreated = new Date();
        this.api.addComment(this.stateComment).subscribe(() => {
            this.commentText='';
            this.api.getAllCommentsByStateId(this.currentState.id).subscribe((allcomm: IssueComment[]) => {
                this.allComments = allcomm;
                this.allComments.forEach(comment => {
                    console.log("Comment: " + comment.text);
                    this.api.getAllIssueStateCommentLikes(comment.Id).subscribe((allLikes: IssueCommentLike[]) => {
                        this.allCommentLikes = allLikes;
                        console.log(this.allCommentLikes);
                    });
                });
            });
        });
    }

    addCommentLike(stateComment: IssueComment) {
        this.commentLike.IssueStateCommentId = this.stateComment.Id;
        this.commentLike.UserId = this.userId;
        console.log("AddCommentLike function executed...")
    }

    getAllComments() {
        this.api.getAllCommentsByStateId(this.currentState.id).subscribe((allcomm: IssueComment[]) => {
            this.allComments = allcomm;
        });
    }

    getUpvotes() {
        this.api.getNumberOfUpvotesByState(this.currentState.id).subscribe((nrOfUpvotes: number) => {
            this.upvoteReacts = nrOfUpvotes;
            console.log("Upvotes:" + this.upvoteReacts);
        });
    }

    getDownvotes() {
        this.api.getNumberOfDownvotesByState(this.currentState.id).subscribe((nrOfDownvotes: number) => {
            this.downvoteReacts = nrOfDownvotes;
            console.log("Downvotes" + this.downvoteReacts);
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
