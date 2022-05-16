
namespace Utilities {

    export class UtilitiesIndexController {

        private elements = {
            utilitiesTable: () => $("#utilitiesTable")
        }

        constructor() {
            this.initDataTable();
        }

        private initDataTable(): void {
            let controller = this; 

            controller.elements.utilitiesTable().DataTable();
        }
    }

    export var utilitiesIndexController = new UtilitiesIndexController();
}