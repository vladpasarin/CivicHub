import { Component, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { HomeComponent } from '../home/home.component';
import { ApiService } from '../shared/api.service';
import { Follow } from '../shared/follow.model';
import { Issue } from '../shared/issue.model';
import { User } from '../shared/user.model';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})
export class SidebarComponent implements OnInit {
  constructor(private home:HomeComponent, private api?:ApiService, private router?:Router) {
  }
  isFollow: boolean = false;
  opened = false;
  open=true;
  issue:Issue;
  organizer=new User();
  userId = sessionStorage.getItem('userId');
  activeFollow:Follow;
  follow=new Follow();


  ngOnInit(): void {
    const side=new SidebarComponent(this.home);
    this.issue=side.home.activeIssue;
    console.log(this.issue.id);
    this.api.getUserById(this.issue.userId).subscribe((user: User) => {
      this.organizer = user;
    });
    this.api.getFollowByUserIdAndIssueId(this.userId,this.issue.id).subscribe((fav:Follow)=>{
      this.activeFollow=fav;
      console.log(this.activeFollow);
    });
  }
  addToFavourites(){
    if(this.activeFollow == null){
      this.follow.issueId=this.issue.id;
      this.follow.userId=this.userId;
      this.api.addFollow(this.follow).subscribe(()=>{
        this.api.getFollowByUserIdAndIssueId(this.userId,this.issue.id).subscribe((fav:Follow)=>{
          this.activeFollow=fav;
          console.log(this.activeFollow);
        });
      });
    }
    else{
      this.api.deleteFollow(this.userId,this.issue.id).subscribe(() => {
        this.activeFollow=null;
      });
    }
  }
    changeStyle() {
        this.isFollow = !this.isFollow;

    }
  exit(){
    this.open=false;
  }
  toProfile(userId:string) {
    this.router.navigate(["profile", userId]);
  }
  toPetition(issueId:string){
  this.router.navigate(["petition-profile", issueId]);
  }
}
