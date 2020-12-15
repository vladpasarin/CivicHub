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
  urls = [];
  markers = [];
  selectedMarker: { lat: any; lng: any; };

  onSelectFile(event) {
    if (event.target.files && event.target.files[0]) {
        var filesAmount = event.target.files.length;
        for (let i = 0; i < filesAmount; i++) {
                var reader = new FileReader();

                reader.onload = (event:any) => {
                  console.log(event.target.result);
                   this.urls.push(event.target.result); 
                }

                reader.readAsDataURL(event.target.files[i]);
        }
    }
  }

  addMarker(lat: number, lng: number) {
    this.markers.push({ lat, lng, alpha: 1 });
  }

  max(coordType: 'latitude' | 'longitude'): number {
    return Math.max(...this.markers.map(marker => marker[coordType]));
  }

  min(coordType: 'latitude' | 'longitude'): number {
    return Math.min(...this.markers.map(marker => marker[coordType]));
  }

  selectMarker(event) {
    this.selectedMarker = {
      lat: event.latitude,
      lng: event.longitude
    };
  }

  constructor() { }

  ngOnInit(): void {
  }

}
