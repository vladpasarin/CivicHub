import { Component, OnInit, ViewChild } from "@angular/core";
import { ModalDirective } from "ngx-bootstrap/modal";
import { ApiService } from "../../shared/api.service";

@Component({
  selector: "photo-modal",
  templateUrl: "./photo-modal.component.html",
  styleUrls: ["./photo-modal.component.css"],
})
export class PhotoModalComponent implements OnInit {
  @ViewChild("photoModal") photoModal: ModalDirective;

  constructor(private api: ApiService) {}
  photoPath:string;
  ngOnInit() {}

  initialize(photo): void {
    this.photoPath=photo;
    this.photoModal.show();
  }

  
}
