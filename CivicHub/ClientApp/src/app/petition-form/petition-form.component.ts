import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { NgZone } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ApiService } from '../shared/api.service';
import { Issue } from '../shared/issue.model';
import { User } from '../shared/user.model';

@Component({
  selector: 'app-petition-form',
  templateUrl: './petition-form.component.html',
  styleUrls: ['./petition-form.component.css']
})
export class PetitionFormComponent implements OnInit {
  @ViewChild('address') adresa:ElementRef;

  latitude = 44.439663;
  longitude = 26.096306;
  zoom = 13.0;
  urls = [];
  photoByte:string;
    markerLat: number;
    markerLng: number;
    markerAlpha = 1;
    userIdInvalid:boolean;
    successAdd="";

    addIssueForm: FormGroup;
    success: boolean;
    issue = new Issue();
    userId = sessionStorage.getItem('userId');
   
  map: google.maps.Map<Element>;
  mapClickListener: google.maps.MapsEventListener;

  onSelectFile(event) {
    if (event.target.files && event.target.files[0]) {
        var filesAmount = event.target.files.length;
        for (let i = 0; i < filesAmount; i++) {
                var reader = new FileReader();

                reader.onload = (event:any) => {
                  this.photoByte = event.target.result.replace('data:image/png;base64,','');
                  this.urls.push(this.photoByte);
                   
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

          this.addMarker(e.latLng.lat(), e.latLng.lng());
          this.getAddress(e.latLng.lat(),e.latLng.lng());
      });
    });
  }
      

    getAddress( lat: number, lng: number ) {
      if (navigator.geolocation) {
        let geocoder = new google.maps.Geocoder();
        let latlng = new google.maps.LatLng(lat, lng);
        let request = {location:latlng};
        geocoder.geocode(request, (results, status) => {
          if (status === google.maps.GeocoderStatus.OK) {
            let result = results[0];
            let rsltAdrComponent = result.address_components;
            if (result != null) {
              this.adresa.nativeElement.value=rsltAdrComponent[1].short_name + " " + rsltAdrComponent[0].short_name
            } else {
              alert('No address available!');
            }
          }
        });
    }
  }

    addIssue() {
        if(this.userId == null){
          this.userIdInvalid=true
          setTimeout(() => {
            this.userIdInvalid=false
        }, 2000);
        }
        else{
        if (this.addIssueForm.valid && this.markerLat != null && this.markerLng != null) {
            this.success = true;
            setTimeout(() => {
                this.success = null;
            }, 3000);
            console.log("loginForm submitted");
            this.issue.description = this.f.description.value;
            this.issue.title = this.f.title.value;
            this.issue.latitude = this.markerLat;
            this.issue.longitude = this.markerLng;
            this.issue.userId = this.userId;
            this.issue.photos = this.urls;
            this.api.addIssue(this.issue).subscribe(() => {
              this.successAdd="Excellent! You gained 25 points"
              setTimeout(() => {
                this.successAdd = "";
                this.router.navigate(["/home"]);
            }, 3000);
            },
                (error: Error) => {
                    console.log('err', error);
                });
        } else {
            this.success = false;
            setTimeout(() => {
                this.success = null;
            }, 3000);
            this.validateAllFormFields(this.addIssueForm);
        }
      }
    }

    validateAllFormFields(formGroup: FormGroup) {
        Object.keys(formGroup.controls).forEach((field) => {
            console.log(field);
            const control = formGroup.get(field);
            if (control instanceof FormControl) {
                control.markAsTouched({ onlySelf: true });
            } else if (control instanceof FormGroup) {
                this.validateAllFormFields(control);
            }
        });
    }

    isFieldValid(field: string) {
        return (
          !this.addIssueForm.get(field).valid && this.addIssueForm.get(field).touched
        );
      }
    
      displayFieldCss(field: string) {
        return {
          "has-error": this.isFieldValid(field),
          "has-feedback": this.isFieldValid(field),
        };
      }

    get f() {
        return this.addIssueForm.controls;
    }

    constructor(private zone: NgZone, public fb: FormBuilder, private api: ApiService, private router: Router) { }

    ngOnInit(): void {
        this.addIssueForm = this.fb.group({
            address:[null],
            description: [null, Validators.required],
            title: [null, Validators.required],
        });
  }

}
