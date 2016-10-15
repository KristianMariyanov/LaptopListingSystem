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
var comments_service_1 = require('../services/administration/comments.service');
var CommentsAdministrationComponent = (function () {
    function CommentsAdministrationComponent(commentsService) {
        this.commentsService = commentsService;
    }
    CommentsAdministrationComponent.prototype.ngOnInit = function () {
        this.getcomments();
    };
    CommentsAdministrationComponent.prototype.getcomments = function () {
        var _this = this;
        this.commentsService.getComments()
            .subscribe(function (comments) { return _this.comments = comments; }, function (error) { return _this.errorMessage = error; });
    };
    CommentsAdministrationComponent.prototype.deleteComment = function (commentId) {
        var _this = this;
        this.commentsService.deleteComment(commentId)
            .subscribe(function (result) {
            console.log(result);
            _this.comments = _this.comments.filter(function (comment) { return (comment.id !== commentId); });
        }, function (error) { return _this.errorMessage = error; });
    };
    CommentsAdministrationComponent = __decorate([
        core_1.Component({
            selector: 'my-app',
            templateUrl: 'app/administration/comments.html',
            providers: [comments_service_1.CommentsService]
        }), 
        __metadata('design:paramtypes', [comments_service_1.CommentsService])
    ], CommentsAdministrationComponent);
    return CommentsAdministrationComponent;
}());
exports.CommentsAdministrationComponent = CommentsAdministrationComponent;
//# sourceMappingURL=comments-administration.component.js.map