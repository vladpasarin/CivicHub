import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Issue } from '../shared/issue.model';
import { User } from '../shared/user.model';
import { PhotoModalComponent } from './photo-modal/photo-modal.component';

@Component({
    selector: 'petition-profile',
    templateUrl: './petition-profile.component.html',
    styleUrls: ['./petition-profile.component.css']
})
export class PetitionProfileComponent implements OnInit {

    constructor(private route: ActivatedRoute, private router: Router) { }

    @ViewChild("photoModal") photoModal: PhotoModalComponent;
    issueId = parseInt(this.route.snapshot.queryParamMap.get('id'));
    selectedIssue: Issue;

    users: User[] = [
        { id: 1, firstName: "Vlad", lastName: "Pasarin", mail: "vlad@gmail.com", password: "vlad1998" },
        { id: 2, firstName: "Florin", lastName: "Stan", mail: "florin@yahoo.com", password: "florinel99" },
        { id: 3, firstName: "Eusebiu", lastName: "Timofte", mail: "sebi@yahoo.com", password: "eusebi98" }
    ];

    issues: Issue[] =
        [
            { id: 1, title: "Gropi pe Soseaua Oltenitei", latitude: 44.439663, longitude: 26.096306, description: "What is Lorem Ipsum?Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", organizer: this.users[0], photoPath: "https://renasterea.ro/ro/wp-content/uploads/gropi_in_asfalt.jpg" },
            { id: 2, title: "Lipsa cosuri de gunoi Piata Unirii", latitude: 44.430663, longitude: 26.095306, description: "issue de rezolvat de urgenta", organizer: this.users[1], photoPath: "https://www.tvlitoral.ro/wp-content/uploads/2016/07/cosuuri-gunoi.jpg" },
            { id: 3, title: "Piata neconforma cu Covidul", latitude: 44.448663, longitude: 26.094306, description: "issue minor", organizer: this.users[2], photoPath: "https://opiniagiurgiu.ro/wp-content/uploads/2017/09/piata.png" }
        ];

    ngOnInit(): void {
        //aici va fi getIssue(id)
        this.selectedIssue = this.issues.find(
            (x) =>
                x.id === this.issueId
        );
        console.log(this.selectedIssue);

    }

    openProfile() {
        this.router.navigate(["/user-profile"],
            { queryParams: { firstName: this.selectedIssue.organizer.firstName } });
    }

    showDM(photoPath): void {
        this.photoModal.initialize(photoPath);
    }
}
