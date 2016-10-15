"use strict";
var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
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
var http_1 = require('@angular/http');
require('../rxjs-operators');
var base_administration_service_1 = require('./base-administration.service');
var ManufacturersService = (function (_super) {
    __extends(ManufacturersService, _super);
    function ManufacturersService(http) {
        _super.call(this, http);
        this.http = http;
        this.baseManufacturersUrl = 'api/administration/manufacturers';
    }
    ManufacturersService.prototype.getManufacturers = function () {
        return this.getAll(this.baseManufacturersUrl);
    };
    ManufacturersService.prototype.addManufacturer = function (name) {
        return this.add(this.baseManufacturersUrl, "name=" + name);
    };
    ManufacturersService.prototype.deleteManufacturer = function (manufacturerId) {
        return this.delete(this.baseManufacturersUrl + "/" + manufacturerId);
    };
    ManufacturersService.prototype.getManufacturer = function (manufacturerId) {
        return this.get(this.baseManufacturersUrl + "/" + manufacturerId);
    };
    ManufacturersService.prototype.updateManufacturer = function (manufacturerId, name) {
        return this.update(this.baseManufacturersUrl, "name=" + name + "&manufacturerId=" + manufacturerId);
    };
    ManufacturersService = __decorate([
        core_1.Injectable(), 
        __metadata('design:paramtypes', [http_1.Http])
    ], ManufacturersService);
    return ManufacturersService;
}(base_administration_service_1.BaseAdministrationService));
exports.ManufacturersService = ManufacturersService;
//# sourceMappingURL=manufacturers.service.js.map