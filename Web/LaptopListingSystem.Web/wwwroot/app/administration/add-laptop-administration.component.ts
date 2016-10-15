import { Component } from '@angular/core';
import { Params, Router } from '@angular/router';

import { LaptopDetails } from '../laptop-details';
import { LaptopsService } from '../services/administration/laptops.service';

@Component({
    selector: 'my-app',
    templateUrl: 'app/administration/add-laptop.html',
    providers: [LaptopsService]
})

export class AddLaptopAdministrationComponent {
    errorMessage: string;
    laptop: LaptopDetails = new LaptopDetails();

    constructor(
        private laptopsService: LaptopsService,
        private router: Router) {
    }

    ngOnInit() { }

    addLaptop() {
        this.laptopsService.addLaptop(
            this.laptop.model,
            this.laptop.manufacturerId,
            this.laptop.imageUrl,
            this.laptop.price,
            this.laptop.ram,
            this.laptop.weight,
            this.laptop.description,
            this.laptop.additionalParts,
            this.laptop.hardDisk,
            this.laptop.monitor)
            .subscribe(
                result => {
                    this.router.navigate(['/administration/laptops']);
                },
                error => this.errorMessage = <any>error);
    }
}