module app.domain {
    export interface ITipoAcerto {
        Id?: number;
        IdTipo: number;
        Descricao: string;
        QtdNumerosAcertados: number;
    }

    export class TipoAcerto extends app.domain.EntityBase implements ITipoAcerto {
        constructor(public IdTipo: number,
            public Descricao: string,
            public QtdNumerosAcertados: number,
            public Id?: number) {

            super();

            this.Id = Id;
            this.IdTipo = IdTipo;
            this.Descricao = Descricao;
            this.QtdNumerosAcertados = QtdNumerosAcertados;
        }
    }
}