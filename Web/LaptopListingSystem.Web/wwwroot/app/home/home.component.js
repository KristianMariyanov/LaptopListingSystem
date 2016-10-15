"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var core_1 = require('@angular/core');
var laptop_service_1 = require('../services/laptop.service');
var HomeComponent = (function () {
    function HomeComponent(laptopService) {
        this.laptopService = laptopService;
    }
    HomeComponent.prototype.ngOnInit = function () {
        this.getLaptops();
    };
    HomeComponent.prototype.getLaptops = function () {
        var _this = this;
        this.laptopService.getLaptops()
            .subscribe(function (laptops) { return _this.laptops = laptops; }, function (error) { return _this.errorMessage = error; });
    };
    HomeComponent.prototype.filterLaptops = function (searchTerm) {
        var _this = this;
        this.laptopService.filterLaptops(searchTerm, this.order)
            .subscribe(function (laptops) { return _this.laptops = laptops; }, function (error) { return _this.errorMessage = error; });
    };
    HomeComponent = __decorate([
        core_1.Component({
            selector: 'my-app',
            templateUrl: 'app/home/home.html',
            providers: [laptop_service_1.LaptopService]
        }), 
        __metadata('design:paramtypes', [laptop_service_1.LaptopService])
    ], HomeComponent);
    return HomeComponent;
}());
exports.HomeComponent = HomeComponent;
//# sourceMappingURL=home.component.js.map