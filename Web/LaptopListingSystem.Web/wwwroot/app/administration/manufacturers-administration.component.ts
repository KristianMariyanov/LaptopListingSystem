import { Component } from '@angular/core';

import { Manufacturer } from '../manufacturer';
import { ManufacturersService } from '../services/administration/manufacturers.service';

@Component({
    selector: 'my-app',
    templateUrl: 'app/administration/manufacturers.html',
    providers: [ManufacturersService]
})

export class ManufacturersAdministrationComponent {
    errorMessage: string;
    manufacturers: Manufacturer[];

    constructor(private manufacturersService: ManufacturersService) {}
    
    ngOnInit() {
        this.getManufacturers();
    }

    getManufacturers() {
        this.manufacturersService.getManufacturers()
            .subscribe(
                manufacturers => this.manufacturers = manufacturers,
                error => this.errorMessage = <any>error);
    }

    deleteManufacturer(manufacturerId: number) {
        this.manufacturersService.deleteManufacturer(manufacturerId)
            .subscribe(
                result => {
                    this.manufacturers = this.manufacturers.filter(manufacturer => (manufacturer.id !== manufacturerId));
                },
                error => this.errorMessage = <any>error);
    }
}