var app;
(function (app) {
    var aposta;
    (function (aposta_1) {
        var kTipoSorteio = 1;
        var kOpcaoAutomatica = "automatica";
        var kOpcaoManual = "manual";
        var NumeroAposta = (function () {
            function NumeroAposta() {
            }
            return NumeroAposta;
        }());
        var ApostaCtrl = (function () {
            function ApostaCtrl(constantService, dataService) {
                this.constantService = constantService;
                this.dataService = dataService;
                this.idTipoSorteioCorrente = kTipoSorteio;
                this.numerosAposta = [];
                this.opcaoDeJogo = kOpcaoManual;
                this.getTiposSorteio();
            }
            ApostaCtrl.prototype.getAposta = function () {
                var _this = this;
                this.dataService.get(this.constantService.apiApostaURI).then(function (result) {
                    _this.apostas = result;
                });
            };
            ApostaCtrl.prototype.getSorteioCorrente = function () {
                var _this = this;
                var numSorteioCorrente = this.tipoSorteioCorrente.NumSorteioCorrente;
                var apiSorteioCorrente = this.constantService.apiSorteioURI + "corrente/" + this.idTipoSorteioCorrente + "/" + numSorteioCorrente;
                this.dataService.getSingle(apiSorteioCorrente).then(function (result) {
                    _this.sorteioCorrente = result;
                    _this.numSorteioSelecionado = _this.sorteioCorrente.NumSorteio;
                    _this.statusCorrente = _this.statusSorteio.filter(function (x) { return x.CodStatus === _this.sorteioCorrente.CodStatus; })[0];
                });
            };
            ApostaCtrl.prototype.getStatusSorteio = function () {
                var _this = this;
                var self = this;
                this.dataService.get(this.constantService.apiStatusSorteioURI).then(function (result) {
                    _this.statusSorteio = result;
                    self.getSorteioCorrente();
                });
            };
            ApostaCtrl.prototype.getTiposSorteio = function () {
                var _this = this;
                var self = this;
                this.dataService.get(this.constantService.apiTipoSorteioURI).then(function (result) {
                    _this.tiposSorteio = result;
                    _this.tipoSorteioCorrente = _this.tiposSorteio.filter(function (x) { return x.Id == _this.idTipoSorteioCorrente; })[0];
                    self.getStatusSorteio();
                });
            };
            ApostaCtrl.prototype.jogar = function () {
                this.obtemApostador();
            };
            ApostaCtrl.prototype.obtemApostador = function () {
                var self = this;
                var apiApostadorPNome = this.constantService.apiApostadorURI + "pornome/" + this.nomeApostador;
                this.dataService.getSingle(apiApostadorPNome).then(function (result) {
                    self.buscaDadosApostador(result);
                }, function (reason) {
                    if (typeof (reason) !== "undefined" && typeof (reason.status) !== "undefined" &&
                        reason.status === 404) {
                        self.cadastraApostador();
                    }
                });
            };
            ApostaCtrl.prototype.cadastraApostador = function () {
                var self = this;
                var apostador_ = { "Nome": this.nomeApostador };
                this.dataService.add(this.constantService.apiApostadorURI, apostador_)
                    .then(function (result) {
                    self.buscaDadosApostador(result);
                });
            };
            ApostaCtrl.prototype.buscaDadosApostador = function (apostador) {
                var _this = this;
                this.apostador = apostador;
                var apiApostasApostador = this.constantService.apiApostaURI + "porapostador/" + apostador.Id;
                this.dataService.get(apiApostasApostador).then(function (result) {
                    _this.apostasApostador = result;
                    var qtdNumerosAposta = _this.tipoSorteioCorrente.MinNumerosPorJogo;
                    var numeros = [];
                    for (var i = 0; i < qtdNumerosAposta; ++i) {
                        numeros.push({
                            "Posicao": i + 1,
                            "Valor": null
                        });
                    }
                    _this.numerosAposta = numeros;
                });
            };
            ApostaCtrl.prototype.geraColunaNumeros = function (numeros) {
                var ret = "";
                var numerosOrdenados = numeros.sort(function (n1, n2) { return n1 - n2; });
                for (var i = 0; i < numerosOrdenados.length; ++i) {
                    ret += numerosOrdenados[i] + " ";
                }
                return ret;
            };
            ApostaCtrl.prototype.apostadorTemApostas = function () {
                return this.apostasApostador && this.apostasApostador.length > 0;
            };
            ApostaCtrl.prototype.registraAposta = function () {
                var _this = this;
                var apostaAutomatica = this.opcaoDeJogo == kOpcaoAutomatica;
                var numeros = apostaAutomatica ? [] : this.numerosAposta.map(function (x) { return x.Valor; }).filter(function (y) { return y != null; });
                var aposta = {
                    "IdApostador": this.apostador.Id,
                    "IdSorteio": this.sorteioCorrente.Id,
                    "Numeros": numeros,
                    "ApostaAutomatica": apostaAutomatica
                };
                this.dataService.add(this.constantService.apiApostaURI, aposta)
                    .then(function (result) {
                    _this.apostasApostador.push(result);
                    for (var i in _this.numerosAposta) {
                        _this.numerosAposta[i].Valor = null;
                    }
                }, function (reason) {
                    if (typeof (reason) !== "undefined" && typeof (reason.status) !== "undefined" &&
                        reason.status === 400) {
                        if (typeof (reason.data) !== "undefined" && typeof (reason.data.Message) != "undefined") {
                            alert(reason.data.Message);
                        }
                    }
                    else {
                        alert("Ocorreu um erro no processamento da requisição");
                    }
                });
            };
            ApostaCtrl.$inject = ['constantService', 'dataService'];
            return ApostaCtrl;
        }());
        angular.module('loteriaApp')
            .controller('ApostaCtrl', ApostaCtrl);
    })(aposta = app.aposta || (app.aposta = {}));
})(app || (app = {}));
