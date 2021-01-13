import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { HomeComponent } from "./home/home.component";
import { SignUpComponent } from "./signUp/signUp.component";
import { LoginComponent } from "./login/login.component";
import { ProfileComponent } from './profile/profile.component';
import { ContactComponent } from './contact/contact.component';
import { PetitonListComponent } from './petiton-list/petiton-list.component';
import { PetitionProfileComponent } from './petition-profile/petition-profile.component';
import { UserProfileComponent } from './user-profile/user-profile.component';
import { PetitionFormComponent } from './petition-form/petition-form.component';
import { TopsComponent } from "./tops/tops.component";


const routes: Routes = [
  { path: "", component: HomeComponent },
  { path: "signUp", component: SignUpComponent },
  { path: "login", component: LoginComponent },
  { path: "home", component: HomeComponent },
  { path: "profile/:id", component: ProfileComponent },
  { path: "contact", component: ContactComponent },
  { path: "petition-list", component: PetitonListComponent },
  { path: "petition-profile/:id", component: PetitionProfileComponent },
  { path: "user-profile/:id", component: UserProfileComponent },
  { path: "petition-form", component: PetitionFormComponent },
  { path: "tops", component: TopsComponent },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
