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
var router_1 = require('@angular/router');
var common_1 = require('@angular/common');
var laptop_services_1 = require('../services/laptop.services');
var LaptopDetailsComponent = (function () {
    function LaptopDetailsComponent(laptopService, route, location) {
        this.laptopService = laptopService;
        this.route = route;
        this.location = location;
    }
    LaptopDetailsComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.route.params.forEach(function (params) {
            var id = +params['id'];
            var laptop = _this.laptopService.getLaptop(id);
            laptop.subscribe(function (laptop) { return _this.laptopDetails = laptop; }, function (error) { return _this.errorMessage = error; });
        });
    };
    LaptopDetailsComponent = __decorate([
        core_1.Component({
            selector: 'my-app',
            templateUrl: 'app/laptops/details.html',
            providers: [laptop_services_1.LaptopService]
        }), 
        __metadata('design:paramtypes', [laptop_services_1.LaptopService, router_1.ActivatedRoute, common_1.Location])
    ], LaptopDetailsComponent);
    return LaptopDetailsComponent;
}());
exports.LaptopDetailsComponent = LaptopDetailsComponent;
//# sourceMappingURL=laptop-details.component.js.map