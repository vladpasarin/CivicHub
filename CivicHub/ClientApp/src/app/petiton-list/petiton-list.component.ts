import { Route } from '@angular/compiler/src/core';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Issue } from '../shared/issue.model';
import { User } from '../shared/user.model';

@Component({
  selector: 'petition-list',
  templateUrl: './petiton-list.component.html',
  styleUrls: ['./petiton-list.component.css']
})
export class PetitonListComponent implements OnInit {

    users: User[] = [
        { id: 1, firstName: "Vlad", lastName: "Pasarin", mail: "vlad@gmail.com", password: "vlad1998" },
        { id: 2, firstName: "Florin", lastName: "Stan", mail: "florin@yahoo.com", password: "florinel99" },
        { id: 3, firstName: "Eusebiu", lastName: "Timofte", mail: "sebi@yahoo.com", password: "eusebi98" }
    ];
issues: Issue[] = 
[
{id: 1,title:"Gropi pe Soseaua Oltenitei", latitude: 44.439663, longitude: 26.096306,description:"issue foarte rau", organizer:this.users[0],photoPath:"https://lh3.googleusercontent.com/proxy/wmG9QJyX2j3aFI08xVreuFmhG517CubIM1t_NOdQoanlLuyQKIaf8Wkad6xndBE8vJQ38IQjFs5boMJLyFzJcNT7nk3Ywp9KFW5LYW8TAPh0pengwd_JWzq9R3pDnV7K-E3tK_Y"},
{id: 2, title:"Lipsa cosuri de gunoi Piata Unirii", latitude: 44.430663, longitude: 26.095306,description:"issue de rezolvat de urgenta", organizer:this.users[1],photoPath:"https://www.tvlitoral.ro/wp-content/uploads/2016/07/cosuuri-gunoi.jpg"}, 
{id: 3, title:"Piata neconforma cu Covidul",latitude: 44.448663, longitude: 26.094306,description:"issue minor", organizer:this.users[2],photoPath:"https://opiniagiurgiu.ro/wp-content/uploads/2017/09/piata.png"} 
];
  constructor(private router: Router) { }
  searchText: string = "";

  ngOnInit(): void {
    
  }
  accessPetition(issue:Issue){
    this.router.navigate(["/petition-profile"],
        {queryParams:{id:issue.id}});
  }
}
