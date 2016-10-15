"use strict";
var router_1 = require('@angular/router');
var home_component_1 = require("./home/home.component");
var laptop_details_component_1 = require("./laptops/laptop-details.component");
var login_component_1 = require("./login/login.component");
var appRoutes = [
    { path: 'home', component: home_component_1.HomeComponent },
    { path: '', redirectTo: 'home', pathMatch: "full" },
    { path: 'laptops/:id', component: laptop_details_component_1.LaptopDetailsComponent },
    { path: 'login', component: login_component_1.LoginComponent },
];
exports.routing = router_1.RouterModule.forRoot(appRoutes);
//# sourceMappingURL=app.routes.js.map