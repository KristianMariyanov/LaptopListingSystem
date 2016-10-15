import { Component } from '@angular/core';

import { Laptop } from '../laptop';
import { LaptopService } from '../services/laptop.service';

@Component({
    selector: 'my-app',
    templateUrl: 'app/home/home.html',
    providers: [LaptopService]
})

export class HomeComponent {
    errorMessage: string;
    laptops: Laptop[];
    order: any;

    ngOnInit() {
        this.getLaptops();
    }

    constructor(private laptopService: LaptopService) { }

    getLaptops() {
        this.laptopService.getLaptops()
            .subscribe(
                laptops => this.laptops = laptops,
                error => this.errorMessage = <any>error);
    }

    filterLaptops(searchTerm: string) {
        this.laptopService.filterLaptops(searchTerm, this.order)
            .subscribe(
                laptops => this.laptops = laptops,
                error => this.errorMessage = <any>error);
    }
}