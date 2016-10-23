import { Component, DoCheck } from '@angular/core';
import { AuthenticationService } from './services/auth.service';

@Component({
    selector: 'my-app',
    templateUrl: 'app/layout.html',
    providers: [AuthenticationService]
})
export class AppComponent implements DoCheck{
    isLoggedIn: boolean = false;
    
    ngDoCheck(): void {
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