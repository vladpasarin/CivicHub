import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import { ApiService } from '../shared/api.service';
import { User } from '../shared/user.model';

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.css']
})
export class UserProfileComponent implements OnInit {
    //firstName = this.route.snapshot.queryParamMap.get('id');
    constructor(private route: ActivatedRoute,private api:ApiService) { }
    userId: string;
    currentUser:User;
  ngOnInit(): void {
    this.route.params.subscribe((params: Params) => this.userId = params['id']);
    console.log(this.userId);
    this.api.getUserById(this.userId).subscribe((user: User) => {
      this.currentUser = user;
      console.log(this.currentUser);
});
  }

}
