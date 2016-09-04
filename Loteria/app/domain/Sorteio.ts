module app.domain {
    export interface ISorteio {
        Id?: number;
        IdTipo: number;
        NumSorteio?: number;
        DhCriacao?: Date;
        DhSorteio?: Date;
        QtdApostas?: number;
        CodStatus?: number;
        Numeros: number[];
    }

    export class Sorteio extends app.domain.EntityBase implements ISorteio {
        constructor(public IdTipo: number,
            public Numeros: number[],
            public NumSorteio?: number,
            public Id?: number,
            public DhCriacao?: Date,
            public DhSorteio?: Date,
            public CodStatus?: number,
            public QtdApostas?: number) {

            super();

            this.Id = Id;
            this.IdTipo = IdTipo;
            this.NumSorteio = NumSorteio;
            this.DhCriacao = DhCriacao;
            this.DhSorteio = DhSorteio;
            this.CodStatus = CodStatus;
            this.QtdApostas = QtdApostas;
            this.Numeros = Numeros;
        }
    }
}