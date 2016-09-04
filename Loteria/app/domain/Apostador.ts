module app.domain {
    export interface IApostador {
        Id?: number;
        Nome: string;
        DhCadastro?: Date;
    }

    export class Apostador extends app.domain.EntityBase implements IApostador {
        constructor(public Nome: string,
            public Id?: number,
            public DhCadastro?: Date) {

            super();

            this.Id = Id;
            this.Nome = Nome;
            this.DhCadastro = DhCadastro;
        }
    }
}