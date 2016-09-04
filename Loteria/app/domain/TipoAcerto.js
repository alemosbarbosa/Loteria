var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var app;
(function (app) {
    var domain;
    (function (domain) {
        var TipoAcerto = (function (_super) {
            __extends(TipoAcerto, _super);
            function TipoAcerto(IdTipo, Descricao, QtdNumerosAcertados, Id) {
                _super.call(this);
                this.IdTipo = IdTipo;
                this.Descricao = Descricao;
                this.QtdNumerosAcertados = QtdNumerosAcertados;
                this.Id = Id;
                this.Id = Id;
                this.IdTipo = IdTipo;
                this.Descricao = Descricao;
                this.QtdNumerosAcertados = QtdNumerosAcertados;
            }
            return TipoAcerto;
        }(app.domain.EntityBase));
        domain.TipoAcerto = TipoAcerto;
    })(domain = app.domain || (app.domain = {}));
})(app || (app = {}));
