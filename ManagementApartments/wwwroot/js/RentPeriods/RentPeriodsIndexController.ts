
namespace RentPeriods {

    export class RentPeriodsIndexController {

        private elements = {
            rentPeriodsTable: () => $("#rentPeriodsTable")
        }

        constructor() {
            this.initDataTable();
        }

        private initDataTable(): void {
            let controller = this; 

            controller.elements.rentPeriodsTable().DataTable();
        }
    }

    export var rentPeriodsIndexController = new RentPeriodsIndexController();
}