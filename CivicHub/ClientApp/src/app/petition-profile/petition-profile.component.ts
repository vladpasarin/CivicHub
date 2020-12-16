import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ApiService } from '../shared/api.service';
import { Issue } from '../shared/issue.model';
import { User } from '../shared/user.model';
import { PhotoModalComponent } from './photo-modal/photo-modal.component';

@Component({
    selector: 'petition-profile',
    templateUrl: './petition-profile.component.html',
    styleUrls: ['./petition-profile.component.css']
})
export class PetitionProfileComponent implements OnInit {

    constructor(private route: ActivatedRoute, private router: Router,private api:ApiService) { }

    @ViewChild("photoModal") photoModal: PhotoModalComponent;
    issueId = this.route.snapshot.queryParamMap.get('id');
    selectedIssue: Issue;

    loaded:boolean;
    issues:Issue[]=[];

    ngOnInit(): void {
        this.api.getIssues().subscribe((issues: Issue[]) => {
            this.issues=issues;
          });

        
        this.api.getIssueById(this.issueId).subscribe((issues: Issue) => {
            this.selectedIssue=issues;
          });
          setTimeout(() => {
            console.log(this.selectedIssue);
        }, 1000);
        setTimeout(() => {
            this.loaded=true;
        }, 2000);
    }

    openProfile() {
        this.router.navigate(["/user-profile"],
            { queryParams: { firstName: this.selectedIssue.userId } });
    }

    showDM(photoPath): void {
        this.photoModal.initialize(photoPath);
    }
}
