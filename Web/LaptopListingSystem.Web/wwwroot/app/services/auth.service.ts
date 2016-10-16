import { Injectable } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs';
import 'rxjs/add/operator/map';
import { BaseService } from './base.service';

@Injectable()
export class AuthenticationService extends BaseService {
    public token: string;
    private options: any;

    constructor(private http: Http) {
        super();
        // set token if saved in local storage
        var currentUser = JSON.parse(localStorage.getItem('currentUser'));
        this.token = currentUser && currentUser.token;
        let headers = new Headers({ 'Content-Type': 'application/x-www-form-urlencoded' });
        headers.append("Accept", 'application/json');
        this.options = new RequestOptions({ headers: headers });
    }

    login(email, password): Observable<boolean> {
        return this.http.post('/api/token', 'email=' + email + '&password=' + password, this.options)
            .map((response: Response) => {
                let responseData = response.json();
                let token = responseData && responseData.access_token;
                if (token) {
                    this.token = token;
                    localStorage.setItem(
                        'currentUser',
                        JSON.stringify({ email: email, token: token, isAdmin: responseData.is_admin }));
                    return true;
                } else {
                    return false;
                }
            });
    }

    register(email, password): Observable<any> {
        return this.http.post('/api/auth/register', 'email=' + email + '&password=' + password, this.options)
            .catch(this.handleError);
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