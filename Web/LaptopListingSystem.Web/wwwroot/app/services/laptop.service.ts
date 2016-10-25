import { Injectable } from '@angular/core';
import { Http, Response, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs/Observable';

import { Laptop } from '../laptop';
import { LaptopDetails } from '../laptop-details';
import { BaseService } from './base.service';
import './rxjs-operators';

@Injectable()
export class LaptopService extends BaseService {
    private laptopsBaseUrl = 'api/laptops/';
    private addCommentUrl = 'api/comments';
    private addVoteUrl = 'api/votes';

    constructor(private http: Http) { super(); }

    getLaptops(): Observable<Laptop[]> {
        return this.http.get(this.laptopsBaseUrl)
            .map(this.extractData)
            .catch(this.handleError);
    }

    getLaptop(id: number): Observable<LaptopDetails> {
        return this.http.get(this.laptopsBaseUrl + id)
            .map(this.extractData)
            .catch(this.handleError);
    }

    addComment(content: string, laptopId: number): Observable<any> {
        let headers = this.getAuthorizationHeader();
        let options = new RequestOptions({ headers: headers });
        return this.http.post(this.addCommentUrl, { content: content, laptopId: laptopId }, options)
            .map(this.extractData)
            .catch(this.handleError);
    }

    addVote(laptopId: number): Observable<any> {
        let headers = this.getAuthorizationHeader();
        let options = new RequestOptions({ headers: headers });
        return this.http.post(this.addVoteUrl, { laptopId: laptopId }, options)
            .map(this.extractData)
            .catch(this.handleError);
    }

    filterLaptops(term: string, order: string): Observable<Laptop[]> {
        let headers = this.getAuthorizationHeader();
        let options = new RequestOptions({ headers: headers });
        return this.http.get(`${this.laptopsBaseUrl}filter?term=${term}&order=${order}`, options)
            .map(this.extractData)
            .catch(this.handleError);
    }
}