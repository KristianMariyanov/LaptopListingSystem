import { Component } from '@angular/core';
import { CORE_DIRECTIVES, NgFor } from '@angular/common';
import { ROUTER_DIRECTIVES } from '@angular/router';
import { HomeComponent } from './home/home.component';

@Component({
    selector: 'my-app',
    templateUrl: 'app/layout.html',
    directives: [ROUTER_DIRECTIVES, CORE_DIRECTIVES, NgFor],
    precompile: [HomeComponent]
})
export class AppComponent { }