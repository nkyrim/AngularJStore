(function () {
    angular
        .module('store')
        .controller('customersController', ['$http', customersController]);

    function customersController($http) {
        var vm = this;
        initializeVm(vm);

        vm.createNew = function () {
            clearAddEditForm();
            clearResponseMessage();
        };

        vm.setEditCustomer = function (customer) {
            clearAddEditForm();
            clearResponseMessage();
            vm.isInEditMode = true;
            vm.editCustomer = angular.copy(customer);
        };

        vm.addCustomer = function () {
            var customer = angular.copy(vm.editCustomer);

            if (vm.isInEditMode) {
                $http.post('api/Customer/Edit', customer)
                    .then(function (response) {
                        var editedIndex = vm.customers.findIndex(function (e) { return e.Id === customer.Id; });
                        vm.customers[editedIndex] = customer;

                        vm.message = 'Edited successfully!';
                        clearAddEditForm();
                    }, function (response) {
                        vm.isError = true;
                        vm.message = response.statusText;
                    });
            } else {
                $http.post('api/Customer/Add', customer)
                    .then(function (response) {
                        var addedCustomer = response.data.Data;
                        vm.customers.push(addedCustomer);

                        vm.message = 'Added successfully!';
                        clearAddEditForm();
                    }, function (response) {
                        vm.isError = true;
                        vm.message = response.statusText;
                    });
            }
        };

        vm.deleteCustomer = function (customer) {
            $http.delete('api/Customer/Delete', { id: customer.Id })
                .then(function (response) {
                    var deletedIndex = vm.customers.findIndex(function (e) { return e.Id === customer.Id; });
                    vm.customers.splice(deletedIndex, 1);

                    vm.message = 'Deleted successfully!';
                    clearAddEditForm();
                }, function (response) {
                    vm.isError = true;
                    vm.message = response.statusText;
                });
        };

        //=========== Internal functions =================

        function clearAddEditForm() {
            vm.editCustomer = {};
            vm.isInEditMode = false;
            vm.addEditForm.$setPristine();
        }

        function clearResponseMessage() {
            vm.message = null;
            vm.isError = false;
        }

        function initializeVm(vm) {
            vm.message = null;
            vm.editCustomer = {};
            vm.isInEditMode = false;
            vm.isSaving = false;
            vm.isError = false;
            vm.customers = [];
            vm.isLoadingCustomers = true;

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
