import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { ApiService } from '../shared/api.service';
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

ngOnInit(): void {
  this.selectedOption = 'Organized';

  this.route.params.subscribe((params: Params) => this.userId = params['id']);
  console.log(this.userId);

  this.api.getUserById(this.userId).subscribe((user: User) => {
    this.currentUser = user;
    console.log(this.currentUser);
    if(this.currentUser.points<10){
      this.currentUser.badgeType="Star_badge.png";
    }
    if(this.currentUser.points>10){
      this.currentUser.badgeType="badge1.png";
    }
    if(this.currentUser.points>30){
      this.currentUser.badgeType="badge2.png";
    }
    if(this.currentUser.points>80){
      this.currentUser.badgeType="badge3.png";
    }
    if(this.currentUser.points>150){
      this.currentUser.badgeType="badge4.png";
    }
    if(this.currentUser.points>500){
      this.currentUser.badgeType="badge5.png";
    }
    
});
}

changeOption(option){
  this.selectedOption=option;
}
toIssue(issueId:string){
  this.router.navigate(["petition-profile", issueId]);
}
}
