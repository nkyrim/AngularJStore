(function () {
    angular
        .module('store')
        .controller('ordersController', ['$http', ordersController]);

    function ordersController($http) {
        var vm = this;
        initializeVm(vm);

        vm.getCustomerOrders = function (customer) {
            vm.orders = [];
            vm.isLoadingOrders = true;
            $http.post('api/Order/GetOrders', { id: customer.Id })
                .then(function (response) {
                    vm.orders = response.data.Data;
                })
                .finally(function () {
                    vm.isLoadingOrders = false;
                });
        };

        //=========== Internal functions ===========
        function initializeVm(vm) {
            vm.message = null;
            vm.customers = [];
            vm.orders = [];
            vm.isLoadingCustomers = true;
            vm.isLoadingOrders = false;

            $http.get('api/Customer/GetAll')
                .then(function (response) {
                    vm.customers = response.data.Data;
                })
                .finally(function () {
                    vm.isLoadingCustomers = false;
                });
        }
    }
})();
