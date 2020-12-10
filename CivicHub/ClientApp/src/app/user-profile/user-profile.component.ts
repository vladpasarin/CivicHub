import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.css']
})
export class UserProfileComponent implements OnInit {
    firstName = this.route.snapshot.queryParamMap.get('firstName');
    constructor(private route: ActivatedRoute) { }

  ngOnInit(): void {
  }

}
