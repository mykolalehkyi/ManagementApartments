
namespace Tenants {

    export class TenantsEditController {

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

    export var tenantsEditController = new TenantsEditController();
}