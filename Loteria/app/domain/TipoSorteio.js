var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var app;
(function (app) {
    var domain;
    (function (domain) {
        var TipoSorteio = (function (_super) {
            __extends(TipoSorteio, _super);
            function TipoSorteio(Descricao, Id, NumSorteioCorrente) {
                _super.call(this);
                this.Descricao = Descricao;
                this.Id = Id;
                this.NumSorteioCorrente = NumSorteioCorrente;
                this.Id = Id;
                this.Descricao = Descricao;
                this.NumSorteioCorrente = NumSorteioCorrente;
            }
            return TipoSorteio;
        }(app.domain.EntityBase));
        domain.TipoSorteio = TipoSorteio;
    })(domain = app.domain || (app.domain = {}));
})(app || (app = {}));
//# sourceMappingURL=TipoSorteio.js.map