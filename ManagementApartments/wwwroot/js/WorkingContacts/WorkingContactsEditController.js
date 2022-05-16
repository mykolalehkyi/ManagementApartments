var WorkingContacts;
(function (WorkingContacts) {
    var WorkingContactsEditController = /** @class */ (function () {
        function WorkingContactsEditController() {
            this.elements = {
                workingContactTable: function () { return $("#workingContactTable"); }
            };
            this.initDataTable();
        }
        WorkingContactsEditController.prototype.initDataTable = function () {
            var controller = this;
            controller.elements.workingContactTable().DataTable();
        };
        return WorkingContactsEditController;
    }());
    WorkingContacts.WorkingContactsEditController = WorkingContactsEditController;
    WorkingContacts.workingContactsEditController = new WorkingContactsEditController();
})(WorkingContacts || (WorkingContacts = {}));
//# sourceMappingURL=WorkingContactsEditController.js.map