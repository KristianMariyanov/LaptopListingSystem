import { Component } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';

import { LaptopDetails } from '../laptop-details';
import { LaptopsService } from '../services/administration/laptops.service';

@Component({
    selector: 'my-app',
    templateUrl: 'app/administration/edit-laptop.html',
    providers: [LaptopsService]
})

export class EditLaptopAdministrationComponent {
    errorMessage: string;
    laptop: LaptopDetails = new LaptopDetails();

    constructor(
        private laptopsService: LaptopsService,
        private route: ActivatedRoute,
        private router: Router) {
    }

    ngOnInit() {
        console.log('init');
        this.route.params.forEach((params: Params) => {
            let id = + params['id'];
            let laptop = this.laptopsService.getLaptop(id);
            console.log(laptop);
            laptop.subscribe(
                laptop => this.laptop = laptop,
                error => this.errorMessage = <any>error);
        });
    }

    updateLaptop() {
        this.laptopsService.updateLaptop(
            this.laptop.id,
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