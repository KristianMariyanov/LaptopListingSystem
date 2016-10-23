import { Component } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';

import { Manufacturer } from '../../manufacturer';
import { ManufacturersService } from '../../services/administration/manufacturers.service';

@Component({
    selector: 'my-app',
    templateUrl: 'app/administration/manufacturers/edit-manufacturer.html',
    providers: [ManufacturersService]
})

export class EditManufacturerAdministrationComponent {
    errorMessage: string;
    manufacturer: Manufacturer = new Manufacturer();

    constructor(
        private manufacturersService: ManufacturersService,
        private route: ActivatedRoute,
        private router: Router) {
    }

    ngOnInit() {
        console.log('init');
        this.route.params.forEach((params: Params) => {
            let id = + params['id'];
            this.manufacturersService.getManufacturer(id)
                .subscribe(
                    manufacturer => this.manufacturer = manufacturer,
                    error => this.errorMessage = <any>error);
        });
    }

    updateManufacturer() {
        this.manufacturersService.updateManufacturer(
            this.manufacturer.id,
            this.manufacturer.name)
            .subscribe(
                result => {
                    this.router.navigate(['/administration/manufacturers']);
                },
            error => this.errorMessage = <any>error);
    }
}