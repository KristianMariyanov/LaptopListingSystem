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
var http_1 = require('@angular/http');
var BaseService = (function () {
    function BaseService() {
    }
    BaseService.prototype.getAuthorizationHeader = function () {
        var currentUser = JSON.parse(localStorage.getItem('currentUser'));
        var token = currentUser && currentUser.token;
        var header = new http_1.Headers({ 'Authorization': 'Bearer ' + token });
        return header;
    };
    BaseService.prototype.getFormContentTypeHeader = function () {
        var header = new http_1.Headers({ 'Content-Type': 'application/x-www-form-urlencoded' });
        return header;
    };
    BaseService = __decorate([
        core_1.Injectable(), 
        __metadata('design:paramtypes', [])
    ], BaseService);
    return BaseService;
}());
exports.BaseService = BaseService;
//# sourceMappingURL=base.service.js.map