var app;
(function (app) {
    var common;
    (function (common) {
        var services;
        (function (services) {
            var ConstantService = (function () {
                function ConstantService() {
                    this.apiApostaURI = '/api/aposta/';
                    this.apiApostadorURI = '/api/apostador/';
                    this.apiSorteioURI = '/api/sorteio/';
                    this.apiStatusSorteioURI = '/api/statussorteio/';
                    this.apiTipoAcertoURI = '/api/tipoacerto/';
                    this.apiTipoSorteioURI = '/api/tiposorteio/';
                }
                return ConstantService;
            }());
            services.ConstantService = ConstantService;
            angular.module('loteriaApp')
                .service('constantService', ConstantService);
        })(services = common.services || (common.services = {}));
    })(common = app.common || (app.common = {}));
})(app || (app = {}));
//# sourceMappingURL=constantService.js.map