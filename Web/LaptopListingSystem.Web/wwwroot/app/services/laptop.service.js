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
var Observable_1 = require('rxjs/Observable');
var base_service_1 = require('./base.service');
require('./rxjs-operators');
var LaptopService = (function (_super) {
    __extends(LaptopService, _super);
    function LaptopService(http) {
        _super.call(this);
        this.http = http;
        this.laptopsBaseUrl = 'api/laptops/';
        this.addCommentUrl = 'api/comments';
        this.addVoteUrl = 'api/votes';
    }
    LaptopService.prototype.getLaptops = function () {
        return this.http.get(this.laptopsBaseUrl)
            .map(this.extractData)
            .catch(this.handleError);
    };
    LaptopService.prototype.getLaptop = function (id) {
        return this.http.get(this.laptopsBaseUrl + id)
            .map(this.extractData)
            .catch(this.handleError);
    };
    LaptopService.prototype.addComment = function (content, laptopId) {
        var headers = this.getAuthorizationHeader();
        headers.append('Content-Type', 'application/x-www-form-urlencoded');
        var options = new http_1.RequestOptions({ headers: headers });
        return this.http.post(this.addCommentUrl, "content=" + content + "&laptopId=" + laptopId, options)
            .map(this.extractData)
            .catch(this.handleError);
    };
    LaptopService.prototype.addVote = function (laptopId) {
        var headers = this.getAuthorizationHeader();
        headers.append('Content-Type', 'application/x-www-form-urlencoded');
        var options = new http_1.RequestOptions({ headers: headers });
        return this.http.post(this.addVoteUrl, "laptopId=" + laptopId, options)
            .map(this.extractData)
            .catch(this.handleError);
    };
    LaptopService.prototype.filterLaptops = function (term, order) {
        var headers = this.getAuthorizationHeader();
        var options = new http_1.RequestOptions({ headers: headers });
        return this.http.get(this.laptopsBaseUrl + "filter?term=" + term + "&order=" + order, options)
            .map(this.extractData)
            .catch(this.handleError);
    };
    LaptopService.prototype.extractData = function (res) {
        return res.json();
    };
    LaptopService.prototype.handleError = function (error) {
        // In a real world app, we might use a remote logging infrastructure
        // We'd also dig deeper into the error to get a better message
        var errMsg = (error.message) ? error.message :
            error.status ? error.status + " - " + error.statusText : 'Server error';
        console.error(errMsg); // log to console instead
        return Observable_1.Observable.throw(errMsg);
    };
    LaptopService = __decorate([
        core_1.Injectable(), 
        __metadata('design:paramtypes', [http_1.Http])
    ], LaptopService);
    return LaptopService;
}(base_service_1.BaseService));
exports.LaptopService = LaptopService;
//# sourceMappingURL=laptop.service.js.map