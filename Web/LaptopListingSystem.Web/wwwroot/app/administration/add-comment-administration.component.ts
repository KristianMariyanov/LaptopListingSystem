import { Component } from '@angular/core';
import { Params, Router } from '@angular/router';

import { Comment } from '../comment';
import { CommentsService } from '../services/administration/comments.service';

@Component({
    selector: 'my-app',
    templateUrl: 'app/administration/add-comment.html',
    providers: [CommentsService]
})

export class AddCommentAdministrationComponent {
    errorMessage: string;
    comment: Comment = new Comment();

    constructor(
        private commentsService: CommentsService,
        private router: Router) {
    }

    ngOnInit() { }

    addComment() {
        this.commentsService.addComment(
                this.comment.content,
                this.comment.laptopId,
                this.comment.author)
            .subscribe(
                result => {
                    this.router.navigate(['/administration/comments']);
                },
                error => this.errorMessage = <any>error);
    }
}