import { Component } from '@angular/core';
import { Params, Router } from '@angular/router';

import { Manufacturer } from '../manufacturer';
import { ManufacturersService } from '../services/administration/manufacturers.service';

@Component({
    selector: 'my-app',
    templateUrl: 'app/administration/add-manufacturer.html',
    providers: [ManufacturersService]
})

export class AddManufacturerAdministrationComponent {
    errorMessage: string;
    manufacturer: Manufacturer = new Manufacturer();

    constructor(
        private manufacturersService: ManufacturersService,
        private router: Router) {
    }

    addManufacturer() {
        this.manufacturersService.addManufacturer(this.manufacturer.name)
            .subscribe(
                result => {
                    this.router.navigate(['/administration/manufacturers']);
                },
                error => this.errorMessage = <any>error);
    }
}