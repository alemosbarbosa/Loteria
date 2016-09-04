var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var app;
(function (app) {
    var domain;
    (function (domain) {
        var StatusSorteio = (function (_super) {
            __extends(StatusSorteio, _super);
            function StatusSorteio(CodStatus, Descricao) {
                _super.call(this);
                this.CodStatus = CodStatus;
                this.Descricao = Descricao;
                this.CodStatus = CodStatus;
                this.Descricao = Descricao;
            }
            return StatusSorteio;
        }(app.domain.EntityBase));
        domain.StatusSorteio = StatusSorteio;
    })(domain = app.domain || (app.domain = {}));
})(app || (app = {}));
//# sourceMappingURL=StatusSorteio.js.map