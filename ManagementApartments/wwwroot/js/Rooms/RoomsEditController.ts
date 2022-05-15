/////// <reference path="../../lib/sweetalert/sweetalert.min.js" />
/////// <reference path="../sweetalerthelper.ts" />
/////// <reference path="../../lib/jquery/dist/jquery.js" />

namespace Apartments {

    export class RoomsEditController {
        private datatable;

        private elements = {
            Id: () => $("#Id"),
            equipmentsTable: () => $("#equipmentsTable")
        }

        constructor() {
            this.initDataTable();
        }

        private initDataTable(): void {
            let controller = this; 

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
                        render: function (data: string, type, row) {
                            return `<nobr><a href="/Equipments/Edit?id=${data}" class="btn btn-primary">Edit✎</a>
                                    <a href="/Equipments/Delete?id=${data}" class="btn btn-danger">Delete</a></nobr>`;
                        }
                    }
                ]
            });
        }
    }

    export var roomsEditController = new RoomsEditController();
}