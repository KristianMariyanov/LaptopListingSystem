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
var EditCommentAdministrationComponent = (function () {
    function EditCommentAdministrationComponent(commentsService, route, router) {
        this.commentsService = commentsService;
        this.route = route;
        this.router = router;
        this.comment = new comment_1.Comment();
        console.log('constructor');
    }
    EditCommentAdministrationComponent.prototype.ngOnInit = function () {
        var _this = this;
        console.log('init');
        this.route.params.forEach(function (params) {
            var id = +params['id'];
            var comment = _this.commentsService.getComment(id);
            console.log(comment);
            comment.subscribe(function (comment) { return _this.comment = comment; }, function (error) { return _this.errorMessage = error; });
        });
    };
    EditCommentAdministrationComponent.prototype.updateComment = function () {
        var _this = this;
        this.commentsService.updateComment(this.comment.content, this.comment.laptopId, this.comment.author, this.comment.id)
            .subscribe(function (result) {
            _this.router.navigate(['/administration/comments']);
        }, function (error) { return _this.errorMessage = error; });
    };
    EditCommentAdministrationComponent = __decorate([
        core_1.Component({
            selector: 'my-app',
            templateUrl: 'app/administration/edit-comment.html',
            providers: [comments_service_1.CommentsService]
        }), 
        __metadata('design:paramtypes', [comments_service_1.CommentsService, router_1.ActivatedRoute, router_1.Router])
    ], EditCommentAdministrationComponent);
    return EditCommentAdministrationComponent;
}());
exports.EditCommentAdministrationComponent = EditCommentAdministrationComponent;
//# sourceMappingURL=edit-comment-administration.component.js.map