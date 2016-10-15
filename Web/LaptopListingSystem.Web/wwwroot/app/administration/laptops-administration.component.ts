import { Component } from '@angular/core';

import { LaptopDetails } from '../laptop-details';
import { LaptopsService } from '../services/administration/laptops.service';

@Component({
    selector: 'my-app',
    templateUrl: 'app/administration/laptops.html',
    providers: [LaptopsService]
})

export class LaptopsAdministrationComponent {
    errorMessage: string;
    laptops: LaptopDetails[];

    constructor(private laptopsService: LaptopsService) {}
    
    ngOnInit() {
        this.getLaptops();
    }

    getLaptops() {
        this.laptopsService.getLaptops()
            .subscribe(
                laptops => this.laptops = laptops,
                error => this.errorMessage = <any>error);
    }

    deleteLaptop(laptopId: number) {
        this.laptopsService.deleteLaptop(laptopId)
            .subscribe(
                result => {
                    console.log(result);
                    this.laptops = this.laptops.filter(laptop => (laptop.id !== laptopId));
                },
                error => this.errorMessage = <any>error);
    }
}