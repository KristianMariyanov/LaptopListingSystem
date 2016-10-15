"use strict";
var router_1 = require('@angular/router');
var home_component_1 = require("./home/home.component");
var laptop_details_component_1 = require("./laptops/laptop-details.component");
var login_component_1 = require("./login/login.component");
var comments_administration_component_1 = require("./administration/comments-administration.component");
var edit_comment_administration_component_1 = require("./administration/edit-comment-administration.component");
var add_comment_administration_component_1 = require("./administration/add-comment-administration.component");
var manufacturers_administration_component_1 = require("./administration/manufacturers-administration.component");
var edit_manufacturer_administration_component_1 = require("./administration/edit-manufacturer-administration.component");
var add_manufacturer_administration_component_1 = require("./administration/add-manufacturer-administration.component");
var appRoutes = [
    { path: 'home', component: home_component_1.HomeComponent },
    { path: '', redirectTo: 'home', pathMatch: "full" },
    { path: 'laptops/:id', component: laptop_details_component_1.LaptopDetailsComponent },
    { path: 'login', component: login_component_1.LoginComponent },
    { path: 'administration/comments', component: comments_administration_component_1.CommentsAdministrationComponent },
    { path: 'administration/comments/edit/:id', component: edit_comment_administration_component_1.EditCommentAdministrationComponent },
    { path: 'administration/comments/add', component: add_comment_administration_component_1.AddCommentAdministrationComponent },
    { path: 'administration/manufacturers', component: manufacturers_administration_component_1.ManufacturersAdministrationComponent },
    { path: 'administration/manufacturers/edit/:id', component: edit_manufacturer_administration_component_1.EditManufacturerAdministrationComponent },
    { path: 'administration/manufacturers/add', component: add_manufacturer_administration_component_1.AddManufacturerAdministrationComponent },
];
exports.routing = router_1.RouterModule.forRoot(appRoutes);
//# sourceMappingURL=app.routes.js.map