import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";

import { AppRoutingModule } from "./app-routing.module";
import { AppComponent } from "./app.component";
import { MDBBootstrapModule } from "angular-bootstrap-md";
import { HttpClientModule } from "@angular/common/http";
import { BsDatepickerModule } from "ngx-bootstrap/datepicker";
import { FieldErrorDisplayComponent } from "./field-error-display/field-error-display.component";
import { HeaderComponent } from "./header/header.component";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { ModalModule } from "ngx-bootstrap/modal";
import { HomeComponent } from "./home/home.component";
import { CommonModule } from "@angular/common";
import { SignUpComponent } from "./signUp/signUp.component";
import { AuthGuard } from "./auth.guard";
import { LoginComponent } from "./login/login.component";
import { AgmCoreModule } from '@agm/core';
import { ContactComponent } from './contact/contact.component';
import { ProfileComponent } from './profile/profile.component';
import { SidebarComponent } from './sidebar/sidebar.component';
import {SidebarModule} from "ng-sidebar";
import { PetitonListComponent } from './petiton-list/petiton-list.component'
import { SearchPipe } from "./shared/search.pipe";
import { PetitionProfileComponent } from './petition-profile/petition-profile.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';


@NgModule({
  declarations: [
    SearchPipe,
    AppComponent,
    HomeComponent,
    HeaderComponent,
    LoginComponent,
    SignUpComponent,
    FieldErrorDisplayComponent,
    ContactComponent,
    ProfileComponent,
    SidebarComponent,
    PetitonListComponent,
    PetitionProfileComponent,
  ],
  imports: [
    CommonModule,
    BrowserAnimationsModule,
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    MDBBootstrapModule.forRoot(),
    ModalModule.forRoot(),
    FormsModule,
    ReactiveFormsModule,
    BsDatepickerModule.forRoot(),
    AgmCoreModule.forRoot({
       apiKey: 'AIzaSyA9ue3Q6fk7aQGRym6lVpZ2LiFy-GItiMk'
     }),
      SidebarModule.forRoot(),
      FontAwesomeModule,
  ],
  exports: [],
    bootstrap: [AppComponent],
  providers: [AuthGuard],
})
export class AppModule {}
