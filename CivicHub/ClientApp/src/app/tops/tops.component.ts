import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ApiService } from '../shared/api.service';
import { User } from '../shared/user.model';
import { faAward, faBars, faUser, faStar } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-tops',
  templateUrl: './tops.component.html',
  styleUrls: ['./tops.component.css']
})
export class TopsComponent implements OnInit {

  constructor(private api:ApiService, private router: Router) { }
  faBars=faBars;
  faUser=faUser;
  faAward=faAward;
  faStar=faStar;
  users:User[]=[];
  show = false;
  selectedOption=10;
  options = [
    { name: "10", value: 10 },
    { name: "25", value: 25 }
  ]
  userId = sessionStorage.getItem('userId');

  ngOnInit() {
    this.api.getUsers().subscribe((data:User[])=>{
      this.users=data;
      this.users.sort((a,b)=>b.points-a.points)
      this.users.forEach((user, index)=>{
        user.index= index+1;
      })
    });
  }
  goToUserProfile(userId:string){
    this.router.navigate(["profile", userId]);
  }
  
}
