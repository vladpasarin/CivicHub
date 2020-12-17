import { Component, OnInit, ViewChild } from "@angular/core";
import { Router } from "@angular/router";
import { ApiService } from '../shared/api.service';
import { Issue } from '../shared/issue.model';
import { User } from '../shared/user.model';
import { SidebarComponent } from '../sidebar/sidebar.component';

@Component({
  selector: "app-home",
  templateUrl: "./home.component.html",
  styleUrls: ["./home.component.css"],
})
export class HomeComponent implements OnInit{
  @ViewChild("sidebar") sidebar: SidebarComponent;
  lat = 44.439663;
  lng = 26.096306;
  zoom = 13.0;
  opened = false;
  activeIssue:Issue;
    
  issues: Issue[] = [];
  constructor(private router: Router,private api:ApiService) {}
  toggleSidebar(issue:Issue){
    this.activeIssue=issue;
    this.opened = true;
  }
  refresh(){
    if(this.opened == true){
      this.opened = false;
      setTimeout(() => {
        this.opened = true;
    }, 300);
    }
  }
  closeSidebar(){
    this.opened = false;
  }
  ngOnInit() {
    this.api.getIssues().subscribe((issues: Issue[]) => {
      this.issues=issues;
    });
    setTimeout(() => {
      console.log(this.issues)
  }, 1000);
  }

 
}
