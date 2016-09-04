var app;
(function (app) {
    var apostaList;
    (function (apostaList) {
        var ApostaCtrl = (function () {
            function ApostaCtrl(constantService, dataService) {
                this.constantService = constantService;
                this.dataService = dataService;
                this.getAposta();
            }
            ApostaCtrl.prototype.remove = function (Id) {
                var self = this;
                this.dataService.remove(this.constantService.apiApostaURI + Id)
                    .then(function (result) {
                    self.getAposta();
                });
            };
            ApostaCtrl.prototype.getAposta = function () {
                var _this = this;
                this.dataService.get(this.constantService.apiApostaURI).then(function (result) {
                    _this.apostas = result;
                });
            };
            ApostaCtrl.$inject = ['constantService', 'dataService'];
            return ApostaCtrl;
        }());
        angular.module('apostaApp')
            .controller('ApostaCtrl', ApostaCtrl);
    })(apostaList = app.apostaList || (app.apostaList = {}));
})(app || (app = {}));
//# sourceMappingURL=apostaCtrl.js.map