﻿import { bootstrap } from '@angular/platform-browser-dynamic';
import { HTTP_PROVIDERS } from '@angular/http';

import { AppComponent } from "./app.component";
import { HomeComponent } from "./home/home.component";
import { appRouterProviders } from "./app.routes";

bootstrap(AppComponent, [
    appRouterProviders,
    HTTP_PROVIDERS]);