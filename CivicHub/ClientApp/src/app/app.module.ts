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
import { AgmCoreModule, AgmGeocoder } from '@agm/core';
import { ContactComponent } from './contact/contact.component';
import { ProfileComponent } from './profile/profile.component';
import { SidebarComponent } from './sidebar/sidebar.component';
import {SidebarModule} from "ng-sidebar";
import { PetitonListComponent } from './petiton-list/petiton-list.component'
import { SearchPipe } from "./shared/search.pipe";
import { PetitionProfileComponent } from './petition-profile/petition-profile.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { UserProfileComponent } from './user-profile/user-profile.component';
import { PhotoModalComponent } from './petition-profile/photo-modal/photo-modal.component';
import { PetitionFormComponent } from './petition-form/petition-form.component';
import { PipeFunctionPipe } from './pipe-function.pipe';
import { SignFormComponent } from "./petition-profile/sign-form/sign-form.component";
import { TopsComponent } from './tops/tops.component';
import { SortDirective } from "./directive/sort.directive";

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
        UserProfileComponent,
        PhotoModalComponent,
        PetitionFormComponent,
        PipeFunctionPipe,
        SignFormComponent,
        TopsComponent,
        SortDirective,

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
       apiKey: 'AIzaSyA7CkGiCKCmf1QT2e7i-0OYfR0NdgSieYc'
     }),
      SidebarModule.forRoot(),
      FontAwesomeModule,
  ],
  exports: [],
    bootstrap: [AppComponent],
  providers: [AuthGuard],
})
export class AppModule {}
