module app.aposta {

    interface IApostaViewModel {
        apostas: app.domain.IAposta[];
        idTipoSorteioCorrente: number;
        sorteioCorrente: app.domain.ISorteio;
        apostador: app.domain.IApostador;
        numSorteioSelecionado: number;
        statusSorteio: app.domain.IStatusSorteio[];
        statusCorrente: app.domain.IStatusSorteio;
        nomeApostador: string;
        apostasApostador: app.domain.IAposta[];
        tiposSorteio: app.domain.ITipoSorteio[];
        tipoSorteioCorrente: app.domain.ITipoSorteio;
        numerosAposta: NumeroAposta[];
        opcaoDeJogo: string;
    }

    const kTipoSorteio: number = 1;
    const kOpcaoAutomatica: string = "automatica";
    const kOpcaoManual: string = "manual";

    class NumeroAposta {
        public Posicao: number;
        public Valor: number;
    }

    class ApostaCtrl implements IApostaViewModel {

        idTipoSorteioCorrente: number = kTipoSorteio;
        sorteioCorrente: app.domain.ISorteio;
        apostador: app.domain.IApostador;
        apostas: app.domain.IAposta[];
        numSorteioSelecionado: number;
        statusSorteio: app.domain.IStatusSorteio[];
        statusCorrente: app.domain.IStatusSorteio;
        nomeApostador: string;
        apostasApostador: app.domain.IAposta[];
        tiposSorteio: app.domain.ITipoSorteio[];
        tipoSorteioCorrente: app.domain.ITipoSorteio;
        numerosAposta: NumeroAposta[] = [];
        opcaoDeJogo: string = kOpcaoManual;

        static $inject = ['constantService', 'dataService'];
        constructor(private constantService: app.common.services.ConstantService,
            private dataService: app.common.services.DataService) {
            this.getTiposSorteio();
        }

 
        getAposta(): void {
            this.dataService.get(this.constantService.apiApostaURI).then((result: app.domain.IAposta[]) => {
                this.apostas = result;
            });
        }

        getSorteioCorrente(): void {
            var numSorteioCorrente = this.tipoSorteioCorrente.NumSorteioCorrente;
            var apiSorteioCorrente = this.constantService.apiSorteioURI + "corrente/" + this.idTipoSorteioCorrente + "/" + numSorteioCorrente;
            this.dataService.getSingle(apiSorteioCorrente).then((result: app.domain.ISorteio) => {
                this.sorteioCorrente = result;
                this.numSorteioSelecionado = this.sorteioCorrente.NumSorteio;
                this.statusCorrente = this.statusSorteio.filter(x => x.CodStatus === this.sorteioCorrente.CodStatus)[0];
            });
        }

        getStatusSorteio(): void {
            var self = this;
            this.dataService.get(this.constantService.apiStatusSorteioURI).then((result: app.domain.IStatusSorteio[]) => {
                this.statusSorteio = result;
                self.getSorteioCorrente();
            });
        }

        getTiposSorteio(): void {
            var self = this;
            this.dataService.get(this.constantService.apiTipoSorteioURI).then((result: app.domain.ITipoSorteio[]) => {
                this.tiposSorteio = result;
                this.tipoSorteioCorrente = this.tiposSorteio.filter(x => x.Id == this.idTipoSorteioCorrente)[0];
                self.getStatusSorteio();
            });
        }

        jogar(): void {
            this.obtemApostador();
        }

        obtemApostador(): void {
            var self = this;
            var apiApostadorPNome = this.constantService.apiApostadorURI + "pornome/" + this.nomeApostador;
            this.dataService.getSingle(apiApostadorPNome).then((result: app.domain.IApostador) => {
                self.buscaDadosApostador(result);
            }, (reason) => {
                if (typeof (reason) !== "undefined" && typeof (reason.status) !== "undefined" &&
                    reason.status === 404) {
                    self.cadastraApostador();
                }
            });
        }

        cadastraApostador(): void {
            var self = this;
            let apostador_ = { "Nome": this.nomeApostador };
            this.dataService.add(this.constantService.apiApostadorURI, apostador_)
                .then((result: app.domain.IApostador) => {
                    self.buscaDadosApostador(result);
                });
        }

        buscaDadosApostador(apostador: app.domain.IApostador): void {
            this.apostador = apostador;
            var apiApostasApostador = this.constantService.apiApostaURI + "porapostador/" + apostador.Id;
            this.dataService.get(apiApostasApostador).then((result: app.domain.IAposta[]) => {
                this.apostasApostador = result;
                var qtdNumerosAposta = this.tipoSorteioCorrente.MinNumerosPorJogo;
                var numeros: NumeroAposta[] = [];
                for (var i = 0; i < qtdNumerosAposta; ++i) {
                    numeros.push({
                        "Posicao": i + 1,
                        "Valor": null
                    });
                }
                this.numerosAposta = numeros;
            });
        }

        geraColunaNumeros(numeros: number[]): string {
            let ret: string = "";
            var numerosOrdenados = numeros.sort((n1, n2) => n1 - n2);
            for (var i = 0; i < numerosOrdenados.length; ++i) {
                ret += numerosOrdenados[i] + " ";
            }
            return ret;
        }

        apostadorTemApostas(): boolean {
            return this.apostasApostador && this.apostasApostador.length > 0;
        }

        registraAposta(): void {
            var apostaAutomatica = this.opcaoDeJogo == kOpcaoAutomatica;
            var numeros: number[] = apostaAutomatica ? [] : this.numerosAposta.map(x => x.Valor).filter(y => y != null);
            var aposta: app.domain.IAposta = {
                "IdApostador": this.apostador.Id,
                "IdSorteio": this.sorteioCorrente.Id,
                "Numeros": numeros,
                "ApostaAutomatica": apostaAutomatica
                };
            this.dataService.add(this.constantService.apiApostaURI, aposta)
                .then((result: app.domain.IAposta) => {
                    this.apostasApostador.push(result);
                    for (var i in this.numerosAposta) {
                        this.numerosAposta[i].Valor = null;
                    }
                }, (reason) => {
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
        }
    }
    angular.module('loteriaApp')
        .controller('ApostaCtrl', ApostaCtrl);
}