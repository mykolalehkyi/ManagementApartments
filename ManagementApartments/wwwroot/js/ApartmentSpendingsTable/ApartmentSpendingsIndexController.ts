
namespace ApartmentSpendings {

    export class ApartmentSpendingsIndexController {

        private elements = {
            apartmentSpendingsTable: () => $("#apartmentSpendingsTable")
        }

        constructor() {
            this.initDataTable();
        }

        private initDataTable(): void {
            let controller = this; 

            controller.elements.apartmentSpendingsTable().DataTable();
        }
    }

    export var apartmentSpendingsIndexController = new ApartmentSpendingsIndexController();
}