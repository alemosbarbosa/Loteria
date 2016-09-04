module app {
    class Config {
        constructor($routeProvider: ng.route.IRouteProvider) {
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
    }
    Config.$inject = ['$routeProvider'];

    var mainApp = angular.module('loteriaApp', ['ngRoute']);
    mainApp.config(Config);
}