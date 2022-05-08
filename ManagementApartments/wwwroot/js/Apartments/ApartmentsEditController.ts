/////// <reference path="../../lib/sweetalert/sweetalert.min.js" />
/////// <reference path="../sweetalerthelper.ts" />
/////// <reference path="../../lib/jquery/dist/jquery.js" />

namespace Apartments {

    class SaveImageFeedbackViewModel {
        public StatusSuccess: boolean;
        public Title: string;
        public Message: string;
        public LogoAsBase64: string;
    }

    export class ApartmentsEditController {

        private elements = {
            Id: () => $("#Id"),
            inputUpdloadLogo: () => $("#inputUpdloadLogo"),
            inputSelectedLogo: () => $("#inputSelectedLogo"),
            lblBtnDeleteLogo: () => $("#lblBtnDeleteLogo"),
            imgLogo: () => $("#imgLogo"),
            lblInputUpdloadLogo: () => $("#lblInputUpdloadLogo")
        }

        private requestUrls = {
            saveLogo: this.elements.inputSelectedLogo().data("request-url"),
            deleteLogo: this.elements.lblBtnDeleteLogo().data("request-url")
        }

        constructor() {
            this.bindInputUploadLogo();
            this.bindLblInputUpdloadLogo();
            this.initLblBtnDeleteLogo();
        }

        private initLblBtnDeleteLogo() {
            let controller = this;

            if (controller.elements.imgLogo().attr("src") == "") {
                controller.emptyImgLogoCallback();
            }
            else {
                controller.existImgLogoCallback();
            }
        }

        private bindInputUploadLogo() {
            let controller = this;
            controller.elements.inputUpdloadLogo().change(function (eventObject) {
                let formData = new FormData();
                controller.elements.inputSelectedLogo().val((<any>this).value);

                let fileInputElement = <HTMLInputElement>controller.elements.inputUpdloadLogo()[0];
                if (fileInputElement.files.length === 0) {
                    SweetAlertHelper.showErrorAlertWithCallbackTimeout("Error", "Please select file", function () {
                        fileInputElement.focus();
                    });
                    return;
                }

                var filesize = ((fileInputElement.files[0].size / 1024) / 1024); // MB
                if (filesize > 5.0) {
                    SweetAlertHelper.showErrorAlertWithCallbackTimeout("Uploaded file too large", "Size, bigger than 5 MB, is not allowed. \n Select other file.  ", function () {
                        fileInputElement.focus();
                    });
                    return;
                }

                formData.append("file", fileInputElement.files[0]);
                formData.append("apartmentId", controller.elements.Id().val().toString());

                $.ajax({
                    type: "POST",
                    url: controller.requestUrls.saveLogo,
                    data: formData,
                    cache: false,
                    contentType: false,
                    processData: false,
                    success: function (dataFromServer: SaveImageFeedbackViewModel) {
                        if (dataFromServer.StatusSuccess) {
                            controller.elements.imgLogo().attr("src", "data:image/jpg;base64," + dataFromServer.LogoAsBase64);
                            controller.existImgLogoCallback();
                        }
                        else {
                            SweetAlertHelper.showErrorAlert(dataFromServer.Title, dataFromServer.Message);
                        }
                    }
                });
                controller.elements.inputUpdloadLogo().val();
            });
        }

        private bindLblInputUpdloadLogo() {
            let controller = this;

            controller.elements.lblInputUpdloadLogo().keypress(function (eventObject) {
                if (eventObject.keyCode == 13) {
                    controller.elements.inputUpdloadLogo().click();
                }
            });
        }

        private bindLblBtnDeleteImage() {
            let controller = this;
            controller.elements.lblBtnDeleteLogo().click(function (eventObject) {
                controller.elements.inputSelectedLogo().val();
                $.ajax({
                    url: controller.requestUrls.deleteLogo,
                    data: { apartmentId: controller.elements.Id().val().toString() },
                    method: "POST",
                    success: function (dataFromServer) {
                        controller.emptyImgLogoCallback();
                    },
                });
            });
        }

        private emptyImgLogoCallback() {
            let controller = this;

            controller.elements.imgLogo().attr("src", "");
            controller.elements.imgLogo().addClass("hidden");
            controller.elements.lblBtnDeleteLogo().attr("disabled", "true");
            controller.elements.lblBtnDeleteLogo().unbind();
        }

        private existImgLogoCallback() {
            let controller = this;

            controller.elements.imgLogo().removeClass("hidden");
            controller.elements.lblBtnDeleteLogo().removeAttr("disabled");
            controller.bindLblBtnDeleteImage();
        }
    }

    export var apartmentsEditController = new ApartmentsEditController();
}