import { Route } from '@angular/compiler/src/core';
import { Component, OnInit, SimpleChanges } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Issue } from '../shared/issue.model';
import { User } from '../shared/user.model';
import { faUser, faCaretUp, faCaretDown } from '@fortawesome/free-solid-svg-icons';
import { ApiService } from '../shared/api.service';

@Component({
  selector: 'petition-list',
  templateUrl: './petiton-list.component.html',
  styleUrls: ['./petiton-list.component.css']
})
export class PetitonListComponent implements OnInit {
    faUser = faUser;
    faCaretUp = faCaretUp;
    faCaretDown = faCaretDown;

    organizer=new User();
    

issues: Issue[] = [];
  constructor(private router: Router,private api:ApiService) { }
  searchText: string = "";

  ngOnInit(): void {
    this.api.getIssues().subscribe((issues: Issue[]) => {
      this.issues=issues;
    });
      
   }

  searchUserById(userId){
      this.api.getUserById(userId).subscribe((user: User) => {
          console.log("Executing function searchUserById...");
          this.organizer = user;
          return this.organizer.firstName;
    });
  }
  accessPetition(issue:Issue){
    this.router.navigate(["/petition-profile"],
        {queryParams:{id:issue.id}});
  }
}
