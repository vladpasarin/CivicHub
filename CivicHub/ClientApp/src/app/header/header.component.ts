import { Component, OnInit, ViewChild } from "@angular/core";
import { AuthService } from "../auth.service";
import { Router } from "@angular/router";

@Component({
  selector: "app-header",
  templateUrl: "./header.component.html",
  styleUrls: ["./header.component.css"],
})
export class HeaderComponent implements OnInit {
  storage = localStorage.getItem("isLoggedIn");
  firstName: string;
  logged:string;
  userId:number;

  logout(): void {
    this.authService.logout();
    this.router.navigate(["/home"]);
  }

  constructor(public authService: AuthService, private router: Router) {}

  ngOnInit() {
    this.firstName = localStorage.getItem("firstName");
    this.logged = localStorage.getItem("isLogged");
    this.userId = parseInt(localStorage.getItem("userId"));
  }
  checkLoggedIn(){
    if (this.logged == 'true'){
      this.router.navigate(["/profile"]);
      console.log("se executa")
    }
    else{
      this.router.navigate(["/login"]);
    }
  }
}
