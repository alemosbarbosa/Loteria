var app;
(function (app) {
    var Config = (function () {
        function Config($routeProvider) {
            $routeProvider
                .when("/aposta", {
                templateUrl: "/app/aposta/aposta.html",
                controller: "ApostaCtrl as vm"
            })
                .when("/sorteio", {
                templateUrl: "/app/sorteio/sorteio.html",
                controller: "SorteioCtrl as vm"
            })
                .otherwise({ redirectTo: '/aposta' });
        }
        return Config;
    }());
    Config.$inject = ['$routeProvider'];
    var mainApp = angular.module('loteriaApp', ['ngRoute']);
    mainApp.config(Config);
})(app || (app = {}));
