var ApartmentSpendings;
(function (ApartmentSpendings) {
    var ApartmentSpendingsIndexController = /** @class */ (function () {
        function ApartmentSpendingsIndexController() {
            this.elements = {
                apartmentSpendingsTable: function () { return $("#apartmentSpendingsTable"); }
            };
            this.initDataTable();
        }
        ApartmentSpendingsIndexController.prototype.initDataTable = function () {
            var controller = this;
            controller.elements.apartmentSpendingsTable().DataTable();
        };
        return ApartmentSpendingsIndexController;
    }());
    ApartmentSpendings.ApartmentSpendingsIndexController = ApartmentSpendingsIndexController;
    ApartmentSpendings.apartmentSpendingsIndexController = new ApartmentSpendingsIndexController();
})(ApartmentSpendings || (ApartmentSpendings = {}));
//# sourceMappingURL=ApartmentSpendingsIndexController.js.map