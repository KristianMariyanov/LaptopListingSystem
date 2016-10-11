import { provideRouter, RouterConfig }  from '@angular/router';
import { HomeComponent } from "./home/home.component";
import { LaptopDetailsComponent } from "./laptops/laptop-details.component";

const routes: RouterConfig = [
    { 
        path: 'home',
        component: HomeComponent
    },
    {
        path: '',
        redirectTo: 'home',
        pathMatch: "full"
    },
    {
        path: 'laptops/:id',
        component: LaptopDetailsComponent
    }
];

export const appRouterProviders = [
    provideRouter(routes)
];