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
var manufacturers_service_1 = require('../services/administration/manufacturers.service');
var ManufacturersAdministrationComponent = (function () {
    function ManufacturersAdministrationComponent(manufacturersService) {
        this.manufacturersService = manufacturersService;
    }
    ManufacturersAdministrationComponent.prototype.ngOnInit = function () {
        this.getManufacturers();
    };
    ManufacturersAdministrationComponent.prototype.getManufacturers = function () {
        var _this = this;
        this.manufacturersService.getManufacturers()
            .subscribe(function (manufacturers) { return _this.manufacturers = manufacturers; }, function (error) { return _this.errorMessage = error; });
    };
    ManufacturersAdministrationComponent.prototype.deleteManufacturer = function (manufacturerId) {
        var _this = this;
        this.manufacturersService.deleteManufacturer(manufacturerId)
            .subscribe(function (result) {
            _this.manufacturers = _this.manufacturers.filter(function (manufacturer) { return (manufacturer.id !== manufacturerId); });
        }, function (error) { return _this.errorMessage = error; });
    };
    ManufacturersAdministrationComponent = __decorate([
        core_1.Component({
            selector: 'my-app',
            templateUrl: 'app/administration/manufacturers.html',
            providers: [manufacturers_service_1.ManufacturersService]
        }), 
        __metadata('design:paramtypes', [manufacturers_service_1.ManufacturersService])
    ], ManufacturersAdministrationComponent);
    return ManufacturersAdministrationComponent;
}());
exports.ManufacturersAdministrationComponent = ManufacturersAdministrationComponent;
//# sourceMappingURL=manufacturers-administration.component.js.map