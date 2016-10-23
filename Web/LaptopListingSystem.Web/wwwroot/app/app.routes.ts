import { Routes, RouterModule } from '@angular/router';

import { AuthGuard } from "./guards/auth.guard";
import { HomeComponent } from "./home/home.component";
import { LaptopDetailsComponent } from "./laptops/laptop-details.component";
import { LoginComponent } from "./login/login.component";
import { RegisterComponent } from "./register/register.component";
import { CommentsAdministrationComponent } from "./administration/comments/comments-administration.component";
import { EditCommentAdministrationComponent } from "./administration/comments/edit-comment-administration.component";
import { AddCommentAdministrationComponent } from "./administration/comments/add-comment-administration.component";
import { ManufacturersAdministrationComponent } from "./administration/manufacturers/manufacturers-administration.component";
import { EditManufacturerAdministrationComponent } from "./administration/manufacturers/edit-manufacturer-administration.component";
import { AddManufacturerAdministrationComponent } from "./administration/manufacturers/add-manufacturer-administration.component";
import { LaptopsAdministrationComponent } from "./administration/laptops/laptops-administration.component";
import { EditLaptopAdministrationComponent } from "./administration/laptops/edit-laptop-administration.component";
import { AddLaptopAdministrationComponent } from "./administration/laptops/add-laptop-administration.component";

const appRoutes: Routes = [
    { path: 'home', component: HomeComponent },
    { path: '', redirectTo: 'home', pathMatch: "full" },
    { path: 'laptops/:id', component: LaptopDetailsComponent },
    { path: 'login', component: LoginComponent },
    { path: 'register', component: RegisterComponent },
    { path: 'administration/comments', component: CommentsAdministrationComponent, canActivate: [AuthGuard] },
    { path: 'administration/comments/edit/:id', component: EditCommentAdministrationComponent, canActivate: [AuthGuard] },
    { path: 'administration/comments/add', component: AddCommentAdministrationComponent, canActivate: [AuthGuard] },
    { path: 'administration/manufacturers', component: ManufacturersAdministrationComponent, canActivate: [AuthGuard] },
    { path: 'administration/manufacturers/edit/:id', component: EditManufacturerAdministrationComponent, canActivate: [AuthGuard] },
    { path: 'administration/manufacturers/add', component: AddManufacturerAdministrationComponent, canActivate: [AuthGuard] },
    { path: 'administration/laptops', component: LaptopsAdministrationComponent, canActivate: [AuthGuard] },
    { path: 'administration/laptops/edit/:id', component: EditLaptopAdministrationComponent, canActivate: [AuthGuard] },
    { path: 'administration/laptops/add', component: AddLaptopAdministrationComponent, canActivate: [AuthGuard] },
];

export const routing = RouterModule.forRoot(appRoutes);