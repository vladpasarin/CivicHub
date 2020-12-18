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
  options = ['Followed', 'Signed', 'Organized','Achievements'];
  selectedOption:string;

ngOnInit(): void {
  this.selectedOption = 'Organized';

  this.route.params.subscribe((params: Params) => this.userId = params['id']);
  console.log(this.userId);

  this.api.getUserById(this.userId).subscribe((user: User) => {
    this.currentUser = user;
    console.log(this.currentUser);
});
}

changeOption(option){
  this.selectedOption=option;
}
toIssue(issueId:string){
  this.router.navigate(["petition-profile", issueId]);
}
}
