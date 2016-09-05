var app;
(function (app) {
    var sorteio;
    (function (sorteio) {
        var kTipoSorteio = 1;
        var kOpcaoAutomatica = "automatica";
        var kOpcaoManual = "manual";
        var NumeroSorteio = (function () {
            function NumeroSorteio() {
            }
            return NumeroSorteio;
        }());
        var SorteioCtrl = (function () {
            function SorteioCtrl(constantService, dataService) {
                this.constantService = constantService;
                this.dataService = dataService;
                this.idTipoSorteioCorrente = kTipoSorteio;
                this.numerosSorteio = [];
                this.opcaoDeSorteio = kOpcaoAutomatica;
                this.getTiposSorteio();
            }
            SorteioCtrl.prototype.getSorteioCorrente = function () {
                var _this = this;
                var numSorteioCorrente = this.tipoSorteioCorrente.NumSorteioCorrente;
                var apiSorteioCorrente = this.constantService.apiSorteioURI + "corrente/" + this.idTipoSorteioCorrente + "/" + numSorteioCorrente;
                this.dataService.getSingle(apiSorteioCorrente).then(function (result) {
                    _this.sorteioCorrente = result;
                    _this.numSorteioSelecionado = _this.sorteioCorrente.NumSorteio;
                    _this.statusCorrente = _this.statusSorteio.filter(function (x) { return x.CodStatus === _this.sorteioCorrente.CodStatus; })[0];
                });
            };
            SorteioCtrl.prototype.getStatusSorteio = function () {
                var _this = this;
                var self = this;
                this.dataService.get(this.constantService.apiStatusSorteioURI).then(function (result) {
                    _this.statusSorteio = result;
                    self.getSorteios();
                });
            };
            SorteioCtrl.prototype.getTiposSorteio = function () {
                var _this = this;
                var self = this;
                this.dataService.get(this.constantService.apiTipoSorteioURI).then(function (result) {
                    _this.tiposSorteio = result;
                    _this.tipoSorteioCorrente = _this.tiposSorteio.filter(function (x) { return x.Id == _this.idTipoSorteioCorrente; })[0];
                    self.getStatusSorteio();
                });
            };
            SorteioCtrl.prototype.getSorteios = function () {
                var _this = this;
                var self = this;
                var apiSorteiosPTipo = this.constantService.apiSorteioURI + "portipo/" + this.idTipoSorteioCorrente;
                this.dataService.get(apiSorteiosPTipo).then(function (result) {
                    _this.sorteios = result;
                    self.getSorteioCorrente();
                });
            };
            SorteioCtrl.prototype.buscarSorteio = function () {
                var _this = this;
                var self = this;
                var apiSorteio = this.constantService.apiSorteioURI + this.idSorteioSelecionado;
                this.dataService.getSingle(apiSorteio).then(function (result) {
                    _this.sorteioSelecionado = result;
                    _this.tipoSorteioSelecionado = _this.tiposSorteio.filter(function (x) { return x.Id == _this.sorteioSelecionado.IdTipo; })[0];
                    _this.statusSelecionado = _this.statusSorteio.filter(function (x) { return x.CodStatus == _this.sorteioSelecionado.CodStatus; })[0];
                    var qtdNumerosSorteio = _this.tipoSorteioSelecionado.MinNumerosPorJogo;
                    var numeros = [];
                    for (var i = 0; i < qtdNumerosSorteio; ++i) {
                        numeros.push({
                            "Posicao": i + 1,
                            "Valor": null
                        });
                    }
                    _this.numerosSorteio = numeros;
                    _this.atualizaControles();
                    if (_this.sorteioSelecionado.CodStatus == 3) {
                        self.buscaAcertos();
                    }
                });
            };
            SorteioCtrl.prototype.buscaAcertos = function () {
                var _this = this;
                var self = this;
                var apiAcertosPSorteio = this.constantService.apiAcertoURI + "porsorteio/" + this.sorteioSelecionado.Id;
                this.dataService.get(apiAcertosPSorteio).then(function (result) {
                    _this.acertos = result;
                    self.atualizaControles();
                });
            };
            SorteioCtrl.prototype.processaRequisicao = function () {
            };
            SorteioCtrl.prototype.atualizaControles = function () {
                this.temAcertador = this.acertos && this.acertos.length > 0;
                this.podeSortear = this.statusSelecionado && this.statusSelecionado.CodStatus == 1; // Status: Aberto
                this.podeProcessar = this.statusSelecionado && this.statusSelecionado.CodStatus == 2; // Status: Fechado
                this.jaProcessado = this.statusSelecionado && this.statusSelecionado.CodStatus == 3; // Status: Processado
                this.mostraNaoTemAcertador = this.jaProcessado && !this.temAcertador;
                this.exibeTabelaAcertadores = this.jaProcessado && this.temAcertador;
            };
            //temAcertador(): boolean {
            //    return this.acertos && this.acertos.length > 0;
            //}
            //mostraNaoTemAcertador(): boolean {
            //    return this.jaProcessado() && !this.temAcertador()
            //}
            //exibeTabelaAcertadores(): boolean {
            //    return this.jaProcessado() && this.temAcertador()
            //}
            //podeSortear(): boolean {
            //    return this.statusSelecionado && this.statusSelecionado.CodStatus == 1; // Status: Aberto
            //}
            //podeProcessar(): boolean {
            //    return this.statusSelecionado && this.statusSelecionado.CodStatus == 2; // Status: Fechado
            //}
            //jaProcessado(): boolean {
            //    return this.statusSelecionado && this.statusSelecionado.CodStatus == 3; // Status: Processado
            //}
            SorteioCtrl.prototype.geraNumerosSorteados = function () {
                var ret = "";
                if (this.sorteioSelecionado && this.sorteioSelecionado.Numeros) {
                    var numerosOrdenados = this.sorteioSelecionado.Numeros.sort(function (n1, n2) { return n1 - n2; });
                    for (var i = 0; i < numerosOrdenados.length; ++i) {
                        ret += numerosOrdenados[i] + " ";
                    }
                }
                return ret;
            };
            SorteioCtrl.$inject = ['constantService', 'dataService'];
            return SorteioCtrl;
        }());
        angular.module('loteriaApp')
            .controller('SorteioCtrl', SorteioCtrl);
    })(sorteio = app.sorteio || (app.sorteio = {}));
})(app || (app = {}));
