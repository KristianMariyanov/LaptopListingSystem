import { Component } from '@angular/core';
import { AuthenticationService } from './services/auth.service';

@Component({
    selector: 'my-app',
    templateUrl: 'app/layout.html',
    providers: [AuthenticationService]
})
export class AppComponent {
    isLoggedIn: boolean = false;

    ngOnInit() {
        if (localStorage.getItem('currentUser')) {
            this.isLoggedIn = true;
        }
    }

    constructor(public authService: AuthenticationService) { }

    logout() {
        this.authService.logout();
        this.isLoggedIn = false;
    }
}