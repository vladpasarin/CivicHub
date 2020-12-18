import { Component, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { HomeComponent } from '../home/home.component';
import { ApiService } from '../shared/api.service';
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

  ngOnInit(): void {
    const side=new SidebarComponent(this.home);
    this.issue=side.home.activeIssue;
    console.log(this.issue.id);
    this.api.getUserById(this.issue.userId).subscribe((user: User) => {
      this.organizer = user;
});
  }
    onClick() {
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
