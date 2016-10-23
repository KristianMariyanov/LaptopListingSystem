import { Component, OnInit } from '@angular/core';
import { Params, Router } from '@angular/router';

import { LaptopDetails } from '../laptop-details';
import { DropdownItem } from '../dropdown-item';
import { LaptopsService } from '../services/administration/laptops.service';
import { ManufacturersService } from '../services/administration/manufacturers.service';

@Component({
    selector: 'my-app',
    templateUrl: 'app/administration/add-laptop.html',
    providers: [LaptopsService, ManufacturersService]
})

export class AddLaptopAdministrationComponent implements OnInit {
    errorMessage: string;
    laptop: LaptopDetails = new LaptopDetails();
    dropdownItems: DropdownItem[] = [];

    constructor(
        private laptopsService: LaptopsService,
        private manufacturersService: ManufacturersService,
        private router: Router) {
    }

    ngOnInit() {
        this.manufacturersService.getDropdownItems()
            .subscribe(
                dropdownItems => this.dropdownItems = dropdownItems,
                error => this.errorMessage = <any> error);
    }

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