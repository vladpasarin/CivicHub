import { PrenormalizedTemplateMetadata } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { faCircle, faLevelUpAlt, faUser } from '@fortawesome/free-solid-svg-icons';
import { ApiService } from '../shared/api.service';
import { Follow } from '../shared/follow.model';
import { Issue } from '../shared/issue.model';
import { Prize } from '../shared/prize.model';
import { PrizeGiven } from '../shared/prizeGiven.model';
import { Signature } from '../shared/signature.model';
import { User } from '../shared/user.model';


@Component({
  selector: 'profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {
  faUser = faUser;
  levelUp = faLevelUpAlt;
  faCircle = faCircle;

  constructor(private route: ActivatedRoute,private api:ApiService, private router:Router) {
    route.params.subscribe(val => {
      this.selectedOption = 'Organized';

    this.route.params.subscribe((params: Params) => this.userId = params['id']);
    console.log(this.userId);

    this.api.getFollowsByUserId(this.userId).subscribe((fav:Follow[])=>{
      this.follows=fav;
      this.follows.forEach(follow => {
        this.api.getIssueById(follow.issueId).subscribe((issue:Issue)=>{
          follow.title=issue.title;
        });
      });
    });
    // this.api.getAllSignaturesByUser(this.userId).subscribe((signatures:Signature[])=>{
    //   this.signatures=signatures;
    //   console.log(this.signatures);
    // });
    this.api.getUserById(this.userId).subscribe((user: User) => {
      this.currentUser = user;
      console.log(this.currentUser);
      this.api.getBagdeNumber(user.id).subscribe((badgeNr:number)=>{
        this.badgeNumber=badgeNr;
        if(this.badgeNumber==1){
          this.currentUser.badgeType="Star_badge.png";
        }
        if(this.badgeNumber==2){
          this.currentUser.badgeType="badge1.png";
        }
        if(this.badgeNumber==3){
          this.currentUser.badgeType="badge2.png";
        }
        if(this.badgeNumber==4){
          this.currentUser.badgeType="badge3.png";
        }
        if(this.badgeNumber==5){
          this.currentUser.badgeType="badge4.png";
        }
        if(this.badgeNumber==6){
          this.currentUser.badgeType="badge5.png";
        }
        if(this.badgeNumber==7){
          this.currentUser.badgeType="badge6.png";
        }
        if(this.badgeNumber==8){
          this.currentUser.badgeType="badge7.png";
        }
        if(this.badgeNumber==9){
          this.currentUser.badgeType="badge8.png";
        }
        this.checkNextRankPoints();
      });

      this.getUserPrizes();
    });

    });

   }
  signatures:Signature[]=[];
  userId: string;
  currentUser:User;
  options = ['Followed', 'Signed', 'Organized','Prizes'];
  selectedOption:string;
  badgeNumber:number;
  availablePrizes: Prize[] = [];
  userPrizes: Prize[] = [];
  prizesGiven: PrizeGiven[] = [];
  punctaje=[10,50,150,300,450,650,900,1200];
  punctajNextRank:number;
  redeemedPrize =  new PrizeGiven();
  follows:Follow[]=[];
  loggedUserId = sessionStorage.getItem('userId');


  ngOnInit(): void {
    
}

checkNextRankPoints(){
  var keepGoing = true;
  this.punctaje.forEach(punctaj => {
        if(keepGoing){
          if(this.currentUser.points<punctaj){
            this.punctajNextRank=punctaj;
            keepGoing=false;
          }
        }
  });
}

deleteFollow(issueId:string){
  this.api.deleteFollow(this.userId, issueId).subscribe(() => {
    this.api.getFollowsByUserId(this.userId).subscribe((fav:Follow[])=>{
      this.follows=fav;
      console.log(this.follows);
      this.follows.forEach(follow => {
        this.api.getIssueById(follow.issueId).subscribe((issue:Issue)=>{
          follow.title=issue.title;
        });
      });
    });
  });
}

changeOption(option){
  this.selectedOption=option;
}

toIssue(issueId:string){
  this.router.navigate(["petition-profile", issueId]);
}

getUserPrizes() {
  this.api.getAllPrizes().subscribe((prizes: Prize[]) => {
    this.availablePrizes = prizes;
    console.log(prizes);
    this.api.getPrizeGivenByUser(this.loggedUserId).subscribe((prize: PrizeGiven[]) => {
      this.prizesGiven = prize;
      console.log(prize);
      this.userPrizes=[];
      this.prizesGiven.forEach(prizeGiven => {
        this.api.getPrizebyPrizeGiven(prizeGiven.prizeId).subscribe((prize: Prize) => {
          this.userPrizes.push(prize);
          this.availablePrizes.forEach((availablePrize, index)=>{
            if(availablePrize.id==prize.id){
              this.availablePrizes.splice(index,1);
            }
          });
        });
      });
    });
  });  
}

redeemPrize(prize: Prize) {
  console.log(prize);
  this.redeemedPrize.prizeId = prize.id;
  this.redeemedPrize.userId = this.loggedUserId;
  this.api.redeemPrize(this.redeemedPrize).subscribe(() => {
    console.log("Successfuly added!")
    this.getUserPrizes();
  });
}

activateClass(option) {
  option.active = !option.active;
}
}


