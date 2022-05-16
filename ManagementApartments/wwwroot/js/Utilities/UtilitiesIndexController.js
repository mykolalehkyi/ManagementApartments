var Utilities;
(function (Utilities) {
    var UtilitiesIndexController = /** @class */ (function () {
        function UtilitiesIndexController() {
            this.elements = {
                utilitiesTable: function () { return $("#utilitiesTable"); }
            };
            this.initDataTable();
        }
        UtilitiesIndexController.prototype.initDataTable = function () {
            var controller = this;
            controller.elements.utilitiesTable().DataTable();
        };
        return UtilitiesIndexController;
    }());
    Utilities.UtilitiesIndexController = UtilitiesIndexController;
    Utilities.utilitiesIndexController = new UtilitiesIndexController();
})(Utilities || (Utilities = {}));
//# sourceMappingURL=UtilitiesIndexController.js.map