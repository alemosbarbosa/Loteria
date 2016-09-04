module app.domain {
    export interface ITipoSorteio {
        Id?: number;
        Descricao: string;
        NumSorteioCorrente?: number;
    }

    export class TipoSorteio extends app.domain.EntityBase implements ITipoSorteio {
        constructor(public Descricao: string,
            public Id?: number,
            public NumSorteioCorrente?: number) {

            super();

            this.Id = Id;
            this.Descricao = Descricao;
            this.NumSorteioCorrente = NumSorteioCorrente;
        }
    }
}