import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpModule, Http } from '@angular/http';
import { AUTH_PROVIDERS, AuthHttp, AuthConfig } from 'angular2-jwt';
import { FormsModule } from '@angular/forms';

import { routing } from './app.routes';

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { LaptopDetailsComponent } from './laptops/laptop-details.component';
import { LoginComponent } from './login/login.component';

import { LaptopService } from './services/laptop.service';

@NgModule({
    imports: [
        BrowserModule,
        HttpModule,
        FormsModule,
        routing
    ],
    declarations: [
        AppComponent,
        HomeComponent,
        LaptopDetailsComponent,
        LoginComponent
    ],
    providers: [
        AUTH_PROVIDERS,
        {
            provide: AuthConfig,
            useClass: AuthConfig,
            deps: [Http]
        },],
    bootstrap: [AppComponent]
})

export class AppModule { }