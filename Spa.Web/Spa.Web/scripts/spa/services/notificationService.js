(
    function (app) {
        'use strict';

        app.factory('notificationService', notificationService);

        function notificationService() {
            toastr.options = {
                "debug": false,
                "positionClass": "toast-top-right",
                "onclick": null,
                "fadeIn": 300,
                "fadeOut": 1000,
                "timeOut": 3000,
                "extendedTimeOut": 1000
            };

            var service = {
                displayError: displayError,
                displaySuccess: displaySuccess,
                displayWarning: displayWarning,
                displayInfo: displayInfo
            };

            function displaySuccess(message) {
                toastr.success(message);
            }

            function displayWarning(message) {
                toastr.warning(message);
            }

            function displayInfo(message) {
                toastr.info(message);
            }

            function displayError(errors) {
                if (Array.isArray(errors)) {
                    errors.forEach(function (err) {
                        toastr.error(err);
                    });
                }else {
                    toastr.error(errors);
                }
            }

            return service;
        }
    }
)(angular.module('common.core'));