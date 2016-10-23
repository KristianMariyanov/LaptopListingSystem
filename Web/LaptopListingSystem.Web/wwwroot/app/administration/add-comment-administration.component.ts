import { Component, OnInit } from '@angular/core';
import { Params, Router } from '@angular/router';

import { Comment } from '../comment';
import { DropdownItem } from '../dropdown-item'
import { CommentsService } from '../services/administration/comments.service';
import { LaptopsService } from '../services/administration/laptops.service';

@Component({
    selector: 'my-app',
    templateUrl: 'app/administration/add-comment.html',
    providers: [CommentsService, LaptopsService]
})

export class AddCommentAdministrationComponent implements OnInit{
    errorMessage: string;
    comment: Comment = new Comment();
    dropdownItems: DropdownItem[] = [];

    constructor(
        private commentsService: CommentsService,
        private laptopsService: LaptopsService,
        private router: Router) {
    }

    ngOnInit() {
        this.laptopsService.getDropdownItems()
            .subscribe(
                dropdownItems => this.dropdownItems = dropdownItems,
                error => this.errorMessage = <any>error);
    }

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