import { Injectable } from '@angular/core';
import { Headers, RequestOptions } from '@angular/http';

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
}