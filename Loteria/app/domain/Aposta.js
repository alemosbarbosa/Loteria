var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var app;
(function (app) {
    var domain;
    (function (domain) {
        var Aposta = (function (_super) {
            __extends(Aposta, _super);
            function Aposta(IdApostador, IdSorteio, Numeros, Id, DhAposta, IdTipoAcerto) {
                _super.call(this);
                this.IdApostador = IdApostador;
                this.IdSorteio = IdSorteio;
                this.Numeros = Numeros;
                this.Id = Id;
                this.DhAposta = DhAposta;
                this.IdTipoAcerto = IdTipoAcerto;
                this.Id = Id;
                this.IdApostador = IdApostador;
                this.IdSorteio = IdSorteio;
                this.DhAposta = DhAposta;
                this.IdTipoAcerto = IdTipoAcerto;
                this.Numeros = Numeros;
            }
            return Aposta;
        }(app.domain.EntityBase));
        domain.Aposta = Aposta;
    })(domain = app.domain || (app.domain = {}));
})(app || (app = {}));
//# sourceMappingURL=Aposta.js.map