module app {
    class Config {
        constructor($routeProvider: ng.route.IRouteProvider) {
            $routeProvider
                .when("/aposta", {
                    templateUrl: "/app/aposta/aposta.html",
                    controller: "ApostaCtrl as vm"
                })
                .when("/", {
                    templateUrl: "/app/sorteio/sorteio.html",
                    controller: "SorteioCtrl as vm"
                })
                .otherwise({ redirectTo: '/' });
        }
    }
    Config.$inject = ['$routeProvider'];

    var mainApp = angular.module('loteriaApp', ['ngRoute']);
    mainApp.config(Config);
}