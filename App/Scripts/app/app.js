(function () {
    angular
        .module('store', ['ngRoute'])
        .config(['$routeProvider', function ($routeProvider) {
            $routeProvider
                .when('/', {
                    templateUrl: 'Html/Home'
                })
                .when('/Customers', {
                    templateUrl: 'Html/Customers',
                    controller: 'customersController',
                    controllerAs: 'customersCtrl'
                })
                .when('/Orders', {
                    templateUrl: 'Html/Orders',
                    controller: 'ordersController',
                    controllerAs: 'ordersCtrl'
                })
                .otherwise({ redirectTo: '/' });
        }]);
})();