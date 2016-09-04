module app.apostaList {

    interface IApostaViewModel {
        apostas: app.domain.IAposta[];
        remove(Id: number): void;
    }

    class ApostaCtrl implements IApostaViewModel {

        apostas: app.domain.IAposta[];

        static $inject = ['constantService', 'dataService'];
        constructor(private constantService: app.common.services.ConstantService,
            private dataService: app.common.services.DataService) {
            this.getAposta();
        }

        remove(Id: number): void {
            var self = this; 

            this.dataService.remove(this.constantService.apiApostaURI + Id)
                .then(function (result) {
                    self.getAposta();
                });
        }

        getAposta(): void {
            this.dataService.get(this.constantService.apiApostaURI).then((result: app.domain.IAposta[]) => {
                this.apostas = result;
            });
        }
    }
    angular.module('apostaApp')
        .controller('ApostaCtrl', ApostaCtrl);
}