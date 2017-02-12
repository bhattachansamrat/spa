(
    function () {
        'use strict';
        var app = angular.module('spa', ['common.core', 'common.ui'])
            .config(config)
            .run(run);

        config.$inject = ['$routeProvider'];
        function config($routeProvider) {
            $routeProvider.when("/", {
                templateUrl: 'scripts/spa/home/index.html',
                controller: 'homeCtrl'
            })
            .when("/login", {
                templateUrl: 'scripts/spa/account/login.html',
                controller: 'loginCtrl'
            })
            .when("/register", {
                templateUrl: 'scripts/spa/account/register.html',
                controller: 'registerCtrl'
            })
            .otherwise({redirectTo : '/'});
        }

        run.$inject = ['$rootScope', '$cookieStore', '$location', '$http'];
        function run($rootScope, $cookieStore, $location, $http) {
            $rootScope.repository = $cookieStore.getRepository('repository') || {};
            if ($rootScope.repository.loggedUser) {
                $http.defaults.headers.common['Authorization'] = $rootScope.repository.loggedUser.authData;
            }
        }
    }
)();