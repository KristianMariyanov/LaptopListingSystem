import { Component } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import { Location } from '@angular/common';

import { LaptopDetails } from '../laptop-details';
import { LaptopService } from '../services/laptop.services';

@Component({
    selector: 'my-app',
    templateUrl: 'app/laptops/details.html',
    providers: [LaptopService]
})

export class LaptopDetailsComponent {
    errorMessage: string;
    laptopDetails: LaptopDetails;

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
}