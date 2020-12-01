import { Component, OnInit, ViewChild } from '@angular/core';
import { HomeComponent } from '../home/home.component';
import { Issue } from '../shared/issue.model';
import { User } from '../shared/user.model';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})
export class SidebarComponent implements OnInit {
  constructor(private home:HomeComponent) {
   }
  opened = false;
  open=true;
  issue:Issue;
  ngOnInit(): void {
    const side=new SidebarComponent(this.home);
    this.issue=side.home.activeIssue;
  }
  exit(){
    this.open=false;
  }
  
}
