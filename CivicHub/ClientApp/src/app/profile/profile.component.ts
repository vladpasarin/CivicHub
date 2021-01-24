import { PrenormalizedTemplateMetadata } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { ApiService } from '../shared/api.service';
import { Prize } from '../shared/prize.model';
import { PrizeGiven } from '../shared/prizeGiven.model';
import { User } from '../shared/user.model';

@Component({
  selector: 'profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {

  constructor(private route: ActivatedRoute,private api:ApiService, private router:Router) { }
  userId: string;
  currentUser:User;
  options = ['Followed', 'Signed', 'Organized','Prizes'];
  selectedOption:string;
  badgeNumber:number;
  availablePrizes: Prize[] = [];
  userPrizes: Prize[] = [];
  prizeGiven: PrizeGiven;

  ngOnInit(): void {
    this.selectedOption = 'Organized';

    this.route.params.subscribe((params: Params) => this.userId = params['id']);
    console.log(this.userId);

    this.api.getUserById(this.userId).subscribe((user: User) => {
      this.currentUser = user;
      console.log(this.currentUser);
      this.api.getBagdeNumber(user.id).subscribe((badgeNr:number)=>{
        this.badgeNumber=badgeNr;
        console.log(this.badgeNumber);
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
      });

      this.api.getAllPrizes().subscribe((prizes: Prize[]) => {
        this.availablePrizes = prizes;
        console.log(prizes);
      });

      this.api.getPrizesByUser(this.currentUser.id).subscribe((prizes: Prize[]) => {
        this.userPrizes = prizes;
        console.log("Al user-ului: " + prizes);
      });
  });
}

changeOption(option){
  this.selectedOption=option;
}

toIssue(issueId:string){
  this.router.navigate(["petition-profile", issueId]);
}
}


