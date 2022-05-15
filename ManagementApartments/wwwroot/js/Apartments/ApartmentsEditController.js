/////// <reference path="../../lib/sweetalert/sweetalert.min.js" />
/////// <reference path="../sweetalerthelper.ts" />
/////// <reference path="../../lib/jquery/dist/jquery.js" />
var Apartments;
(function (Apartments) {
    var SaveImageFeedbackViewModel = /** @class */ (function () {
        function SaveImageFeedbackViewModel() {
        }
        return SaveImageFeedbackViewModel;
    }());
    var ApartmentsEditController = /** @class */ (function () {
        function ApartmentsEditController() {
            this.elements = {
                Id: function () { return $("#Id"); },
                inputUpdloadLogo: function () { return $("#inputUpdloadLogo"); },
                inputSelectedLogo: function () { return $("#inputSelectedLogo"); },
                lblBtnDeleteLogo: function () { return $("#lblBtnDeleteLogo"); },
                imgLogo: function () { return $("#imgLogo"); },
                lblInputUpdloadLogo: function () { return $("#lblInputUpdloadLogo"); },
                roomsTable: function () { return $("#roomsTable"); }
            };
            this.requestUrls = {
                saveLogo: this.elements.inputSelectedLogo().data("request-url"),
                deleteLogo: this.elements.lblBtnDeleteLogo().data("request-url")
            };
            this.bindInputUploadLogo();
            this.bindLblInputUpdloadLogo();
            this.initLblBtnDeleteLogo();
            this.initDataTable();
        }
        ApartmentsEditController.prototype.initLblBtnDeleteLogo = function () {
            var controller = this;
            if (controller.elements.imgLogo().attr("src") == "") {
                controller.emptyImgLogoCallback();
            }
            else {
                controller.existImgLogoCallback();
            }
        };
        ApartmentsEditController.prototype.bindInputUploadLogo = function () {
            var controller = this;
            controller.elements.inputUpdloadLogo().change(function (eventObject) {
                var formData = new FormData();
                controller.elements.inputSelectedLogo().val(this.value);
                var fileInputElement = controller.elements.inputUpdloadLogo()[0];
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
                    success: function (dataFromServer) {
                        if (dataFromServer.statusSuccess) {
                            controller.elements.imgLogo().attr("src", "data:image/jpg;base64," + dataFromServer.logoAsBase64);
                            controller.existImgLogoCallback();
                        }
                        else {
                            SweetAlertHelper.showErrorAlert(dataFromServer.title, dataFromServer.message);
                        }
                    }
                });
                controller.elements.inputUpdloadLogo().val();
            });
        };
        ApartmentsEditController.prototype.bindLblInputUpdloadLogo = function () {
            var controller = this;
            controller.elements.lblInputUpdloadLogo().keypress(function (eventObject) {
                if (eventObject.keyCode == 13) {
                    controller.elements.inputUpdloadLogo().click();
                }
            });
        };
        ApartmentsEditController.prototype.bindLblBtnDeleteImage = function () {
            var controller = this;
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
        };
        ApartmentsEditController.prototype.emptyImgLogoCallback = function () {
            var controller = this;
            controller.elements.imgLogo().attr("src", "");
            controller.elements.imgLogo().addClass("hidden");
            controller.elements.lblBtnDeleteLogo().attr("disabled", "true");
            controller.elements.lblBtnDeleteLogo().unbind();
        };
        ApartmentsEditController.prototype.existImgLogoCallback = function () {
            var controller = this;
            controller.elements.imgLogo().removeClass("hidden");
            controller.elements.lblBtnDeleteLogo().removeAttr("disabled");
            controller.bindLblBtnDeleteImage();
        };
        ApartmentsEditController.prototype.initDataTable = function () {
            var controller = this;
            this.datatable = controller.elements.roomsTable();
            controller.elements.roomsTable().DataTable({
                ajax: {
                    "url": controller.elements.roomsTable().data("request-url"),
                    "type": "GET",
                    "dataType": "json",
                    "data": { apartmentId: controller.elements.roomsTable().data("apartment-id") }
                },
                columns: [
                    { data: "name" },
                    { data: "roomStyle" },
                    { data: "area" },
                    {
                        data: "id",
                        render: function (data, type, row) {
                            return "<nobr><a href=\"/Rooms/Edit?id=".concat(data, "\" class=\"btn btn-primary\">Edit\u270E</a>\n                                    <a href=\"/Rooms/Delete?id=").concat(data, "\" class=\"btn btn-danger\">Delete</a></nobr>");
                        }
                    }
                ]
            });
        };
        return ApartmentsEditController;
    }());
    Apartments.ApartmentsEditController = ApartmentsEditController;
    Apartments.apartmentsEditController = new ApartmentsEditController();
})(Apartments || (Apartments = {}));
//# sourceMappingURL=ApartmentsEditController.js.map