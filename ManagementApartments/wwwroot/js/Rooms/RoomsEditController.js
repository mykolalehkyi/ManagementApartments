/////// <reference path="../../lib/sweetalert/sweetalert.min.js" />
/////// <reference path="../sweetalerthelper.ts" />
/////// <reference path="../../lib/jquery/dist/jquery.js" />
var Apartments;
(function (Apartments) {
    var RoomsEditController = /** @class */ (function () {
        function RoomsEditController() {
            this.elements = {
                Id: function () { return $("#Id"); },
                equipmentsTable: function () { return $("#equipmentsTable"); }
            };
            this.initDataTable();
        }
        RoomsEditController.prototype.initDataTable = function () {
            var controller = this;
            this.datatable = controller.elements.equipmentsTable();
            controller.elements.equipmentsTable().DataTable({
                ajax: {
                    "url": controller.elements.equipmentsTable().data("request-url"),
                    "type": "GET",
                    "dataType": "json",
                    "data": { roomId: controller.elements.equipmentsTable().data("room-id") }
                },
                columns: [
                    { data: "name" },
                    { data: "description" },
                    { data: "price" },
                    {
                        data: "id",
                        render: function (data, type, row) {
                            return "<nobr><a href=\"/Equipments/Edit?id=".concat(data, "\" class=\"btn btn-primary\">Edit\u270E</a>\n                                    <a href=\"/Equipments/Delete?id=").concat(data, "\" class=\"btn btn-danger\">Delete</a></nobr>");
                        }
                    }
                ]
            });
        };
        return RoomsEditController;
    }());
    Apartments.RoomsEditController = RoomsEditController;
    Apartments.roomsEditController = new RoomsEditController();
})(Apartments || (Apartments = {}));
//# sourceMappingURL=RoomsEditController.js.map