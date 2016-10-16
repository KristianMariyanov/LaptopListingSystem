import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { AuthenticationService } from '../services/auth.service';

@Component({
    moduleId: module.id,
    templateUrl: 'register.html',
    providers: [AuthenticationService]
})

export class RegisterComponent {
    model: any = {};
    loading = false;
    error = '';

    constructor(
        private router: Router,
        private authenticationService: AuthenticationService) { }

    register() {
        this.loading = true;
        this.authenticationService.register(this.model.email, this.model.password)
            .subscribe(
                result => this.router.navigate(['/login']),
                error => this.error = <any>error
            );
    }
}
