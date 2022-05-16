var RentPeriods;
(function (RentPeriods) {
    var RentPeriodsIndexController = /** @class */ (function () {
        function RentPeriodsIndexController() {
            this.elements = {
                rentPeriodsTable: function () { return $("#rentPeriodsTable"); }
            };
            this.initDataTable();
        }
        RentPeriodsIndexController.prototype.initDataTable = function () {
            var controller = this;
            controller.elements.rentPeriodsTable().DataTable();
        };
        return RentPeriodsIndexController;
    }());
    RentPeriods.RentPeriodsIndexController = RentPeriodsIndexController;
    RentPeriods.rentPeriodsIndexController = new RentPeriodsIndexController();
})(RentPeriods || (RentPeriods = {}));
//# sourceMappingURL=RentPeriodsIndexController.js.map