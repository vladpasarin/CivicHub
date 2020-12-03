import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-petition-form',
  templateUrl: './petition-form.component.html',
  styleUrls: ['./petition-form.component.css']
})
export class PetitionFormComponent implements OnInit {
  lat = 44.439663;
  lng = 26.096306;
  zoom = 13.0;
  opened = false;
  constructor() { }

  ngOnInit(): void {
  }

}
