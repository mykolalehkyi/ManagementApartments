var RentPeriods;
(function (RentPeriods) {
    var RentPeriodsEditController = /** @class */ (function () {
        function RentPeriodsEditController() {
            this.elements = {
                tenantsIds: function () { return $("#tenantsIds"); }
            };
            this.initTenantsSelect2();
        }
        RentPeriodsEditController.prototype.initTenantsSelect2 = function () {
            var controller = this;
            controller.elements.tenantsIds().select2();
        };
        return RentPeriodsEditController;
    }());
    RentPeriods.RentPeriodsEditController = RentPeriodsEditController;
    RentPeriods.rentPeriodsEditController = new RentPeriodsEditController();
})(RentPeriods || (RentPeriods = {}));
//# sourceMappingURL=RentPeriodsEditController.js.map