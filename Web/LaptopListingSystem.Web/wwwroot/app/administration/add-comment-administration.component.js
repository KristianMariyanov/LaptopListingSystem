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
var comment_1 = require('../comment');
var comments_service_1 = require('../services/administration/comments.service');
var AddCommentAdministrationComponent = (function () {
    function AddCommentAdministrationComponent(commentsService, router) {
        this.commentsService = commentsService;
        this.router = router;
        this.comment = new comment_1.Comment();
    }
    AddCommentAdministrationComponent.prototype.ngOnInit = function () { };
    AddCommentAdministrationComponent.prototype.addComment = function () {
        var _this = this;
        this.commentsService.addComment(this.comment.content, this.comment.laptopId, this.comment.author)
            .subscribe(function (result) {
            _this.router.navigate(['/administration/comments']);
        }, function (error) { return _this.errorMessage = error; });
    };
    AddCommentAdministrationComponent = __decorate([
        core_1.Component({
            selector: 'my-app',
            templateUrl: 'app/administration/add-comment.html',
            providers: [comments_service_1.CommentsService]
        }), 
        __metadata('design:paramtypes', [comments_service_1.CommentsService, router_1.Router])
    ], AddCommentAdministrationComponent);
    return AddCommentAdministrationComponent;
}());
exports.AddCommentAdministrationComponent = AddCommentAdministrationComponent;
//# sourceMappingURL=add-comment-administration.component.js.map