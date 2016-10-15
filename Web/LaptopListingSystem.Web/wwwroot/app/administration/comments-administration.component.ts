import { Component } from '@angular/core';

import { Comment } from '../comment';
import { CommentsService } from '../services/administration/comments.service';

@Component({
    selector: 'my-app',
    templateUrl: 'app/administration/comments.html',
    providers: [CommentsService]
})

export class CommentsAdministrationComponent {
    errorMessage: string;
    comments: Comment[];

    constructor(private commentsService: CommentsService) {}
    
    ngOnInit() {
        this.getcomments();
    }

    getcomments() {
        this.commentsService.getComments()
            .subscribe(
                comments => this.comments = comments,
                error => this.errorMessage = <any>error);
    }

    deleteComment(commentId: number) {
        this.commentsService.deleteComment(commentId)
            .subscribe(
                result => {
                    console.log(result);
                    this.comments = this.comments.filter(comment => (comment.id !== commentId))
                },
                error => this.errorMessage = <any>error);
    }
}