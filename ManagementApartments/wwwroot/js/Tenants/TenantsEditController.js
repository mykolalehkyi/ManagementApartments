var Tenants;
(function (Tenants) {
    var TenantsEditController = /** @class */ (function () {
        function TenantsEditController() {
            this.elements = {
                tenantsIds: function () { return $("#tenantsIds"); }
            };
            this.initTenantsSelect2();
        }
        TenantsEditController.prototype.initTenantsSelect2 = function () {
            var controller = this;
            controller.elements.tenantsIds().select2();
        };
        return TenantsEditController;
    }());
    Tenants.TenantsEditController = TenantsEditController;
    Tenants.tenantsEditController = new TenantsEditController();
})(Tenants || (Tenants = {}));
//# sourceMappingURL=TenantsEditController.js.map