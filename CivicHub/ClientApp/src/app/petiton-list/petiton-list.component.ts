import { Route } from '@angular/compiler/src/core';
import { ChangeDetectorRef, Component, OnInit, SimpleChanges } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Issue } from '../shared/issue.model';
import { User } from '../shared/user.model';
import { faUser, faCaretUp, faCaretDown, faStar } from '@fortawesome/free-solid-svg-icons';
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
    faStar=faStar;
    

  issues: Issue[] = [];
  constructor(private router: Router,private api:ApiService,private changeDetection: ChangeDetectorRef) { }
  
  userId = sessionStorage.getItem('userId');
  searchText: string = "";

  ngOnInit(): void {
    this.api.getIssues().subscribe((issues: Issue[]) => {
      this.issues=issues;
      this.issues.forEach(issue => {
        this.api.getIssueById(issue.id).subscribe((iss:Issue)=>{
          issue.numberOfSignatures=iss.numberOfSignatures;
        });
      });
      console.log(this.issues);
    });
      
   }
   
  accessPetition(issue:Issue){
    this.router.navigate(["petition-profile", issue.id]);
  }
  sortIssuesDescending() {
    console.log('sorting!'); // just to check if sorting is being called
     this.issues=this.issues.sort((a:Issue,b:Issue)=>b.numberOfSignatures-a.numberOfSignatures)
     console.log(this.issues);
     
  }
  sortIssuesAscending() {
    console.log('sorting!'); // just to check if sorting is being called
     this.issues=this.issues.sort((a:Issue,b:Issue)=>a.numberOfSignatures-b.numberOfSignatures)
     console.log(this.issues);
     
  }
  
}