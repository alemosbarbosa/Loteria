module app.domain {
    export interface ITipoSorteio {
        Id?: number;
        Descricao: string;
        NumSorteioCorrente?: number;
        MinNumerosPorJogo: number;
        MaxNumerosPorJogo: number;
        MinValorNumero: number;
        MaxValorNumero: number;
    }

    export class TipoSorteio extends app.domain.EntityBase implements ITipoSorteio {
        constructor(public Descricao: string,
            public MinNumerosPorJogo: number,
            public MaxNumerosPorJogo: number,
            public MinValorNumero: number,
            public MaxValorNumero: number,
            public Id?: number,
            public NumSorteioCorrente?: number) {

            super();

            this.Id = Id;
            this.Descricao = Descricao;
            this.NumSorteioCorrente = NumSorteioCorrente;
            this.MinNumerosPorJogo = MinNumerosPorJogo;
            this.MaxNumerosPorJogo = MaxNumerosPorJogo;
            this.MinValorNumero = MinValorNumero;
            this.MaxValorNumero = MaxValorNumero;
        }
    }
}