import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ApiService } from '../shared/api.service';
import { User } from '../shared/user.model';
import { faAward, faBars, faUser, } from '@fortawesome/free-solid-svg-icons';

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
  users:User[]=[];

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
