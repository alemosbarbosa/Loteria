module app.common.services {

    interface IConstant {
        apiApostaURI: string;
        apiApostadorURI: string;
        apiSorteioURI: string;
        apiStatusSorteioURI: string;
        apiTipoAcertoURI: string;
        apiTipoSorteioURI: string;
    }

    export class ConstantService implements IConstant {
        apiApostaURI: string;
        apiApostadorURI: string;
        apiSorteioURI: string;
        apiStatusSorteioURI: string;
        apiTipoAcertoURI: string;
        apiTipoSorteioURI: string;

        constructor() {
            this.apiApostaURI = '/api/aposta/';
            this.apiApostadorURI = '/api/apostador/';
            this.apiSorteioURI = '/api/sorteio/';
            this.apiStatusSorteioURI = '/api/statussorteio/';
            this.apiTipoAcertoURI = '/api/tipoacerto/';
            this.apiTipoSorteioURI = '/api/tiposorteio/';
        }
    }

    angular.module('loteriaApp')
        .service('constantService', ConstantService);
}