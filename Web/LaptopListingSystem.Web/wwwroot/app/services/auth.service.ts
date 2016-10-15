import { Injectable } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs';
import 'rxjs/add/operator/map'

@Injectable()
export class AuthenticationService {
    public token: string;
    private options: any;

    constructor(private http: Http) {
        // set token if saved in local storage
        var currentUser = JSON.parse(localStorage.getItem('currentUser'));
        this.token = currentUser && currentUser.token;
        let headers = new Headers({ 'Content-Type': 'application/x-www-form-urlencoded' });
        headers.append("Accept", 'application/json');
        this.options = new RequestOptions({ headers: headers });
    }

    login(username, password): Observable<boolean> {
        return this.http.post('/api/token', 'email=' + username + '&password=' + password, this.options)
            .map((response: Response) => {
                // login successful if there's a jwt token in the response
                let responseData = response.json();
                let token = responseData && responseData.access_token;
                if (token) {
                    // set token property
                    this.token = token;

                    // store username and jwt token in local storage to keep user logged in between page refreshes
                    localStorage.setItem('currentUser', JSON.stringify({ username: username, token: token, isAdmin: responseData.is_admin }));

                    // return true to indicate successful login
                    return true;
                } else {
                    // return false to indicate failed login
                    return false;
                }
            });
    }

    logout(): void {
        // clear token remove user from local storage to log user out
        this.token = null;
        localStorage.removeItem('currentUser');
    }

    isAdmin(): boolean {
        let currentUser = localStorage.getItem('currentUser');
        return !!(currentUser && JSON.parse(currentUser).isAdmin);
    }
}