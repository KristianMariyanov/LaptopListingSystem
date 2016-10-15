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
var manufacturer_1 = require('../manufacturer');
var manufacturers_service_1 = require('../services/administration/manufacturers.service');
var EditManufacturerAdministrationComponent = (function () {
    function EditManufacturerAdministrationComponent(manufacturersService, route, router) {
        this.manufacturersService = manufacturersService;
        this.route = route;
        this.router = router;
        this.manufacturer = new manufacturer_1.Manufacturer();
    }
    EditManufacturerAdministrationComponent.prototype.ngOnInit = function () {
        var _this = this;
        console.log('init');
        this.route.params.forEach(function (params) {
            var id = +params['id'];
            _this.manufacturersService.getManufacturer(id)
                .subscribe(function (manufacturer) { return _this.manufacturer = manufacturer; }, function (error) { return _this.errorMessage = error; });
        });
    };
    EditManufacturerAdministrationComponent.prototype.updateManufacturer = function () {
        var _this = this;
        this.manufacturersService.updateManufacturer(this.manufacturer.id, this.manufacturer.name)
            .subscribe(function (result) {
            _this.router.navigate(['/administration/manufacturers']);
        }, function (error) { return _this.errorMessage = error; });
    };
    EditManufacturerAdministrationComponent = __decorate([
        core_1.Component({
            selector: 'my-app',
            templateUrl: 'app/administration/edit-manufacturer.html',
            providers: [manufacturers_service_1.ManufacturersService]
        }), 
        __metadata('design:paramtypes', [manufacturers_service_1.ManufacturersService, router_1.ActivatedRoute, router_1.Router])
    ], EditManufacturerAdministrationComponent);
    return EditManufacturerAdministrationComponent;
}());
exports.EditManufacturerAdministrationComponent = EditManufacturerAdministrationComponent;
//# sourceMappingURL=edit-manufacturer-administration.component.js.map