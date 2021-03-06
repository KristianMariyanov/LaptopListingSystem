﻿import { Injectable } from '@angular/core';
import { Http, Response, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs/Observable';

import { BaseService } from '../base.service';
import { Comment } from '../../comment';
import '../rxjs-operators';

@Injectable()
export class BaseAdministrationService extends BaseService {
    constructor(public http: Http) { super(); }

    protected getAll(url: string) {
        let headers = this.getAuthorizationHeader();
        let options = new RequestOptions({ headers: headers });
        return this.http.get(url, options)
            .map(this.extractData)
            .catch(this.handleError);
    }

    protected add(url: string, formData: string): Observable<any> {
        let headers = this.getAuthorizationHeader();
        headers.append('Content-Type', 'application/x-www-form-urlencoded');
        let options = new RequestOptions({ headers: headers });
        return this.http.post(url, formData, options)
            .map(this.extractData)
            .catch(this.handleError);
    }

    protected delete(url: string): Observable<any> {
        let headers = this.getAuthorizationHeader();
        let options = new RequestOptions({ headers: headers });
        return this.http.delete(url, options)
            .map(res => res)
            .catch(this.handleError);
    }

    protected get(url: string): Observable<any> {
        let headers = this.getAuthorizationHeader();
        let options = new RequestOptions({ headers: headers });
        return this.http.get(url, options)
            .map(this.extractData)
            .catch(this.handleError);
    }

    protected update(url: string, formData: string): Observable<any> {
        let headers = this.getAuthorizationHeader();
        headers.append('Content-Type', 'application/x-www-form-urlencoded');
        let options = new RequestOptions({ headers: headers });
        return this.http.put(url, formData, options)
            .catch(this.handleError);
    }
}