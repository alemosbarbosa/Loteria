var app;
(function (app) {
    var Config = (function () {
        function Config($routeProvider) {
            $routeProvider
                .when("/", {
                templateUrl: "/app/posts/list.html",
                controller: "PostsCtrl as vm"
            })
                .when("/edit/:id", {
                templateUrl: "/app/posts/edit.html",
                controller: "PostEditCtrl as vm"
            })
                .when("/add", {
                templateUrl: "/app/posts/add.html",
                controller: "PostAddCtrl as vm"
            })
                .otherwise({ redirectTo: '/' });
        }
        return Config;
    }());
    Config.$inject = ['$routeProvider'];
    var mainApp = angular.module('chsakellBlogApp', ['ngRoute']);
    mainApp.config(Config);
})(app || (app = {}));
//# sourceMappingURL=app.js.map