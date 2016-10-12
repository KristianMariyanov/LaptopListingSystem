import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpModule } from '@angular/http';

import { BaseRequestOptions } from '@angular/http';

import { AppComponent } from './app.component';
import { routing } from './app.routes';

import { HomeComponent } from './home/home.component';
import { LaptopDetailsComponent } from './laptops/laptop-details.component';

import { LaptopService } from './services/laptop.services';

@NgModule({
    imports: [
        BrowserModule,
        HttpModule,
        routing
    ],
    declarations: [
        AppComponent,
        HomeComponent,
        LaptopDetailsComponent
    ],
    bootstrap: [AppComponent]
})

export class AppModule { }