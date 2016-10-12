import { Component } from '@angular/core';

import { Laptop } from '../laptop';
import { LaptopService } from '../services/laptop.services';

@Component({
    selector: 'my-app',
    templateUrl: 'app/home/home.html',
    providers: [LaptopService]
})

export class HomeComponent {
    errorMessage: string;
    laptops: Laptop[];
    mode = 'Observable';

    ngOnInit() { this.getLaptops(); }

    constructor(private laptopService: LaptopService) { }

    getLaptops() {
        let laptopsTest = this.laptopService.getLaptops();
        console.log(laptopsTest);
        laptopsTest.subscribe(
                laptops => this.laptops = laptops,
                error => this.errorMessage = <any>error);
    }
}