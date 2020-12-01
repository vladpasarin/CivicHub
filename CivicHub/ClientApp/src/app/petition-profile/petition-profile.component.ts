import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'petition-profile',
  templateUrl: './petition-profile.component.html',
  styleUrls: ['./petition-profile.component.css']
})
export class PetitionProfileComponent implements OnInit {

  constructor(private route:ActivatedRoute) { }

  issueId=parseInt(this.route.snapshot.queryParamMap.get('id'));

  ngOnInit(): void {
    //aici va fi getIssue(id)
  }

}
