
namespace Tenants {

    export class TenantsIndexController {

        private elements = {
            tenantsTable: () => $("#tenantsTable")
        }

        constructor() {
            this.initDataTable();
        }

        private initDataTable(): void {
            let controller = this;

            controller.elements.tenantsTable().DataTable();
        }
    }

    export var tenantsIndexController = new TenantsIndexController();
}