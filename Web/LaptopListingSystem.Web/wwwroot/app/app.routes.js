"use strict";
var router_1 = require('@angular/router');
//import { AppComponent } from  "./app.component";
var home_component_1 = require("./home/home.component");
var routes = [
    {
        path: "home",
        component: home_component_1.HomeComponent
    }
];
exports.appRouterProviders = [
    router_1.provideRouter(routes)
];
//# sourceMappingURL=app.routes.js.map