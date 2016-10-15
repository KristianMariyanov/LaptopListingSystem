import { Injectable } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs';
import 'rxjs/add/operator/map'

import {BaseAdministrationService} from './base-administration.service';

@Injectable()
export class CommentsService extends BaseAdministrationService {
    constructor(private http: Http) { super(); }

    addComment(content: string, laptopId: number, userEmail: string): Observable<any> {
        let headers = this.getAuthorizationHeader();
        headers.append('Content-Type', 'application/x-www-form-urlencoded');
        let options = new RequestOptions({ headers: headers });
        ////return this.http.post(this.addCommentUrl, `content=${content}&laptopId=${laptopId}`, options)
        ////    .map(this.extractData)
        ////    .catch(this.handleError);
    }

    deleteComment(commentId: number): Observable<any> {

    }

    getComment(commentId: number): Observable<any> {

    }

    updateComment(content: string, laptopId: number, userEmail: string): Observable<any> {

    }
}