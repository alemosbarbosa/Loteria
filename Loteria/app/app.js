var app;
(function (app) {
    var Config = (function () {
        function Config($routeProvider) {
            $routeProvider
                .when("/", {
                templateUrl: "/app/aposta/index.html",
                controller: "ApostaCtrl as vm"
            })
                .when("/sorteio", {
                templateUrl: "/app/sorteio/index.html",
                controller: "SorteioCtrl as vm"
            })
                .otherwise({ redirectTo: '/' });
        }
        return Config;
    }());
    Config.$inject = ['$routeProvider'];
    var mainApp = angular.module('loteriaApp', ['ngRoute']);
    mainApp.config(Config);
})(app || (app = {}));
//# sourceMappingURL=app.js.map