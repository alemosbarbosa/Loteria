module app.sorteio {
    interface ISorteioViewModel {
        sorteios: app.domain.ISorteio[];
    }

    const kTipoSorteio: number = 1;
    const kOpcaoAutomatica: string = "automatica";
    const kOpcaoManual: string = "manual";

    class NumeroSorteio {
        public Posicao: number;
        public Valor: number;
    }

    class SorteioCtrl implements ISorteioViewModel {
        sorteios: app.domain.ISorteio[];
        idTipoSorteioCorrente: number = kTipoSorteio;
        sorteioCorrente: app.domain.ISorteio;
        numSorteioSelecionado: number;
        statusSorteio: app.domain.IStatusSorteio[];
        statusCorrente: app.domain.IStatusSorteio;
        statusSelecionado: app.domain.IStatusSorteio;
        apostasApostador: app.domain.IAposta[];
        tiposSorteio: app.domain.ITipoSorteio[];
        tipoSorteioCorrente: app.domain.ITipoSorteio;
        tipoSorteioSelecionado: app.domain.ITipoSorteio;
        numerosSorteio: NumeroSorteio[] = [];
        opcaoDeSorteio: string = kOpcaoAutomatica;
        idSorteioSelecionado: number;
        sorteioSelecionado: app.domain.ISorteio;
        acertos: app.domain.IAcerto[];
        temAcertador: boolean;
        podeSortear: boolean;
        podeProcessar: boolean;
        jaProcessado: boolean;
        mostraNaoTemAcertador: boolean;
        exibeTabelaAcertadores: boolean;
        podeCriar: boolean;

        static $inject = ['constantService', 'dataService'];
        constructor(private constantService: app.common.services.ConstantService,
            private dataService: app.common.services.DataService) {
            this.getTiposSorteio();
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
                self.getSorteios();
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

        getSorteios(): void {
            var self = this;
            var apiSorteiosPTipo = this.constantService.apiSorteioURI + "portipo/" + this.idTipoSorteioCorrente;
            this.dataService.get(apiSorteiosPTipo).then((result: app.domain.ISorteio[]) => {
                this.sorteios = result;
                self.getSorteioCorrente();
            });
        }

        buscarSorteio(): void {
            var self = this;
            var apiSorteio = this.constantService.apiSorteioURI + this.idSorteioSelecionado;
            this.dataService.getSingle(apiSorteio).then((result: app.domain.ISorteio) => {
                this.sorteioSelecionado = result; 
                this.tipoSorteioSelecionado = this.tiposSorteio.filter(x => x.Id == this.sorteioSelecionado.IdTipo)[0];
                this.statusSelecionado = this.statusSorteio.filter(x => x.CodStatus == this.sorteioSelecionado.CodStatus)[0];
                var qtdNumerosSorteio = this.tipoSorteioSelecionado.MinNumerosPorJogo;
                var numeros: NumeroSorteio[] = [];
                for (var i = 0; i < qtdNumerosSorteio; ++i) {
                    numeros.push({
                        "Posicao": i + 1,
                        "Valor": null
                    });
                }
                this.numerosSorteio = numeros;
                this.atualizaControles();
                if (this.sorteioSelecionado.CodStatus == 3)
                {
                    self.buscaAcertos();
                }
            });
        }

        buscaAcertos(): void {
            var self = this;
            var apiAcertosPSorteio = this.constantService.apiAcertoURI + "porsorteio/" + this.sorteioSelecionado.Id;
            this.dataService.get(apiAcertosPSorteio).then((result: app.domain.IAcerto[]) => {
                this.acertos = result;
                self.atualizaControles();
            });
        }

        sortear(): void {
            var sorteioAutomatico = this.opcaoDeSorteio == kOpcaoAutomatica;
            var numeros: number[] = sorteioAutomatico ? [] : this.numerosSorteio.map(x => x.Valor).filter(y => y != null);
            this.sorteioCorrente.Numeros = numeros;
            var apiSorteioUpdate = this.constantService.apiSorteioURI + this.sorteioCorrente.Id;
            this.dataService.update(apiSorteioUpdate, this.sorteioCorrente)
                .then((result: app.domain.ISorteio) => {
                    this.sorteioCorrente = result;
                    this.statusCorrente = this.statusSorteio.filter(x => x.CodStatus == this.sorteioCorrente.CodStatus)[0];
                    this.atualizaControles();
                },
                (reason) => {
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

        processar(): void {
            var apiSorteioProcessa = this.constantService.apiSorteioURI + "processa/" + this.sorteioCorrente.Id;
            this.dataService.getSingle(apiSorteioProcessa)
                .then((result: app.domain.ISorteio) => {
                    this.sorteioCorrente = result;
                    this.statusCorrente = this.statusSorteio.filter(x => x.CodStatus == this.sorteioCorrente.CodStatus)[0];
                    this.atualizaControles();
                },
                (reason) => {
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

        atualizaControles(): void {
            this.temAcertador = this.acertos && this.acertos.length > 0;
            this.podeSortear = this.statusSelecionado && this.statusSelecionado.CodStatus == 1; // Status: Aberto
            this.podeProcessar = this.statusSelecionado && this.statusSelecionado.CodStatus == 2; // Status: Fechado
            this.jaProcessado = this.statusSelecionado && this.statusSelecionado.CodStatus == 3; // Status: Processado
            this.mostraNaoTemAcertador = this.jaProcessado && !this.temAcertador;
            this.exibeTabelaAcertadores = this.jaProcessado && this.temAcertador;
            this.podeCriar = this.sorteioCorrente && this.sorteioCorrente.CodStatus == 3;
        }

        geraNumerosSorteados(): string {
            let ret: string = "";
            if (this.sorteioSelecionado && this.sorteioSelecionado.Numeros) {
                var numerosOrdenados = this.sorteioSelecionado.Numeros.sort((n1, n2) => n1 - n2);
                for (var i = 0; i < numerosOrdenados.length; ++i) {
                    ret += numerosOrdenados[i] + " ";
                }
            }
            return ret;
        }

        criarSorteio(): void {
            if (this.sorteioCorrente && this.sorteioCorrente.CodStatus == 3) {
                let sorteio = {
                    "IdTipo": this.tipoSorteioCorrente.Id
                    };
                this.dataService.add(this.constantService.apiSorteioURI, sorteio)
                    .then((result: app.domain.ISorteio) => {
                        this.sorteioCorrente = result;
                        this.statusCorrente = this.statusSorteio.filter(x => x.CodStatus == this.sorteioCorrente.CodStatus)[0];
                        this.sorteios.push(this.sorteioCorrente);
                        this.atualizaControles();
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
    }
    angular.module('loteriaApp')
        .controller('SorteioCtrl', SorteioCtrl);
}