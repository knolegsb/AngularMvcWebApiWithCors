﻿(function () {
    "use strict";

    angular.module("productManagement")
        .controller("productEditCtrl", productEditCtrl);

    function productEditCtrl(productResource) {
        var vm = this;
        vm.product = {};
        vm.message = '';

        productResource.get({ id: 5 },
            function (data) {
                vm.product = data;
                vm.originalProduct = angular.copy(data);
            });
            //function (response) {
            //    vm.message = response.statusText + "\r\n";
            //    if (response.data.exceptionMessage)
            //        vm.message += response.data.exceptionMessage;
            //});

        if (vm.product && vm.product.productId) {
            vm.title = "Edit: " + vm.product.productName;
        }
        else {
            vm.title = "New Product";
        }

        vm.submit = function () {
            vm.message = '';
            if (vm.product.productId) {
                vm.product.$update({ id: vm.product.productId },
                    function (data) {
                        vm.message = "... Save Complete";
                    })
            }
            else {
                vm.product.$save(
                    function (data) {
                        vm.originalProduct = angular.copy(data);
                    })
            }
        };

        vm.cancel = function (editForm) {
            editForm.$setPristine();
            vm.product = angular.copy(vm.originalProduct);
            vm.message = "";
        };
    }
}());