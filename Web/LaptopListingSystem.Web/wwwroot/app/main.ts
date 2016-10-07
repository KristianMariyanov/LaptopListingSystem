import { bootstrap } from '@angular/platform-browser-dynamic';
import { AppComponent } from "./app.component";
import { HomeComponent } from "./home/home.component";
import { appRouterProviders } from "./app.routes"

bootstrap(AppComponent, [
    appRouterProviders]);