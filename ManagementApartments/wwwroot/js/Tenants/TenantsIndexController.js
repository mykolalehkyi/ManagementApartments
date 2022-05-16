var Tenants;
(function (Tenants) {
    var TenantsIndexController = /** @class */ (function () {
        function TenantsIndexController() {
            this.elements = {
                tenantsTable: function () { return $("#tenantsTable"); }
            };
            this.initDataTable();
        }
        TenantsIndexController.prototype.initDataTable = function () {
            var controller = this;
            controller.elements.tenantsTable().DataTable();
        };
        return TenantsIndexController;
    }());
    Tenants.TenantsIndexController = TenantsIndexController;
    Tenants.tenantsIndexController = new TenantsIndexController();
})(Tenants || (Tenants = {}));
//# sourceMappingURL=TenantsIndexController.js.map