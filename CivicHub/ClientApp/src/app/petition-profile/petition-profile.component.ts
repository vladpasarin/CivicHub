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
import { Follow } from '../shared/follow.model';
import { IssuePhoto } from '../shared/issuePhoto.model';
@Component({
    selector: 'petition-profile',
    templateUrl: './petition-profile.component.html',
    styleUrls: ['./petition-profile.component.css']
})
export class PetitionProfileComponent implements OnInit {

    constructor(private route: ActivatedRoute, private router: Router,private api:ApiService) { }

    @ViewChild("photoModal") photoModal: PhotoModalComponent;
    @ViewChild("signForm") signForm: SignFormComponent;

    isFollow: boolean = false;
    issueId:string;
    selectedIssue: Issue;
    commentText: string;
    stateComment = new IssueComment();
    currentState = new IssueState();
    userId = sessionStorage.getItem('userId');
    allComments: IssueComment[] = [];
    allSignatures:Signature[]=[];
    commentLike = new IssueCommentLike();
    issueStateReactions: IssueReaction[] = [];
    issueReact = new IssueReaction();
    upvoteReacts: number;
    downvoteReacts: number;
    userIdInvalid:boolean;
    invalidComment:boolean;
    currentUser=new User();
    checkIfUserLiked: boolean;
    show = false;
    showNumber = 3;
    errorAdd: boolean;
    successAdd;
    voteSuccess;
    photos=["https://i0.1616.ro/media/2/2701/33631/16664900/1/whatsapp-image-2017-02-23-at-09-38-33.jpg",
            "https://autoblog.md/media/2018/03/gropi-bd-Dacia_0.jpg",
            "https://playtech.ro/wp-content/uploads/2018/02/gropi-bucure%C8%99ti-rom%C3%A2nia-1170x658.jpg",
            "https://neurococi.ro/assets/images/posts/amp/gropstop.jpg",
            "https://www.banatulazi.ro/wp-content/uploads/2017/09/drum-gropi3.jpg"]

    faUser = faUser;
    upvote = faArrowAltCircleUp;
    downvote = faArrowAltCircleDown;
    thumbsUp = faThumbsUp;

    organizer=new User();
    issueStates:IssueState[]=[];
    issueTypes=["Petiton pending","Petition waiting"];
    activeFollow:Follow;
    follow=new Follow();
    activeReaction: IssueReaction;
    issueStatePhotos:IssuePhoto[]=[];

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
            this.currentState=issueStates[this.issueStates.length - 1];

            this.api.getAllCommentsByStateId(this.currentState.id).subscribe((allcomm: IssueComment[]) => {
                this.allComments = allcomm;
                this.allComments.forEach(comment => {
                    console.log(comment.id);
                    //console.log("CommentId: " + comment.Id);
                    this.api.getAllIssueStateCommentLikes(comment.id).subscribe((allLikes: IssueCommentLike[]) => {
                        comment.nrOfLikes = allLikes.length;
                        console.log(allLikes.length);
                    });
                    this.api.getUserById(comment.userId).subscribe((user: User) => {
                        comment.userName = user.firstName;
                        console.log(comment.userName);
                    });
                });
            });
            
            this.getUserReaction(this.currentState.id, this.userId);

            this.api.getNumberOfUpvotesByState(this.currentState.id).subscribe((nrOfUpvotes: number) => {
                this.upvoteReacts = nrOfUpvotes;
            });

            this.api.getNumberOfDownvotesByState(this.currentState.id).subscribe((nrOfDownvotes: number) => {
                this.downvoteReacts = nrOfDownvotes;
            });

            this.api.getAllSignaturesByStateId(this.currentState.id).subscribe((allSignatures:Signature[])=>{
                this.allSignatures= allSignatures;
            });
            this.api.getFollowByUserIdAndIssueId(this.userId,this.issueId).subscribe((fav:Follow)=>{
                this.activeFollow=fav;
                console.log(this.activeFollow);
              });
            this.api.getIssueStatePhotos(this.currentState.id).subscribe((photos:IssuePhoto[])=>{
                this.issueStatePhotos=photos;
                console.log(this.issueStatePhotos)
            });
        });
    }

    addToFavourites(){
        if(this.activeFollow == null){
          this.follow.issueId=this.issueId
          this.follow.userId=this.userId;
          this.api.addFollow(this.follow).subscribe(()=>{
            this.api.getFollowByUserIdAndIssueId(this.userId,this.issueId).subscribe((fav:Follow)=>{
              this.activeFollow=fav;
              console.log(this.activeFollow);
            });
          });
        }
        else{
            this.api.deleteFollow(this.userId,this.issueId).subscribe(() => {
                this.activeFollow=null;
              });
        }
      }
        changeStyle() {
            this.isFollow = !this.isFollow;
    
        }

    selectState(issueState: IssueState) {
        this.currentState = issueState;
        console.log(this.currentState);
        this.api.getIssueStatePhotos(this.currentState.id).subscribe((photos:IssuePhoto[])=>{
            this.issueStatePhotos=photos;
            console.log(this.issueStatePhotos)
        });
        this.api.getAllSignaturesByStateId(this.currentState.id).subscribe((allSignatures:Signature[])=>{
            this.allSignatures= allSignatures;
            this.api.getAllCommentsByStateId(this.currentState.id).subscribe((allcomm: IssueComment[]) => {
                this.allComments = allcomm;
                this.allComments.forEach(comment => {
                    console.log(comment.id);
                    //console.log("CommentId: " + comment.Id);
                    this.api.getAllIssueStateCommentLikes(comment.id).subscribe((allLikes: IssueCommentLike[]) => {
                        comment.nrOfLikes = allLikes.length;
                        console.log(allLikes.length);
                    });
                    this.api.getUserById(comment.userId).subscribe((user: User) => {
                        comment.userName = user.firstName;
                        console.log(comment.userName);
                    });
                });
            });
        });
    }

    addUpvoteReaction() {
        if (this.activeReaction != null) {
            if (this.activeReaction.vote == "upvote") {
                this.api.deleteUserReaction(this.activeReaction.id).subscribe(() => {
                    this.activeReaction = null;
                    this.getUpvotes();
                    this.getDownvotes();
                });
                return;
            }
            this.api.deleteUserReaction(this.activeReaction.id).subscribe(() => {
                this.activeReaction = null;
                this.getUpvotes();
                this.getDownvotes();
            });
        }
        this.issueReact.issueStateId = this.currentState.id;
        this.issueReact.userId = this.userId;
        this.issueReact.vote = "upvote";
        this.issueReact.dateGiven = new Date();
        console.log(this.issueReact);
        this.activeReaction=this.issueReact;
        this.api.addIssueReaction(this.issueReact).subscribe(() => {
            this.getUpvotes();
            this.getUserReaction(this.currentState.id, this.userId);
            this.voteSuccess="The organizer thanks you! You gained 2 points";
            setTimeout(() => {
                this.voteSuccess="";
            }, 3000);
        });
    }

    addDownvoteReaction() {
        if (this.activeReaction != null) {
            if (this.activeReaction.vote == "downvote") {
                this.api.deleteUserReaction(this.activeReaction.id).subscribe(() => {
                    this.activeReaction = null;
                    this.getUpvotes();
                    this.getDownvotes();
                }); 
                return;
            }
            this.api.deleteUserReaction(this.activeReaction.id).subscribe(() => {
                this.activeReaction = null;
                this.getUpvotes();
                this.getDownvotes();
            });
        }
        this.issueReact.issueStateId = this.currentState.id;
        this.issueReact.userId = this.userId;
        this.issueReact.vote = "downvote";
        this.issueReact.dateGiven = new Date();
        this.activeReaction=this.issueReact;
        this.api.addIssueReaction(this.issueReact).subscribe(() => {
            this.getDownvotes();
            this.getUserReaction(this.currentState.id, this.userId);
            this.voteSuccess="Thanks for your reaction! You gained 2 points";
            setTimeout(() => {
                this.voteSuccess="";
            }, 3000);
        });
    }

    /*addUpvoteReaction() {
        console.log(this.activeReaction);
        if (this.activeReaction == null) {
            this.issueReact.issueStateId = this.currentState.id;
            this.issueReact.userId = this.userId;
            this.issueReact.vote = "upvote";
            this.issueReact.dateGiven = new Date();
            console.log(this.issueReact);
            this.activeReaction=this.issueReact;
            this.api.addIssueReaction(this.issueReact).subscribe(() => {
                this.getUpvotes();
                this.getUserReaction(this.currentState.id, this.userId);
                this.voteSuccess="The organizer thanks you! You gained 2 points";
                setTimeout(() => {
                    this.voteSuccess="";
                }, 3000);
            });
        } 
        else {
            if(this.activeReaction.vote="upvote"){
                this.api.deleteUserReaction(this.activeReaction.id).subscribe(() => {
                    this.activeReaction = null;
                    this.getUpvotes();
                    this.getDownvotes();
    
    
                });
            }
        }
    }

    addDownvoteReaction() {
        console.log(this.activeReaction);
        if (this.activeReaction == null) {
            this.issueReact.issueStateId = this.currentState.id;
            this.issueReact.userId = this.userId;
            this.issueReact.vote = "downvote";
            this.issueReact.dateGiven = new Date();
            this.activeReaction=this.issueReact;
            this.api.addIssueReaction(this.issueReact).subscribe(() => {
                this.getDownvotes();
                this.getUserReaction(this.currentState.id, this.userId);
                this.voteSuccess="Thanks for your reaction! You gained 2 points";
                setTimeout(() => {
                    this.voteSuccess="";
                }, 3000);
            });
        }
        else {
            if(this.activeReaction.vote="downvote"){
                this.api.deleteUserReaction(this.activeReaction.id).subscribe(() => {
                    this.activeReaction = null;
                    this.getUpvotes();
                    this.getDownvotes();
                });
            }
        }
    }*/

    getUserReaction(stateId:string,userId: string) {
        this.api.getUserReactionToIssue(stateId, userId).subscribe((reaction:IssueReaction) => {
            this.activeReaction = reaction;
            console.log(this.activeReaction)
        });
    }

    addComment() {
        if(this.userId == null || this.commentText == null){
            this.invalidComment=true
            setTimeout(() => {
              this.invalidComment=false
          }, 3000);
          }
        
        else{
            this.stateComment.IssueStateId = this.currentState.id;
            this.stateComment.userId = this.userId;
            this.stateComment.text = this.commentText;
            this.stateComment.dateCreated = new Date();
            this.api.addComment(this.stateComment).subscribe(() => {
                this.commentText='';
                this.api.getAllCommentsByStateId(this.currentState.id).subscribe((allcomm: IssueComment[]) => {
                    this.allComments = allcomm;
                        this.successAdd="Fantastic! You gained 1 point";
                        setTimeout(() => {
                            this.successAdd="";
                        }, 3000);
                    this.allComments.forEach(comment => {
                        this.api.getAllIssueStateCommentLikes(comment.id).subscribe((allLikes: IssueCommentLike[]) => {
                            comment.nrOfLikes = allLikes.length;
                            console.log(allLikes.length);
                        });
                        this.api.getUserById(comment.userId).subscribe((user: User) => {
                            comment.userName = user.firstName;
                            console.log(comment.userName);
                        });
                    });
                });
            });
        }
    }

    addCommentLike(stateComment: IssueComment) {
        if(this.userId == null){
            this.errorAdd=true
            setTimeout(() => {
              this.errorAdd=false
          }, 2000);
        }
        this.commentLike.issueStateCommentId = stateComment.id;
        this.commentLike.userId = this.userId;
        this.api.addCommentLike(this.commentLike).subscribe(() => {
            this.api.getAllCommentsByStateId(this.currentState.id).subscribe((allcomm: IssueComment[]) => {
                this.allComments = allcomm;
                this.allComments.forEach(comment => {
                    this.api.getAllIssueStateCommentLikes(comment.id).subscribe((allLikes: IssueCommentLike[]) => {
                        comment.nrOfLikes = allLikes.length;
                        console.log(allLikes.length);
                    });

                    this.api.getUserById(comment.userId).subscribe((user: User) => {
                        comment.userName = user.firstName;
                        console.log(comment.userName);
                    });

                   /*this.api.checkIfUserLikedComment(this.userId, comment.id).subscribe((check: boolean) => {
                        if (check == true) {
                            
                        }
                    });*/
                });
            });
        });
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
        if(this.userId == null){
            this.userIdInvalid=true
            setTimeout(() => {
              this.userIdInvalid=false
          }, 2000);
          }
          else{
            this.signForm.initialize();
          }
    }

   
}
