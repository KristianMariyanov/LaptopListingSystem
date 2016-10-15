import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from "./home/home.component";
import { LaptopDetailsComponent } from "./laptops/laptop-details.component";
import { LoginComponent } from "./login/login.component";

const appRoutes: Routes = [
    { path: 'home', component: HomeComponent },
    { path: '', redirectTo: 'home', pathMatch: "full" },
    { path: 'laptops/:id', component: LaptopDetailsComponent },
    { path: 'login', component: LoginComponent },
];

export const routing = RouterModule.forRoot(appRoutes);