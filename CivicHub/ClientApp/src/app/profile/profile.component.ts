import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {

    firstName = this.route.snapshot.queryParamMap.get('firstName');

    constructor(private route: ActivatedRoute) { }

  ngOnInit(): void {
  }

}
