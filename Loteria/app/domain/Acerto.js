var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var app;
(function (app) {
    var domain;
    (function (domain) {
        var Acerto = (function (_super) {
            __extends(Acerto, _super);
            function Acerto(IdSorteio, IdAposta, Id, NomeAcertador, DescricaoTipoAcerto) {
                _super.call(this);
                this.IdSorteio = IdSorteio;
                this.IdAposta = IdAposta;
                this.Id = Id;
                this.NomeAcertador = NomeAcertador;
                this.DescricaoTipoAcerto = DescricaoTipoAcerto;
                this.Id = Id;
                this.IdSorteio = IdSorteio;
                this.IdAposta = IdAposta;
                this.NomeAcertador = NomeAcertador;
                this.DescricaoTipoAcerto = DescricaoTipoAcerto;
            }
            return Acerto;
        }(app.domain.EntityBase));
        domain.Acerto = Acerto;
    })(domain = app.domain || (app.domain = {}));
})(app || (app = {}));
