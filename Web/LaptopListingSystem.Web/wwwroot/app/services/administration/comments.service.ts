import { Injectable } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs';
import '../rxjs-operators'

import { BaseAdministrationService } from './base-administration.service';
import { Comment } from "../../comment";

@Injectable()
export class CommentsService extends BaseAdministrationService {
    private baseCommentsUrl = 'api/administration/comments';

    constructor(public http: Http) { super(http); }

    getComments(): Observable<any> {
        return this.getAll(this.baseCommentsUrl);
    }

    addComment(content: string, laptopId: number, userEmail: string): Observable<any> {
        return this.add(
            this.baseCommentsUrl,
            `content=${content}&laptopId=${laptopId}&userEmail=${userEmail}`);
    }

    deleteComment(commentId: number): Observable<any> {
        return this.delete(`${this.baseCommentsUrl}/${commentId}`);
    }

    getComment(commentId: number): Observable<Comment> {
        return this.get(`${this.baseCommentsUrl}/${commentId}`);
    }

    updateComment(content: string, laptopId: number, userEmail: string, commentId: number): Observable<any> {
        return this.update(
            this.baseCommentsUrl,
            `content=${content}&laptopId=${laptopId}&userEmail=${userEmail}&commentId=${commentId}`);
    }
}