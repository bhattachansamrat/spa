(
    function (app) {
        'use strict';
        app.factory('appService', appService);
        appService.$inject = ['$http', '$location', '$rootScope', 'notificationService'];

        function appService($http, $location, $rootScope, notificationService) {
            var service = {
                get: get,
                post: post
            };

            function get(url, config, success, failure) {
                $http.get(url, config)
                    .then(function (data) {
                        success(data);
                    },
                    function (error) {
                        if ('401' == error.status) {
                            notificationService.displayError('Authentication required');
                            $rootScope.previous = $location.path();
                            $location.path('/login');
                        }
                        else if(null != failure) {
                            failure(error);
                        }
                    });
            }

            function post(url, data, success, failure) {
                $http.post(url, data)
                .then(function (result) {
                    success(result);
                }, function (error) {
                    if ('401' == error.status) {
                        notificationService.displayError('Authentication required');
                        $rootScope.previous = $location.path();
                        $location.path('/login');
                    }
                    else if(null != failure) {
                        failure(error);
                    }
                });
            }

            return service;
        }
    }
)(angular.module('common.core'));