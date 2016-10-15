import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from "./home/home.component";
import { LaptopDetailsComponent } from "./laptops/laptop-details.component";
import { LoginComponent } from "./login/login.component";
import { CommentsAdministrationComponent } from "./administration/comments-administration.component";
import { EditCommentAdministrationComponent } from "./administration/edit-comment-administration.component";
import { AddCommentAdministrationComponent } from "./administration/add-comment-administration.component";
import { ManufacturersAdministrationComponent } from "./administration/manufacturers-administration.component";
import { EditManufacturerAdministrationComponent } from "./administration/edit-manufacturer-administration.component";
import { AddManufacturerAdministrationComponent } from "./administration/add-manufacturer-administration.component";

const appRoutes: Routes = [
    { path: 'home', component: HomeComponent },
    { path: '', redirectTo: 'home', pathMatch: "full" },
    { path: 'laptops/:id', component: LaptopDetailsComponent },
    { path: 'login', component: LoginComponent },
    { path: 'administration/comments', component: CommentsAdministrationComponent },
    { path: 'administration/comments/edit/:id', component: EditCommentAdministrationComponent },
    { path: 'administration/comments/add', component: AddCommentAdministrationComponent },
    { path: 'administration/manufacturers', component: ManufacturersAdministrationComponent },
    { path: 'administration/manufacturers/edit/:id', component: EditManufacturerAdministrationComponent },
    { path: 'administration/manufacturers/add', component: AddManufacturerAdministrationComponent },
];

export const routing = RouterModule.forRoot(appRoutes);