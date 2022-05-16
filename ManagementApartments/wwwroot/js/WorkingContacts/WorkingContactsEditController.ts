
namespace WorkingContacts {

    export class WorkingContactsEditController {

        private elements = {
            workingContactTable: () => $("#workingContactTable")
        }

        constructor() {
            this.initDataTable();
        }

        private initDataTable(): void {
            let controller = this; 

            controller.elements.workingContactTable().DataTable();
        }
    }

    export var workingContactsEditController = new WorkingContactsEditController();
}