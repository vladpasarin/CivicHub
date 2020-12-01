import { Component, OnInit, ViewChild } from "@angular/core";
import { Router } from "@angular/router";
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
  users:User[]=[
    {id:1,firstName:"Vlad",lastName:"Pasarin",password:"vlad98"},
    {id:2,firstName:"Florin",lastName:"Stan",password:"florinel99"},
    {id:3,firstName:"Eusebiu",lastName:"Timofte",password:"eusebi98"}
];
  issues: Issue[] = 
[
{id: 1,title:"Gropi pe Soseaua Oltenitei", latitude: 44.439663, longitude: 26.096306,description:"issue foarte rau", organizer:this.users[0],photoPath:"https://renasterea.ro/ro/wp-content/uploads/gropi_in_asfalt.jpg"},
{id: 2, title:"Lipsa cosuri de gunoi Piata Unirii", latitude: 44.430663, longitude: 26.095306,description:"issue de rezolvat de urgenta", organizer:this.users[1],photoPath:"https://www.tvlitoral.ro/wp-content/uploads/2016/07/cosuuri-gunoi.jpg"}, 
{id: 3, title:"Piata neconforma cu Covidul",latitude: 44.448663, longitude: 26.094306,description:"issue minor", organizer:this.users[2],photoPath:"https://opiniagiurgiu.ro/wp-content/uploads/2017/09/piata.png"} 
];
  constructor(private router: Router) {}
  toggleSidebar(issue:Issue){
    this.activeIssue=issue;
    this.opened = true;
    console.log(this.users[0])
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
  

  }

 
}
