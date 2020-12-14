import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-petition-form',
  templateUrl: './petition-form.component.html',
  styleUrls: ['./petition-form.component.css']
})
export class PetitionFormComponent implements OnInit {
  latitude = 44.439663;
  longitude = 26.096306;
  zoom = 13.0;
    opened = false;
    location(x) {
        this.latitude = x.coords.lat;
        this.longitude = x.coords.lng;
    }
  constructor() { }

  ngOnInit(): void {
  }

}
