import { Component } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';

import { Comment } from '../comment';
import { DropdownItem } from '../dropdown-item';
import { CommentsService } from '../services/administration/comments.service';
import { LaptopsService } from '../services/administration/laptops.service';

@Component({
    selector: 'my-app',
    templateUrl: 'app/administration/edit-comment.html',
    providers: [CommentsService, LaptopsService]
})

export class EditCommentAdministrationComponent {
    errorMessage: string;
    comment: Comment = new Comment();
    dropdownItems: DropdownItem[] = [];

    constructor(
        private commentsService: CommentsService,
        private laptopsService: LaptopsService,
        private route: ActivatedRoute,
        private router: Router) {
    }

    ngOnInit() {
        console.log('init');
        this.route.params.forEach((params: Params) => {
            let id = + params['id'];
            let comment = this.commentsService.getComment(id);
            console.log(comment);
            comment.subscribe(
                comment => this.comment = comment,
                error => this.errorMessage = <any>error);
        });

        this.laptopsService.getDropdownItems()
            .subscribe(
                dropdownItems => this.dropdownItems = dropdownItems,
                error => this.errorMessage = <any>error);
    }

    updateComment() {
        this.commentsService.updateComment(
            this.comment.content,
            this.comment.laptopId,
            this.comment.author,
            this.comment.id)
            .subscribe(
            result => {
                this.router.navigate(['/administration/comments']);
            },
            error => this.errorMessage = <any>error);
    }
}