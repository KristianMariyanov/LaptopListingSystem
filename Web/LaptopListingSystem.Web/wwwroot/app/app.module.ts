import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpModule, Http } from '@angular/http';
import { FormsModule } from '@angular/forms';

import { routing } from './app.routes';
import { AuthGuard } from "./guards/auth.guard";
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { LaptopDetailsComponent } from './laptops/laptop-details.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { CommentsAdministrationComponent } from './administration/comments/comments-administration.component';
import { EditCommentAdministrationComponent } from './administration/comments/edit-comment-administration.component';
import { AddCommentAdministrationComponent } from "./administration/comments/add-comment-administration.component";
import { ManufacturersAdministrationComponent } from "./administration/manufacturers/manufacturers-administration.component";
import { EditManufacturerAdministrationComponent } from "./administration/manufacturers/edit-manufacturer-administration.component";
import { AddManufacturerAdministrationComponent } from "./administration/manufacturers/add-manufacturer-administration.component";
import { LaptopsAdministrationComponent } from "./administration/laptops/laptops-administration.component";
import { EditLaptopAdministrationComponent } from "./administration/laptops/edit-laptop-administration.component";
import { AddLaptopAdministrationComponent } from "./administration/laptops/add-laptop-administration.component";

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
        LoginComponent,
        RegisterComponent,
        CommentsAdministrationComponent,
        EditCommentAdministrationComponent,
        AddCommentAdministrationComponent,
        ManufacturersAdministrationComponent,
        EditManufacturerAdministrationComponent,
        AddManufacturerAdministrationComponent,
        LaptopsAdministrationComponent,
        EditLaptopAdministrationComponent,
        AddLaptopAdministrationComponent
    ],
    providers: [
        AuthGuard
    ],
    bootstrap: [AppComponent]
})

export class AppModule { }