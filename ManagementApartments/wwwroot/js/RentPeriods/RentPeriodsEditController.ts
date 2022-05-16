namespace RentPeriods {

    export class RentPeriodsEditController {

        private elements = {
            tenantsIds: () => $("#tenantsIds")
        }

        constructor() {
            this.initTenantsSelect2();
        }

        private initTenantsSelect2(): void {
            let controller = this;

            controller.elements.tenantsIds().select2();
        }
    }

    export var rentPeriodsEditController = new RentPeriodsEditController();
}
