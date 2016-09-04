module app.domain {
    export interface IStatusSorteio {
        CodStatus: number;
        Descricao: string;
        NumSorteioCorrente?: number;
    }

    export class StatusSorteio extends app.domain.EntityBase implements IStatusSorteio {
        constructor(public CodStatus: number,
            public Descricao: string) {

            super();

            this.CodStatus = CodStatus;
            this.Descricao = Descricao;
        }
    }
}