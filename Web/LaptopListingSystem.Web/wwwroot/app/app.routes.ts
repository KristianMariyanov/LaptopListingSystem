import { provideRouter, RouterConfig }  from '@angular/router';
//import { AppComponent } from  "./app.component";
import { HomeComponent } from  "./home/home.component";

const routes: RouterConfig = [
    { 
        path: "home",
        component: HomeComponent
    }
];

export const appRouterProviders = [
    provideRouter(routes)
];