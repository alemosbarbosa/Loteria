var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var app;
(function (app) {
    var domain;
    (function (domain) {
        var Sorteio = (function (_super) {
            __extends(Sorteio, _super);
            function Sorteio(IdTipo, Numeros, NumSorteio, Id, DhCriacao, DhSorteio, CodStatus, QtdApostas) {
                _super.call(this);
                this.IdTipo = IdTipo;
                this.Numeros = Numeros;
                this.NumSorteio = NumSorteio;
                this.Id = Id;
                this.DhCriacao = DhCriacao;
                this.DhSorteio = DhSorteio;
                this.CodStatus = CodStatus;
                this.QtdApostas = QtdApostas;
                this.Id = Id;
                this.IdTipo = IdTipo;
                this.NumSorteio = NumSorteio;
                this.DhCriacao = DhCriacao;
                this.DhSorteio = DhSorteio;
                this.CodStatus = CodStatus;
                this.QtdApostas = QtdApostas;
                this.Numeros = Numeros;
            }
            return Sorteio;
        }(app.domain.EntityBase));
        domain.Sorteio = Sorteio;
    })(domain = app.domain || (app.domain = {}));
})(app || (app = {}));
