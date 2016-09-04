var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var app;
(function (app) {
    var domain;
    (function (domain) {
        var Apostador = (function (_super) {
            __extends(Apostador, _super);
            function Apostador(Nome, Id, DhCadastro) {
                _super.call(this);
                this.Nome = Nome;
                this.Id = Id;
                this.DhCadastro = DhCadastro;
                this.Id = Id;
                this.Nome = Nome;
                this.DhCadastro = DhCadastro;
            }
            return Apostador;
        }(app.domain.EntityBase));
        domain.Apostador = Apostador;
    })(domain = app.domain || (app.domain = {}));
})(app || (app = {}));
//# sourceMappingURL=Apostador.js.map