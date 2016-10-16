import { Injectable } from '@angular/core';
import { Headers, RequestOptions, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class BaseService {
    getAuthorizationHeader(): Headers {
        var currentUser = JSON.parse(localStorage.getItem('currentUser'));
        let token = currentUser && currentUser.token;
        let header = new Headers({ 'Authorization': 'Bearer ' + token });
        return header;
    }

    getFormContentTypeHeader(): Headers {
        let header = new Headers({ 'Content-Type': 'application/x-www-form-urlencoded' });
        return header;
    }

    protected extractData(res: Response) {
        return res && res.json();
    }

    protected handleError(error: any) {
        // In a real world app, we might use a remote logging infrastructure
        // We'd also dig deeper into the error to get a better message
        let errMsg = (error.message) ? error.message :
            error.status ? `${error.status} - ${error.statusText}` : 'Server error';
        console.error(errMsg); // log to console instead
        return Observable.throw(errMsg);
    }
}