import { Component, OnInit } from '@angular/core';
import { NgZone } from '@angular/core';

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
    markerLat: number;
    markerLng: number;
    markerAplha = 1;
   
  map: google.maps.Map<Element>;
  mapClickListener: google.maps.MapsEventListener;

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
      this.markerLat = lat;
      this.markerLng = lng;
  }

  public mapReadyHandler(map: google.maps.Map): void {
    this.map = map;
    this.mapClickListener = this.map.addListener('click', (e: google.maps.MouseEvent) => {
      this.zone.run(() => {

          console.log(e.latLng.lat(), e.latLng.lng());
          this.addMarker(e.latLng.lat(), e.latLng.lng());
      });
    });
  }

  constructor(private zone: NgZone) { }

  ngOnInit(): void {
  }

}
