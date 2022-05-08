/// <reference path="../../node_modules/sweetalert/typings/sweetalert.d.ts" />


class SweetAlertHelper {
    /*
        Timeout required because of the SweetAlert routine take some time to close the dialog.
        E.g., set focus to the element requires some little time gap between pressing close button and callback action execution.
    */
    static callBackTimeout = 100;

    static showSuccessAlert(title: string, text: string, confirmCallback: any = undefined, closeOnConfirm: boolean = true, html: boolean = false) {
        var previousWindowKeyDown = window.onkeydown;

        (<any>swal)({
            title: title,
            text: text,
            type: "success",
            confirmButtonColor: "#005dc8",
            confirmButtonText: "OK",
            closeOnConfirm: closeOnConfirm,
            html: html
        },
            (isConfirm: boolean) => {
                window.onkeydown = previousWindowKeyDown;

                if (isConfirm) {
                    if (confirmCallback) {
                        confirmCallback();
                    }
                }
            }
        );
    }

    static showAlert(title: string, text: string, confirmCallback: any = undefined, closeOnConfirm: boolean = true, confirmButtonText: string = undefined) {
        (<any>swal)({
            title: title,
            text: text,
            type: "info",
            confirmButtonColor: "#005dc8",
            confirmButtonText: confirmButtonText ? confirmButtonText : "OK",
            closeOnConfirm: closeOnConfirm,
            allowEscapeKey: false
        },
            (isConfirm: boolean) => {
                if (isConfirm) {
                    if (confirmCallback) {
                        confirmCallback();
                    }
                }
            }
        );
    }

    static showWarningAlert(title: string, text: string, confirmCallback: any = undefined, closeOnConfirm: boolean = true, confirmButtonText: string = undefined) {
        (<any>swal)({
            title: title,
            text: text,
            type: "warning",
            confirmButtonColor: "#005dc8",
            confirmButtonText: confirmButtonText ? confirmButtonText : "OK",
            closeOnConfirm: closeOnConfirm
        },
            (isConfirm: boolean) => {
                if (isConfirm) {
                    if (confirmCallback) {
                        confirmCallback();
                    }
                }
            }
        );
    }

    static showErrorAlert(title: string, text: string, confirmCallback: any = undefined, closeOnConfirm: boolean = true) {
        (<any>swal)({
            title: title,
            text: text,
            type: "error",
            confirmButtonColor: "#005dc8",
            confirmButtonText: "Close",
            closeOnConfirm: closeOnConfirm
        },
            (isConfirm: boolean) => {
                if (isConfirm) {
                    if (confirmCallback) {
                        confirmCallback();
                    }
                }
            });
    }

    static showErrorAlertWithCallbackTimeout(title: string, text: string, confirmCallback: any = undefined) {
        SweetAlertHelper.showErrorAlert(title, text, () => {
            if (confirmCallback) {
                setTimeout(() => {
                    confirmCallback();
                }, SweetAlertHelper.callBackTimeout);
            }
        });
    }

    static showWarningAlertWithCallbackTimeout(title: string, text: string, confirmCallback: any = undefined) {
        SweetAlertHelper.showWarningAlert(title, text, () => {
            if (confirmCallback) {
                setTimeout(() => {
                    confirmCallback();
                }, SweetAlertHelper.callBackTimeout);
            }
        });
    }

    static showConfirmAlert(title: string, text: string, confirmCallback: any = undefined, cancelCallback: any = undefined, closeOnConfirm: boolean = true, closeOnCancel: boolean = true, confirmButtonText: string = undefined, cancelButtonText: string = undefined) {
        var previousWindowKeyDown = window.onkeydown;
        (<any>swal)({
            title: title,
            text: text,
            type: "warning",
            showCancelButton: true,
            confirmButtonColor: "#005dc8",
            confirmButtonText: confirmButtonText ? confirmButtonText : "Yes",
            cancelButtonText: cancelButtonText ? cancelButtonText : "No",
            closeOnConfirm: closeOnConfirm,
            closeOnCancel: closeOnCancel
        },
            (isConfirm: boolean) => {
                window.onkeydown = previousWindowKeyDown;
                if (isConfirm) {
                    if (confirmCallback) {
                        confirmCallback();
                    }
                } else {
                    if (cancelCallback) {
                        cancelCallback();
                    }
                }
            }
        );
    }

    //In case you have second Confirm Alert and you dont want to set closeOnConfirm = false(to prevent hiding second Alert) - because multiple triggering is possible
    //200 milliseconds shoud be enough
    static showConfirmAlertWithCallbackTimeout(title: string, text: string, confirmCallback: any = undefined, cancelCallback: any = undefined, closeOnConfirm: boolean = true, closeOnCancel: boolean = true, confirmButtonText: string = undefined, cancelButtonText: string = undefined) {
        var previousWindowKeyDown = window.onkeydown;
        (<any>swal)({
            title: title,
            text: text,
            type: "warning",
            showCancelButton: true,
            confirmButtonColor: "#005dc8",
            confirmButtonText: confirmButtonText ? confirmButtonText : "Yes",
            cancelButtonText: cancelButtonText ? cancelButtonText : "No",
            closeOnConfirm: closeOnConfirm,
            closeOnCancel: closeOnCancel
        },
            (isConfirm: boolean) => {
                window.onkeydown = previousWindowKeyDown;
                if (isConfirm) {
                    if (confirmCallback) {
                        setTimeout(() => {
                            confirmCallback();
                        }, 200);
                    }
                } else {
                    if (cancelCallback) {
                        setTimeout(() => {
                            cancelCallback();
                        }, 200);
                    }
                }
            }
        );
    }

    static showPrompt(title, text, initValue, confirmCallback: any = undefined, validateCallback: (value: string | boolean) => SweetAlertValidationResult = undefined) {
        (<any>swal)({
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
            var validationResult: SweetAlertValidationResult = null;
            if (validateCallback) {
                validationResult = validateCallback(inputValue);
                if (!validationResult.isValid) {
                    (<any>swal).showInputError(validationResult.validationMessage);
                    return false;
                }
            }
            if (confirmCallback) {
                confirmCallback(validationResult ? validationResult.value : inputValue);
                (<any>swal).close();
            }
        });
    }
}

interface SweetAlertValidationResult {
    validationMessage: string,
    isValid: boolean,
    value: any
}