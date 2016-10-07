import { Component } from '@angular/core';
import { ROUTER_DIRECTIVES } from '@angular/router';

@Component({
    selector: 'my-app',
    template: '<h1>My first Angular 2 App. I will have a new job!</h1>' +
        '<router-outlet></router-outlet>',
    directives: [ROUTER_DIRECTIVES]
})
export class AppComponent { }