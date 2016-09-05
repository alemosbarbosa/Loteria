module app.domain {
    export interface IAcerto {
        Id?: number;
        IdSorteio: number;
        IdAposta: number;
        NomeAcertador?: string;
        DescricaoTipoAcerto?: string;
    }

    export class Acerto extends app.domain.EntityBase implements IAcerto {
        constructor(public IdSorteio: number,
            public IdAposta: number,
            public Id?: number,
            public NomeAcertador?: string,
            public DescricaoTipoAcerto?: string) {

            super();

            this.Id = Id;
            this.IdSorteio = IdSorteio;
            this.IdAposta = IdAposta;
            this.NomeAcertador = NomeAcertador;
            this.DescricaoTipoAcerto = DescricaoTipoAcerto;
        }
    }
}