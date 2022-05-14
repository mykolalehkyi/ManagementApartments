var SweetAlertHelper = /** @class */ (function () {
    function SweetAlertHelper() {
    }
    SweetAlertHelper.showSuccessAlert = function (title, text, confirmCallback, closeOnConfirm, html) {
        if (confirmCallback === void 0) { confirmCallback = undefined; }
        if (closeOnConfirm === void 0) { closeOnConfirm = true; }
        if (html === void 0) { html = false; }
        var previousWindowKeyDown = window.onkeydown;
        swal.default({
            title: title,
            text: text,
            type: "success",
            confirmButtonColor: "#005dc8",
            confirmButtonText: "OK",
            closeOnConfirm: closeOnConfirm,
            html: html
        }, function (isConfirm) {
            window.onkeydown = previousWindowKeyDown;
            if (isConfirm) {
                if (confirmCallback) {
                    confirmCallback();
                }
            }
        });
    };
    SweetAlertHelper.showAlert = function (title, text, confirmCallback, closeOnConfirm, confirmButtonText) {
        if (confirmCallback === void 0) { confirmCallback = undefined; }
        if (closeOnConfirm === void 0) { closeOnConfirm = true; }
        if (confirmButtonText === void 0) { confirmButtonText = undefined; }
        swal({
            title: title,
            text: text,
            type: "info",
            confirmButtonColor: "#005dc8",
            confirmButtonText: confirmButtonText ? confirmButtonText : "OK",
            closeOnConfirm: closeOnConfirm,
            allowEscapeKey: false
        }, function (isConfirm) {
            if (isConfirm) {
                if (confirmCallback) {
                    confirmCallback();
                }
            }
        });
    };
    SweetAlertHelper.showWarningAlert = function (title, text, confirmCallback, closeOnConfirm, confirmButtonText) {
        if (confirmCallback === void 0) { confirmCallback = undefined; }
        if (closeOnConfirm === void 0) { closeOnConfirm = true; }
        if (confirmButtonText === void 0) { confirmButtonText = undefined; }
        swal({
            title: title,
            text: text,
            type: "warning",
            confirmButtonColor: "#005dc8",
            confirmButtonText: confirmButtonText ? confirmButtonText : "OK",
            closeOnConfirm: closeOnConfirm
        }, function (isConfirm) {
            if (isConfirm) {
                if (confirmCallback) {
                    confirmCallback();
                }
            }
        });
    };
    SweetAlertHelper.showErrorAlert = function (title, text, confirmCallback, closeOnConfirm) {
        if (confirmCallback === void 0) { confirmCallback = undefined; }
        if (closeOnConfirm === void 0) { closeOnConfirm = true; }
        swal({
            title: title,
            text: text,
            type: "error",
            confirmButtonColor: "#005dc8",
            confirmButtonText: "Close",
            closeOnConfirm: closeOnConfirm
        }, function (isConfirm) {
            if (isConfirm) {
                if (confirmCallback) {
                    confirmCallback();
                }
            }
        });
    };
    SweetAlertHelper.showErrorAlertWithCallbackTimeout = function (title, text, confirmCallback) {
        if (confirmCallback === void 0) { confirmCallback = undefined; }
        SweetAlertHelper.showErrorAlert(title, text, function () {
            if (confirmCallback) {
                setTimeout(function () {
                    confirmCallback();
                }, SweetAlertHelper.callBackTimeout);
            }
        });
    };
    SweetAlertHelper.showWarningAlertWithCallbackTimeout = function (title, text, confirmCallback) {
        if (confirmCallback === void 0) { confirmCallback = undefined; }
        SweetAlertHelper.showWarningAlert(title, text, function () {
            if (confirmCallback) {
                setTimeout(function () {
                    confirmCallback();
                }, SweetAlertHelper.callBackTimeout);
            }
        });
    };
    SweetAlertHelper.showConfirmAlert = function (title, text, confirmCallback, cancelCallback, closeOnConfirm, closeOnCancel, confirmButtonText, cancelButtonText) {
        if (confirmCallback === void 0) { confirmCallback = undefined; }
        if (cancelCallback === void 0) { cancelCallback = undefined; }
        if (closeOnConfirm === void 0) { closeOnConfirm = true; }
        if (closeOnCancel === void 0) { closeOnCancel = true; }
        if (confirmButtonText === void 0) { confirmButtonText = undefined; }
        if (cancelButtonText === void 0) { cancelButtonText = undefined; }
        var previousWindowKeyDown = window.onkeydown;
        swal({
            title: title,
            text: text,
            type: "warning",
            showCancelButton: true,
            confirmButtonColor: "#005dc8",
            confirmButtonText: confirmButtonText ? confirmButtonText : "Yes",
            cancelButtonText: cancelButtonText ? cancelButtonText : "No",
            closeOnConfirm: closeOnConfirm,
            closeOnCancel: closeOnCancel
        }, function (isConfirm) {
            window.onkeydown = previousWindowKeyDown;
            if (isConfirm) {
                if (confirmCallback) {
                    confirmCallback();
                }
            }
            else {
                if (cancelCallback) {
                    cancelCallback();
                }
            }
        });
    };
    //In case you have second Confirm Alert and you dont want to set closeOnConfirm = false(to prevent hiding second Alert) - because multiple triggering is possible
    //200 milliseconds shoud be enough
    SweetAlertHelper.showConfirmAlertWithCallbackTimeout = function (title, text, confirmCallback, cancelCallback, closeOnConfirm, closeOnCancel, confirmButtonText, cancelButtonText) {
        if (confirmCallback === void 0) { confirmCallback = undefined; }
        if (cancelCallback === void 0) { cancelCallback = undefined; }
        if (closeOnConfirm === void 0) { closeOnConfirm = true; }
        if (closeOnCancel === void 0) { closeOnCancel = true; }
        if (confirmButtonText === void 0) { confirmButtonText = undefined; }
        if (cancelButtonText === void 0) { cancelButtonText = undefined; }
        var previousWindowKeyDown = window.onkeydown;
        swal({
            title: title,
            text: text,
            type: "warning",
            showCancelButton: true,
            confirmButtonColor: "#005dc8",
            confirmButtonText: confirmButtonText ? confirmButtonText : "Yes",
            cancelButtonText: cancelButtonText ? cancelButtonText : "No",
            closeOnConfirm: closeOnConfirm,
            closeOnCancel: closeOnCancel
        }, function (isConfirm) {
            window.onkeydown = previousWindowKeyDown;
            if (isConfirm) {
                if (confirmCallback) {
                    setTimeout(function () {
                        confirmCallback();
                    }, 200);
                }
            }
            else {
                if (cancelCallback) {
                    setTimeout(function () {
                        cancelCallback();
                    }, 200);
                }
            }
        });
    };
    SweetAlertHelper.showPrompt = function (title, text, initValue, confirmCallback, validateCallback) {
        if (confirmCallback === void 0) { confirmCallback = undefined; }
        if (validateCallback === void 0) { validateCallback = undefined; }
        swal({
            title: title,
            text: text,
            inputValue: initValue,
            type: "input",
            confirmButtonColor: "#005dc8",
            confirmButtonText: "Confirm",
            cancelButtonText: "Cancel",
            closeOnConfirm: false,
            closeOnCancel: true,
            showCancelButton: true
        }, function (inputValue) {
            // cancel button click
            if (inputValue === false) {
                return false;
            }
            var validationResult = null;
            if (validateCallback) {
                validationResult = validateCallback(inputValue);
                if (!validationResult.isValid) {
                    swal.showInputError(validationResult.validationMessage);
                    return false;
                }
            }
            if (confirmCallback) {
                confirmCallback(validationResult ? validationResult.value : inputValue);
                swal.close();
            }
        });
    };
    /*
        Timeout required because of the SweetAlert routine take some time to close the dialog.
        E.g., set focus to the element requires some little time gap between pressing close button and callback action execution.
    */
    SweetAlertHelper.callBackTimeout = 100;
    return SweetAlertHelper;
}());
//# sourceMappingURL=SweetAlertHelper.js.map