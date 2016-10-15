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
var CommentsService = (function (_super) {
    __extends(CommentsService, _super);
    function CommentsService(http) {
        _super.call(this, http);
        this.http = http;
        this.baseCommentsUrl = 'api/administration/comments';
    }
    CommentsService.prototype.getComments = function () {
        return this.getAll(this.baseCommentsUrl);
    };
    CommentsService.prototype.addComment = function (content, laptopId, userEmail) {
        return this.add(this.baseCommentsUrl, "content=" + content + "&laptopId=" + laptopId + "&userEmail=" + userEmail);
    };
    CommentsService.prototype.deleteComment = function (commentId) {
        return this.delete(this.baseCommentsUrl + "/" + commentId);
    };
    CommentsService.prototype.getComment = function (commentId) {
        return this.get(this.baseCommentsUrl + "/" + commentId);
    };
    CommentsService.prototype.updateComment = function (content, laptopId, userEmail, commentId) {
        return this.update(this.baseCommentsUrl, "content=" + content + "&laptopId=" + laptopId + "&userEmail=" + userEmail + "&commentId=" + commentId);
    };
    CommentsService = __decorate([
        core_1.Injectable(), 
        __metadata('design:paramtypes', [http_1.Http])
    ], CommentsService);
    return CommentsService;
}(base_administration_service_1.BaseAdministrationService));
exports.CommentsService = CommentsService;
//# sourceMappingURL=comments.service.js.map