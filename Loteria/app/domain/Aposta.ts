module app.domain {
    export interface IAposta {
        Id?: number;
        IdApostador: number;
        IdSorteio: number;
        DhAposta?: Date;
        IdTipoAcerto?: number;
        Numeros: number[];
        ApostaAutomatica?: boolean;
    }

    export class Aposta extends app.domain.EntityBase implements IAposta {
        constructor(public IdApostador: number,
            public IdSorteio: number,
            public Numeros: number[],
            public Id?: number,
            public DhAposta?: Date,
            public IdTipoAcerto?: number,
            public ApostaAutomatica?: boolean) {

            super();

            this.Id = Id;
            this.IdApostador = IdApostador;
            this.IdSorteio = IdSorteio;
            this.DhAposta = DhAposta;
            this.IdTipoAcerto = IdTipoAcerto;
            this.Numeros = Numeros;
            this.ApostaAutomatica = ApostaAutomatica;
        }
    }
}