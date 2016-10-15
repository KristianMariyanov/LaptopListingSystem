import { Component } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import { Location } from '@angular/common';

import { LaptopDetails } from '../laptop-details';
import { LaptopService } from '../services/laptop.service';

@Component({
    selector: 'my-app',
    templateUrl: 'app/laptops/details.html',
    providers: [LaptopService]
})

export class LaptopDetailsComponent {
    errorMessage: string;
    laptopDetails: LaptopDetails;
    model: any = {};
    loading = false;
    commentError = '';

    ngOnInit() {
        this.route.params.forEach((params: Params) => {
            let id = + params['id'];
            let laptop = this.laptopService.getLaptop(id);
            laptop.subscribe(
                laptop => this.laptopDetails = laptop,
                error => this.errorMessage = <any>error);
        });
    }

    constructor(
        private laptopService: LaptopService,
        private route: ActivatedRoute,
        private location: Location) { }

    addComment() {
        this.laptopService
            .addComment(this.model.content, this.laptopDetails.id)
            .subscribe(
                result => {
                    this.laptopDetails.comments.push(this.model.content);
                },
                error => this.commentError = error
            );
    }

    addVote() {
        this.laptopService
            .addVote(this.laptopDetails.id)
            .subscribe(
                result => {
                    this.laptopDetails.votesCount++;
                },
                error => this.commentError = error
            );
    }
}