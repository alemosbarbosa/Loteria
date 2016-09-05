module app {
    class Config {
        constructor($routeProvider: angular.route.IRouteProvider) {
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
    }
    Config.$inject = ['$routeProvider'];

    var mainApp = angular.module('loteriaApp', ['ngRoute']);
    mainApp.config(Config);
}