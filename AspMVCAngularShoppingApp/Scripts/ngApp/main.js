var modules = modules || [];

(function () {
    'use strict';

    var productsService = function ($http, $q) {

        var product = {};

        product.GetAllProducts = function () {

            var productList = [];
            var productImageList = [];

            $http.get('/api/Product/GetProducts').success(function (data) {
                if (angular.isDefined(data))
                    productList = data;
            }).error(function (data) {
                // do some error handling here
            });

            $http.get('/api/Product/GetProductImages').success(function (data) {
                if (angular.isDefined(data))
                    productImageList = data;
            }).error(function (data) {
                // do some error handling here
            });

            return {
                ProductList: productList,
                ProductImageList: productImageList
            }
        };

        return product;
    };

    var shoppingCtrl = function (productsService) {

        var products = this;
        products.product = productsService.GetAllProducts().ProductsList;
        products.productImageList = productsService.GetAllProducts().ProductsImageList;

    };

    var mainMenu = function($scope) {
        // can create the main menu links list here instead of asp net
        $scope.modules = modules;
    };

    var ngApp = angular.module('ngApp', modules);

    ngApp.controller('MainMenu', mainMenu);

    ngApp.controller('ShoppingCtrl', ['ProductsService', shoppingCtrl]);

    ngApp.factory('ProductsService', ['$http', '$q', productsService]);
})();